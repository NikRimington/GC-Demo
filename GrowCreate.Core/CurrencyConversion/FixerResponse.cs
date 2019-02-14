using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GrowCreate.Core.CurrencyConversion
{
    public class FixerResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("timestamp")]
        public long TimeStamp { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("rates")]
        public Dictionary<string, decimal> Rates { get; set; }
    }    
}
