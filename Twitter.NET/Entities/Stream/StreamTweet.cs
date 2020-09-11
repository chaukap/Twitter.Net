using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Twitter.Net.Entities.Stream
{
    public class StreamTweet
    {
        public Tweet Data { get; set; }
        [JsonPropertyName("matching_rules")]
        public List<MatchedRule> MatchingRules { get; set; }
    }
}
