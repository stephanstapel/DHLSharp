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
using System.Linq;

namespace DHLSharp.Client.Models.Order
{
    public sealed record LabelFormat(string Code)
    {
        public static readonly LabelFormat A4 = new("A4");
        public static readonly LabelFormat CommonLabelLaserA5_105x208 = new("910-300-700");
        public static readonly LabelFormat CommonLabelLaserA5_105x208_Oz = new("910-300-700-oz");
        public static readonly LabelFormat CommonLabelLaser_105x209 = new("910-300-710");
        public static readonly LabelFormat CommonLabelThermoFold_103x199 = new("910-300-600");
        public static readonly LabelFormat CommonLabelThermoRoll_103x199 = new("910-300-610");
        public static readonly LabelFormat CommonLabelThermoFold_103x150 = new("910-300-400");
        public static readonly LabelFormat CommonLabelThermoRoll_103x150 = new("910-300-410");
        public static readonly LabelFormat CommonLabelLaserA5_105x148 = new("910-300-300");
        public static readonly LabelFormat CommonLabelLaserA5_105x148_Oz = new("910-300-300-oz");

        public override string ToString() => Code;

        public static IEnumerable<LabelFormat> All => new[]
        {
            A4, CommonLabelLaserA5_105x208, CommonLabelLaserA5_105x208_Oz, CommonLabelLaser_105x209,
            CommonLabelThermoFold_103x199, CommonLabelThermoRoll_103x199, CommonLabelThermoFold_103x150,
            CommonLabelThermoRoll_103x150, CommonLabelLaserA5_105x148, CommonLabelLaserA5_105x148_Oz
        };

        public static LabelFormat? FromCode(string code) =>
            All.FirstOrDefault(l => l.Code == code);
    }
}
