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
using System.Reflection;
using System.Runtime.CompilerServices;

public sealed record ProductType(string Code)
{    
    public static readonly ProductType NationalPackage = new("V01PAK");
    public static readonly ProductType InternationalPackage = new("V53WPAK");
    public static readonly ProductType EuropaPackage = new("V54EPAK");
    public static readonly ProductType SameDayPackage = new("V06PAK");
    public static readonly ProductType SameDayMessenger = new("V06TG");
    public static readonly ProductType WishTimeMessenger = new("V06WZ");
    public static readonly ProductType AustriaPackage = new("V86PARCEL");
    public static readonly ProductType AustriaInternationalPackage = new("V82PARCEL");
    public static readonly ProductType ConnectPackage = new("V87PARCEL");
    public static readonly ProductType NationalMiniPackage = new("V62KP");
    public static readonly ProductType InternationalWarenpost = new("V66WPI");

    public override string ToString() => Code;

    public static IEnumerable<ProductType> All => new[]
    {
        NationalPackage, InternationalPackage, EuropaPackage, SameDayPackage,
        SameDayMessenger, WishTimeMessenger, AustriaPackage, AustriaInternationalPackage, ConnectPackage
    };

    public static ProductType? FromCode(string code) =>
        All.FirstOrDefault(p => p.Code == code);

    public static ProductType? FromName(string name)
    {
        var field = typeof(ProductType)
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .FirstOrDefault(f => f.Name == name);

        return field?.GetValue(null) as ProductType;
    } // !FromName()
}
