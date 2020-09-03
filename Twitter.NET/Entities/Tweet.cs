using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Twitter.Net
{
    public class Tweet
    {
        public string Id { get; set; }
        public string Text { get; set; }
        [JsonPropertyName("public_metrics")]
        public PublicMetrics PublicMetrics { get; set;}

    }
}
