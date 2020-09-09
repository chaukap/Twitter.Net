using System;

namespace Twitter.Net.Stream
{
    public class StreamRulesMetadata
    {
        public DateTime Sent { get; set; }
        public StreamRulesSummary Summary { get; set; }
    }
}