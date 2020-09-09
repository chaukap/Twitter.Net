using System;

namespace Twitter.Net.Stream
{
    public class DeletedStreamRulesMetadata
    {
        public DateTime Sent { get; set; }
        public DeletedRulesSummary Summary { get; set; }
    }
}