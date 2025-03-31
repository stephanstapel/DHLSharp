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
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DHLSharp.Client.Converters;

namespace DHLSharp.Client.Models
{
    [JsonConverter(typeof(CountryCodeJsonConverter))]
    public sealed record CountryCode(string Code)
    {
        public static readonly CountryCode Afghanistan = new("AFG");
        public static readonly CountryCode Albania = new("ALB");
        public static readonly CountryCode Algeria = new("DZA");
        public static readonly CountryCode Andorra = new("AND");
        public static readonly CountryCode Angola = new("AGO");
        public static readonly CountryCode AntiguaAndBarbuda = new("ATG");
        public static readonly CountryCode Argentina = new("ARG");
        public static readonly CountryCode Armenia = new("ARM");
        public static readonly CountryCode Australia = new("AUS");
        public static readonly CountryCode Austria = new("AUT");
        public static readonly CountryCode Azerbaijan = new("AZE");
        public static readonly CountryCode Bahamas = new("BHS");
        public static readonly CountryCode Bahrain = new("BHR");
        public static readonly CountryCode Bangladesh = new("BGD");
        public static readonly CountryCode Barbados = new("BRB");
        public static readonly CountryCode Belarus = new("BLR");
        public static readonly CountryCode Belgium = new("BEL");
        public static readonly CountryCode Belize = new("BLZ");
        public static readonly CountryCode Benin = new("BEN");
        public static readonly CountryCode Bhutan = new("BTN");
        public static readonly CountryCode Bolivia = new("BOL");
        public static readonly CountryCode BosniaAndHerzegovina = new("BIH");
        public static readonly CountryCode Botswana = new("BWA");
        public static readonly CountryCode Brazil = new("BRA");
        public static readonly CountryCode Brunei = new("BRN");
        public static readonly CountryCode Bulgaria = new("BGR");
        public static readonly CountryCode BurkinaFaso = new("BFA");
        public static readonly CountryCode Burundi = new("BDI");
        public static readonly CountryCode CaboVerde = new("CPV");
        public static readonly CountryCode Cambodia = new("KHM");
        public static readonly CountryCode Cameroon = new("CMR");
        public static readonly CountryCode Canada = new("CAN");
        public static readonly CountryCode CentralAfricanRepublic = new("CAF");
        public static readonly CountryCode Chad = new("TCD");
        public static readonly CountryCode Chile = new("CHL");
        public static readonly CountryCode China = new("CHN");
        public static readonly CountryCode Colombia = new("COL");
        public static readonly CountryCode Comoros = new("COM");
        public static readonly CountryCode DemocraticRepublicOfCongo = new("COD");
        public static readonly CountryCode Congo = new("COG");
        public static readonly CountryCode CostaRica = new("CRI");
        public static readonly CountryCode Croatia = new("HRV");
        public static readonly CountryCode Cuba = new("CUB");
        public static readonly CountryCode Cyprus = new("CYP");
        public static readonly CountryCode Czechia = new("CZE");
        public static readonly CountryCode Denmark = new("DNK");
        public static readonly CountryCode Djibouti = new("DJI");
        public static readonly CountryCode Dominica = new("DMA");
        public static readonly CountryCode DominicanRepublic = new("DOM");
        public static readonly CountryCode Ecuador = new("ECU");
        public static readonly CountryCode Egypt = new("EGY");
        public static readonly CountryCode ElSalvador = new("SLV");
        public static readonly CountryCode EquatorialGuinea = new("GNQ");
        public static readonly CountryCode Eritrea = new("ERI");
        public static readonly CountryCode Estonia = new("EST");
        public static readonly CountryCode Eswatini = new("SWZ");
        public static readonly CountryCode Ethiopia = new("ETH");
        public static readonly CountryCode Fiji = new("FJI");
        public static readonly CountryCode Finland = new("FIN");
        public static readonly CountryCode France = new("FRA");
        public static readonly CountryCode Gabon = new("GAB");
        public static readonly CountryCode Gambia = new("GMB");
        public static readonly CountryCode Georgia = new("GEO");
        public static readonly CountryCode Germany = new("DEU");
        public static readonly CountryCode Ghana = new("GHA");
        public static readonly CountryCode Greece = new("GRC");
        public static readonly CountryCode Guatemala = new("GTM");
        public static readonly CountryCode Guinea = new("GIN");
        public static readonly CountryCode GuineaBissau = new("GNB");
        public static readonly CountryCode Guyana = new("GUY");
        public static readonly CountryCode Haiti = new("HTI");
        public static readonly CountryCode Honduras = new("HND");
        public static readonly CountryCode Hungary = new("HUN");
        public static readonly CountryCode Iceland = new("ISL");
        public static readonly CountryCode India = new("IND");
        public static readonly CountryCode Indonesia = new("IDN");
        public static readonly CountryCode Iran = new("IRN");
        public static readonly CountryCode Iraq = new("IRQ");
        public static readonly CountryCode Ireland = new("IRL");
        public static readonly CountryCode Israel = new("ISR");
        public static readonly CountryCode Italy = new("ITA");
        public static readonly CountryCode Jamaica = new("JAM");
        public static readonly CountryCode Japan = new("JPN");
        public static readonly CountryCode Jordan = new("JOR");
        public static readonly CountryCode Kazakhstan = new("KAZ");
        public static readonly CountryCode Kenya = new("KEN");
        public static readonly CountryCode Korea = new("KOR");
        public static readonly CountryCode Kuwait = new("KWT");
        public static readonly CountryCode Kyrgyzstan = new("KGZ");
        public static readonly CountryCode Laos = new("LAO");
        public static readonly CountryCode Latvia = new("LVA");
        public static readonly CountryCode Lebanon = new("LBN");
        public static readonly CountryCode Lesotho = new("LSO");
        public static readonly CountryCode Liberia = new("LBR");
        public static readonly CountryCode Libya = new("LBY");
        public static readonly CountryCode Liechtenstein = new("LIE");
        public static readonly CountryCode Lithuania = new("LTU");
        public static readonly CountryCode Luxembourg = new("LUX");
        public static readonly CountryCode Madagascar = new("MDG");
        public static readonly CountryCode Malawi = new("MWI");
        public static readonly CountryCode Malaysia = new("MYS");
        public static readonly CountryCode Maldives = new("MDV");
        public static readonly CountryCode Mali = new("MLI");
        public static readonly CountryCode Malta = new("MLT");
        public static readonly CountryCode MarshallIslands = new("MHL");
        public static readonly CountryCode Mauritania = new("MRT");
        public static readonly CountryCode Mauritius = new("MUS");
        public static readonly CountryCode Mexico = new("MEX");
        public static readonly CountryCode Micronesia = new("FSM");
        public static readonly CountryCode Moldova = new("MDA");
        public static readonly CountryCode Monaco = new("MCO");
        public static readonly CountryCode Mongolia = new("MNG");
        public static readonly CountryCode Montenegro = new("MNE");
        public static readonly CountryCode Morocco = new("MAR");
        public static readonly CountryCode Mozambique = new("MOZ");
        public static readonly CountryCode Myanmar = new("MMR");
        public static readonly CountryCode Namibia = new("NAM");
        public static readonly CountryCode Nauru = new("NRU");
        public static readonly CountryCode Nepal = new("NPL");
        public static readonly CountryCode Netherlands = new("NLD");
        public static readonly CountryCode NewZealand = new("NZL");
        public static readonly CountryCode Nicaragua = new("NIC");
        public static readonly CountryCode Niger = new("NER");
        public static readonly CountryCode Nigeria = new("NGA");
        public static readonly CountryCode NorthMacedonia = new("MKD");
        public static readonly CountryCode Norway = new("NOR");
        public static readonly CountryCode Oman = new("OMN");
        public static readonly CountryCode Pakistan = new("PAK");
        public static readonly CountryCode Palau = new("PLW");
        public static readonly CountryCode Panama = new("PAN");
        public static readonly CountryCode PapuaNewGuinea = new("PNG");
        public static readonly CountryCode Paraguay = new("PRY");
        public static readonly CountryCode Peru = new("PER");
        public static readonly CountryCode Philippines = new("PHL");
        public static readonly CountryCode Poland = new("POL");
        public static readonly CountryCode Portugal = new("PRT");
        public static readonly CountryCode Qatar = new("QAT");
        public static readonly CountryCode Romania = new("ROU");
        public static readonly CountryCode Russia = new("RUS");
        public static readonly CountryCode Rwanda = new("RWA");
        public static readonly CountryCode SaintKittsAndNevis = new("KNA");
        public static readonly CountryCode SaintLucia = new("LCA");
        public static readonly CountryCode SaintVincentAndTheGrenadines = new("VCT");
        public static readonly CountryCode Samoa = new("WSM");
        public static readonly CountryCode SanMarino = new("SMR");
        public static readonly CountryCode SaoTomeAndPrincipe = new("STP");
        public static readonly CountryCode SaudiArabia = new("SAU");
        public static readonly CountryCode Senegal = new("SEN");
        public static readonly CountryCode Serbia = new("SRB");
        public static readonly CountryCode Seychelles = new("SYC");
        public static readonly CountryCode SierraLeone = new("SLE");
        public static readonly CountryCode Singapore = new("SGP");
        public static readonly CountryCode Slovakia = new("SVK");
        public static readonly CountryCode Slovenia = new("SVN");
        public static readonly CountryCode SolomonIslands = new("SLB");
        public static readonly CountryCode Somalia = new("SOM");
        public static readonly CountryCode SouthAfrica = new("ZAF");
        public static readonly CountryCode SouthKorea = new("KOR");
        public static readonly CountryCode SouthSudan = new("SSD");
        public static readonly CountryCode Spain = new("ESP");
        public static readonly CountryCode SriLanka = new("LKA");
        public static readonly CountryCode Sudan = new("SDN");
        public static readonly CountryCode Suriname = new("SUR");
        public static readonly CountryCode Sweden = new("SWE");
        public static readonly CountryCode Switzerland = new("CHE");
        public static readonly CountryCode Syria = new("SYR");
        public static readonly CountryCode Taiwan = new("TWN");
        public static readonly CountryCode Tajikistan = new("TJK");
        public static readonly CountryCode Tanzania = new("TZA");
        public static readonly CountryCode Thailand = new("THA");
        public static readonly CountryCode TimorLeste = new("TLS");
        public static readonly CountryCode Togo = new("TGO");
        public static readonly CountryCode Tonga = new("TON");
        public static readonly CountryCode TrinidadAndTobago = new("TTO");
        public static readonly CountryCode Tunisia = new("TUN");
        public static readonly CountryCode Turkey = new("TUR");
        public static readonly CountryCode Turkmenistan = new("TKM");
        public static readonly CountryCode Tuvalu = new("TUV");
        public static readonly CountryCode Uganda = new("UGA");
        public static readonly CountryCode Ukraine = new("UKR");
        public static readonly CountryCode UnitedArabEmirates = new("ARE");
        public static readonly CountryCode UnitedKingdom = new("GBR");
        public static readonly CountryCode UnitedStates = new("USA");
        public static readonly CountryCode Uruguay = new("URY");
        public static readonly CountryCode Uzbekistan = new("UZB");
        public static readonly CountryCode Vanuatu = new("VUT");
        public static readonly CountryCode VaticanCity = new("VAT");
        public static readonly CountryCode Venezuela = new("VEN");
        public static readonly CountryCode Vietnam = new("VNM");
        public static readonly CountryCode Yemen = new("YEM");
        public static readonly CountryCode Zambia = new("ZMB");
        public static readonly CountryCode Zimbabwe = new("ZWE");

        public static IEnumerable<CountryCode> All => typeof(CountryCode).GetFields()
            .Where(f => f.FieldType == typeof(CountryCode))
            .Select(f => (CountryCode)f.GetValue(null)!);

        public static CountryCode? FromCode(string code) => All.FirstOrDefault(c => c.Code == code);
    }

}
