using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Twitter.Net.Stream
{
    internal class AddStreamRules
    {
        [JsonPropertyName("add")]
        public List<StreamRule> Rules { get; set; }
        public AddStreamRules(List<StreamRule> rules)
        {
            Rules = rules;
        }
    }
}
