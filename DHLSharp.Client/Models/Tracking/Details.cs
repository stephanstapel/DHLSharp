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
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DHLSharp.Client.Models.Tracking
{
    public class Details
    {
        [JsonPropertyName("product")]
        public Product Product { get; set; }

        [JsonPropertyName("proofOfDeliverySignedAvailable")]
        public bool ProofOfDeliverySignedAvailable { get; set; }

        [JsonPropertyName("totalNumberOfPieces")]
        public int TotalNumberOfPieces { get; set; }

        [JsonPropertyName("pieceIds")]
        public List<string> PieceIds { get; set; }

        [JsonPropertyName("weight")]
        public Measurement Weight { get; set; }

        [JsonPropertyName("dimensions")]
        public Dimensions Dimensions { get; set; }
    }
}
