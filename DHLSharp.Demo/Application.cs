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
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DHLSharp.Client.Models;
using DHLSharp.Client.Models.Order;
using DHLSharp.Client;

namespace DHLSharp.Demo
{
    public class Application
    {
        public DHLClientConfig _TestConfiguration { get; set; }
        public DHLClientConfig _ProductionConfiguration { get; set; }


        public Application()
        {
            DHLConfigurationFile configurationFile = DHLConfigurationLoader.Load("credentials.json");

            _TestConfiguration = new DHLClientConfig
            {
                TrackingUnifiedApiKey = configurationFile.Test.TrackingUnifiedApiKey,
                ApiKey = configurationFile.Test.ApiKey,
                ApiSecret = configurationFile.Test.ApiSecret,
                Username = configurationFile.Test.Username,
                Password = configurationFile.Test.Password,
                IsSandbox = configurationFile.Test.IsSandbox
            };

            Type t = ProductType.NationalMiniPackage.GetType();
            string s = t.ToString();

            // add billing numbers
            foreach (var kv in configurationFile.Test.BillingNumbers)
            {
                ProductType productType = ProductType.FromName(kv.Key);
                _TestConfiguration.BillingNumbers.Add(productType, kv.Value);
            }

            _ProductionConfiguration = new DHLClientConfig
            {
                TrackingUnifiedApiKey = configurationFile.Production.TrackingUnifiedApiKey,
                ApiKey = configurationFile.Production.ApiKey,
                ApiSecret = configurationFile.Production.ApiSecret,
                Username = configurationFile.Production.Username,
                Password = configurationFile.Production.Password,
                IsSandbox = configurationFile.Production.IsSandbox
            };

            // add billing numbers
            foreach (var kv in configurationFile.Production.BillingNumbers)
            {
                ProductType productType = ProductType.FromName(kv.Key);
                _ProductionConfiguration.BillingNumbers.Add(productType, kv.Value);
            }
        } /// !Application()


        public async Task RunAsync()
        {
            DHLClient client = new DHLClient(_ProductionConfiguration);
            var result = await client.TrackShipmentAsync("00340434299339705230", "de");

            /*
            DHLClient api = new DHLClient(_TestConfiguration);
            Shipment[] shipments = new[]
                {
                new Shipment
                {
                    Product = ProductType.NationalPackage,         
                    RefNo = "Order No. 1234",
                    ShipDate = DateTime.Today,
                    Shipper = new Shipper
                    {
                        Name1 = "My Online Shop GmbH",
                        AddressStreet = "Str‰ﬂchensweg 10",
                        PostalCode = "53113",
                        City = "Bonn",
                        Country = CountryCode.Germany,
                        Email = "max@mustermann.de",
                        Phone = "+49 123456789"
                    },
                    Consignee = new Consignee
                    {
                        Name = "Maria Musterfrau",
                        PostNumber = "12345678",
                        RetailID = "502",
                        PostalCode = "53113",
                        City = "Bonn",
                        Country = CountryCode.Germany
                    },
                    Details = new Details
                    {
                        Dimensions = new Dimensions
                        {
                            Uom = "mm",
                            Height = 100,
                            Length = 200,
                            Width = 150
                        },
                        Weight = new Weight
                        {
                            Uom = "g",
                            Value = 500
                        }
                    }
                }
            };
            //  var result = await api.CreateShipmentAsync("STANDARD_GRUPPENPROFIL", shipments, validate: false);

            await api.TrackShipmentAsync("LE046975012DE", "de");
            */
        }
    }
}
