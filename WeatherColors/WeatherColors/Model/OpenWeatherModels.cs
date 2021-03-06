﻿using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Weather.MobileCore.Model
{
    // <auto-generated />
    //
    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using QuickType;
    //
    //    var welcome = Welcome.FromJson(jsonString);



    //public partial class WeatherContainer
    //    {
    //        [JsonProperty("cod")]
    //        [JsonConverter(typeof(ParseStringConverter))]
    //        public long Cod { get; set; }

    //        [JsonProperty("calctime")]
    //        public double Calctime { get; set; }

    //        [JsonProperty("cnt")]
    //        public long Cnt { get; set; }

    //        [JsonProperty("list")]
    //        public List<City> CityList { get; set; }
    //    }

        //public partial class City
        //{
        //    [JsonProperty("id")]
        //    public long Id { get; set; }

        //    [JsonProperty("name")]
        //    public string Name { get; set; }

        //    [JsonProperty("coord")]
        //    public Coord Coord { get; set; }

        //    [JsonProperty("main")]
        //    public MainClass Main { get; set; }

        //    [JsonProperty("dt")]
        //    public long Dt { get; set; }

        //    [JsonProperty("wind")]
        //    public Wind Wind { get; set; }

        //    [JsonProperty("rain", NullValueHandling = NullValueHandling.Ignore)]
        //    public Rain Rain { get; set; }

        //    [JsonProperty("clouds")]
        //    public Clouds Clouds { get; set; }

        //    [JsonProperty("weather")]
        //    public List<Weather> Weather { get; set; }
        //}

        public partial class Clouds
        {
            [JsonProperty("all")]
            public long All { get; set; }
        }

        public partial class Coord
        {
            [JsonProperty("lon")]
            public double Lon { get; set; }

            [JsonProperty("lat")]
            public double Lat { get; set; }
        }

        public partial class MainClass
        {
            [JsonProperty("temp")]
            public double Temp { get; set; }

            [JsonProperty("temp_min")]
            public double TempMin { get; set; }

            [JsonProperty("temp_max")]
            public double TempMax { get; set; }

            [JsonProperty("pressure")]
            public double Pressure { get; set; }

            [JsonProperty("sea_level", NullValueHandling = NullValueHandling.Ignore)]
            public double? SeaLevel { get; set; }

            [JsonProperty("grnd_level", NullValueHandling = NullValueHandling.Ignore)]
            public double? GrndLevel { get; set; }

            [JsonProperty("humidity")]
            public long Humidity { get; set; }
        }

        public partial class Rain
        {
            [JsonProperty("3h")]
            public double The3H { get; set; }
        }

        public partial class Weather
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("main")]
            public MainEnum Main { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("icon")]
            public string Icon { get; set; }
        }

        public partial class Wind
        {
            [JsonProperty("speed")]
            public double Speed { get; set; }

            [JsonProperty("deg")]
            public double Deg { get; set; }

            [JsonProperty("var_beg", NullValueHandling = NullValueHandling.Ignore)]
            public long? VarBeg { get; set; }

            [JsonProperty("var_end", NullValueHandling = NullValueHandling.Ignore)]
            public long? VarEnd { get; set; }
        }

        public enum MainEnum { Clouds, Rain };

        public partial class Welcome
        {
            public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, QuickType.Converter.Settings);
        }

        public static class Serialize
        {
            public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
        }

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
            {
                MainEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }

        internal class ParseStringConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                long l;
                if (Int64.TryParse(value, out l))
                {
                    return l;
                }
                throw new Exception("Cannot unmarshal type long");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (long)untypedValue;
                serializer.Serialize(writer, value.ToString());
                return;
            }

            public static readonly ParseStringConverter Singleton = new ParseStringConverter();
        }

        internal class MainEnumConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(MainEnum) || t == typeof(MainEnum?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "Clouds":
                        return MainEnum.Clouds;
                    case "Rain":
                        return MainEnum.Rain;
                }
                throw new Exception("Cannot unmarshal type MainEnum");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (MainEnum)untypedValue;
                switch (value)
                {
                    case MainEnum.Clouds:
                        serializer.Serialize(writer, "Clouds");
                        return;
                    case MainEnum.Rain:
                        serializer.Serialize(writer, "Rain");
                        return;
                }
                throw new Exception("Cannot marshal type MainEnum");
            }

            public static readonly MainEnumConverter Singleton = new MainEnumConverter();
        }
    }

