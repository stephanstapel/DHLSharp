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
using System.Text.Json.Serialization;
using DHLSharp.Client.Models.Tracking;

public class OrderResponse
{
    [JsonPropertyName("status")]
    public Status Status { get; set; }

    [JsonPropertyName("items")]
    public List<Item> Items { get; set; }
}

public class Status
{
    [JsonPropertyName("title")]
    public string Title { get; set; }


    [JsonPropertyName("status")]
    public EventCode StatusCode { get; set; }
    

    [JsonPropertyName("detail")]
    public string Detail { get; set; }

    /*
    [JsonPropertyName("statusCode")]
    public int? StatusCodeDuplicate { get; set; }
    */
}

public class Item
{
    [JsonPropertyName("shipmentNo")]
    public string ShipmentNo { get; set; }

    [JsonPropertyName("sstatus")]
    public Status ShipmentStatus { get; set; }

    [JsonPropertyName("shipmentRefNo")]
    public string ShipmentRefNo { get; set; }

    [JsonPropertyName("label")]
    public Label Label { get; set; }

    [JsonPropertyName("validationMessages")]
    public List<string> ValidationMessages { get; set; }

    [JsonPropertyName("routingCode")]
    public string RoutingCode { get; set; }
}

public class Label
{
    [JsonPropertyName("b64")]
    public string Base64 { get; set; }

    [JsonPropertyName("fileFormat")]
    public string FileFormat { get; set; }

    [JsonPropertyName("printFormat")]
    public string PrintFormat { get; set; }
}
