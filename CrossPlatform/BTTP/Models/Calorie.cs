using System;
using Newtonsoft.Json;

namespace BTTP
{
    public class Calorie
    {
        [JsonProperty("kcalcount")]
        public int Count { get; set; }
        [JsonProperty("time")]
        public DateTime Time;
    }
}
