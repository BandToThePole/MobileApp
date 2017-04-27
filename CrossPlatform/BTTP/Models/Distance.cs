using System;
using Newtonsoft.Json;

namespace BTTP
{
    public class Distance
    {
        [JsonProperty("date")]
        public DateTime Time { get; set; }
        [JsonProperty("distance")]
        // This is in cm
        public double DistanceCM { get; set; }
        // No idea what the units are 
        [JsonProperty("speed")]
        public double Speed { get; set; }
        [JsonProperty("pace")]
        public double Pace { get; set; }
        [JsonProperty("motion")]
        public string Motion { get; set; }
    }
}
