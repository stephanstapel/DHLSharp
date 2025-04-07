/*
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Channels;
using System.Threading.Tasks;
using DHLSharp.Client.Models;
using DHLSharp.Client.Models.Order;
using DHLSharp.Client.Models.Tracking;
using static System.Net.WebRequestMethods;

namespace DHLSharp.Client
{
    public class DHLClient
    {
        private readonly string DhlTrackingUnifiedApiUrl;
        private readonly string DhlApiUrl;
        private readonly string AuthUrl;

        private readonly DHLClientConfig _config;
        private string _bearerToken;

        private static readonly SemaphoreSlim _unifiedTrackingRateLimitSemaphore = new SemaphoreSlim(1, 1);
        private static DateTime _unifiedTrackingLastRequestTime = DateTime.MinValue;


        public DHLClient(DHLClientConfig config)
        {
            _config = config;

            if (_config.IsSandbox)
            {
                DhlTrackingUnifiedApiUrl = "https://api-eu.dhl.com/track/shipments";
                DhlApiUrl = "https://api-sandbox.dhl.com/parcel/de/shipping/v2/";
                AuthUrl = "https://api-sandbox.dhl.com/parcel/de/account/auth/ropc/v1/token";                
            }
            else
            {
                DhlTrackingUnifiedApiUrl = "https://api-eu.dhl.com/track/shipments";
                DhlApiUrl = "https://api-eu.dhl.com/parcel/de/shipping/v2/";
                AuthUrl = "https://api-eu.dhl.com/parcel/de/account/auth/ropc/v1/token";
            }
        } // !DHLSharp()


        private async Task<string> _GetAuthTokenAsync()
        {
            if (!string.IsNullOrEmpty(_bearerToken))
            {
                return _bearerToken;
            }

            using var client = new HttpClient();
            var content = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        { "grant_type", "password" },
                        { "username", _config.Username },
                        { "password", _config.Password },
                        { "client_id", _config.ApiKey },
                        { "client_secret", _config.ApiSecret }
                    });

            var response = await client.PostAsync(AuthUrl, content);

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read and display the response from the API
                var responseContent = await response.Content.ReadAsStringAsync();
                var jsonDoc = JsonDocument.Parse(responseContent);
                _bearerToken = jsonDoc.RootElement.GetProperty("access_token").GetString();
            }

            return _bearerToken;
        } // !_GetAuthTokenAsync()


        /// <summary>
        /// Optionally, you can pass a rate limit using the applyRateLimit parameter. This will make the function wait for the
        /// delay that is specified in DHLConfig.TrackingRateLimitInMiliseconds
        /// </summary>
        /// <param name="shipmentNo"></param>
        /// <param name="language"></param>
        /// <param name="service"></param>
        /// <param name="originCountryCode"></param>
        /// <param name="requesterCountryCode"></param>
        /// <param name="applyRateLimit"></param>
        /// <returns></returns>
        public async Task<List<Models.Tracking.Shipment>> TrackShipmentAsync(string shipmentNo, string language = "", Service? service = null, string originCountryCode = "", string requesterCountryCode = "", bool applyRateLimit = false)
        {
            if (applyRateLimit)
            {
                await _unifiedTrackingRateLimitSemaphore.WaitAsync();
                try
                {
                    var rateLimitDelay = TimeSpan.FromMilliseconds(_config.TrackingRateLimitInMiliseconds);
                    var now = DateTime.UtcNow;
                    var timeSinceLastRequest = now - _unifiedTrackingLastRequestTime;

                    if (timeSinceLastRequest < rateLimitDelay)
                    {
                        var delay = rateLimitDelay - timeSinceLastRequest;
                        await Task.Delay(delay);
                    }

                    _unifiedTrackingLastRequestTime = DateTime.UtcNow;
                }
                finally
                {
                    _unifiedTrackingRateLimitSemaphore.Release();
                }
            }

            var uriBuilder = new UriBuilder(DhlTrackingUnifiedApiUrl);
            var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);

            if (!String.IsNullOrWhiteSpace(shipmentNo))
            {
                query["trackingNumber"] = shipmentNo;
            }

            if (!String.IsNullOrWhiteSpace(language))
            {
                query["language"] = language;
            }

            if (service.HasValue)
            {
                query["service"] = EnumExtensions.EnumToString<Service>(service);
            }

            if (!String.IsNullOrWhiteSpace(originCountryCode))
            {
                query["originCountryCode"] = originCountryCode;
            }

            if (!String.IsNullOrWhiteSpace(requesterCountryCode))
            {
                query["requesterCountryCode"] = requesterCountryCode;
            }

            uriBuilder.Query = query.ToString();
            var requestUrl = uriBuilder.ToString();

            using var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);            
            request.Headers.Add("DHL-API-Key", _config.TrackingUnifiedApiKey);
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string s = await response.Content.ReadAsStringAsync();
            ShipmentResponse shipmentResponse = System.Text.Json.JsonSerializer.Deserialize<ShipmentResponse>(s);
            return shipmentResponse?.Shipments;
        } // !TrackShipmentAsync()


        /// <summary>
        /// This request is used to create one or more shipments and return corresponding shipment tracking numbers,
        /// labels, and documentation. Up to 30 shipments can be created in a single call.
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="shipments"></param>
        /// <param name="labelFormat"></param>
        /// <param name="retoureLabelFormat"></param>
        /// <param name="validate">If provided and set to true, the input document will be:
        /// * validated against JSON schema(/orders/ endpoint) at the API layer.In case of errors, HTTP 400 and details will be returned.
        /// * validated against the DHL backend.
        /// 
        /// In that case, no state changes are happening, no data is stored, shipments neither deleted nor created, no labels being returned.
        /// The call will return a status (200, 400) for each shipment element.
        /// </param>
        /// <param name="docFormat">Defines the printable document format to be used for label and manifest documents.
        /// Available values : ZPL2, PDF
        /// Default value : PDF</param>
        /// <param name="combine">If set, label and return label for one shipment will be printed as single PDF document with possibly
        /// multiple pages. Else, those two labels come as separate documents. The option does not affect customs documents and COD
        /// labels.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<OrderResponse> CreateShipmentAsync(
            string profile,
            IEnumerable<DHLSharp.Client.Models.Order.Shipment> shipments,
            LabelFormat? labelFormat = null,    
            LabelFormat? retoureLabelFormat = null,
            bool validate = true,
            string docFormat = "PDF",                        
            bool combine = true)
        {
            string bearerToken = await _GetAuthTokenAsync(); // Ensure the token is available before making the API call

            if (String.IsNullOrWhiteSpace(bearerToken))
            {
                throw new Exception("Could not load bearer token. Aborting API call.");
            }

            // serialize shipment data
            ShipmentRequest shipmentRequest = new ShipmentRequest
            {
                Profile = profile
            };

            foreach(Models.Order.Shipment shipment in shipments)
            {
                if (!_config.BillingNumbers.ContainsKey(shipment.Product))
                {
                    throw new Exception($"Billing number for product {shipment.Product} not found in config.");
                }

                Models.Order.JsonShipment jsonShipment = new Models.Order.JsonShipment(shipment, _config.BillingNumbers[shipment.Product]);
                shipmentRequest.Shipments.Add(jsonShipment);
            }

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            string jsonData = JsonSerializer.Serialize(shipmentRequest, options);

            // create URL
            var uriBuilder = new UriBuilder(DhlApiUrl + "orders");
            var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
            query["validate"] = validate.ToString().ToLower();

            if (!String.IsNullOrWhiteSpace(docFormat))
            {
                query["docFormat"] = docFormat;
            }

            query["includeDocs"] = "true";

            if (labelFormat != null)
            {
                query["printFormat"] = labelFormat.ToString();
            }            

            if (retoureLabelFormat != null)
            {
                query["retourePrintFormat"] = retoureLabelFormat.ToString();
            }

            query["combine"] = combine.ToString().ToLower();
            uriBuilder.Query = query.ToString();
            var requestUrl = uriBuilder.ToString();

            using var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, requestUrl);
            request.Headers.Add("Authorization", $"Bearer {bearerToken}");
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            request.Content = content;

            _LogHttpRequest(request);

            var response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {response.StatusCode}, Content: {responseContent}");
                response.EnsureSuccessStatusCode();
            }

            var responseData = await response.Content.ReadAsStringAsync();
            var orderResponse = JsonSerializer.Deserialize<OrderResponse>(responseData, options);
            Console.WriteLine(responseData);

            return orderResponse;
        } // !CreateShipmentAsync()


        private void _LogHttpRequest(HttpRequestMessage request)
        {
            Console.WriteLine("HTTP Request:");
            Console.WriteLine($"{request.Method} {request.RequestUri}");
            foreach (var header in request.Headers)
            {
                Console.WriteLine($"{header.Key}: {string.Join(", ", header.Value)}");
            }
            if (request.Content != null)
            {
                var contentTask = request.Content.ReadAsStringAsync();
                contentTask.Wait();
                Console.WriteLine("Content:");
                Console.WriteLine(contentTask.Result);
            }
        } // !_LogHttpRequest()
    }
}
