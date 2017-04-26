using System;
using Newtonsoft.Json;

namespace BTTP
{
    public class HeartRate
    {
        [JsonProperty("time")]
        public DateTime Time { get; set; }
        [JsonProperty("bpm")]
        public int BeatsPerMinute { get; set; }
    }
}
