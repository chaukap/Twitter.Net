using System.Collections.Generic;

namespace Twitter.Net.Stream
{
    public class CurrentStreamRules
    {
        public List<CurrentStreamRule> Data { get; set; }
        public StreamRulesMetadata Meta { get; set; }
    }
}