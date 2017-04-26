using System;
using Newtonsoft.Json;

namespace BTTP
{
    public class Location
    {
        [JsonProperty("time")]
        public DateTime Time { get; set; }
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("long")]
        public double Longitude { get; set; }
    }
}
