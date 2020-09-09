using System.Collections.Generic;

namespace Twitter.Net.Stream
{
    internal class DeleteStreamRules
    {
        public DeleteRuleTagList Delete { get; set; }
        public DeleteStreamRules(List<string> values)
        {
            Delete = new DeleteRuleTagList
            {
                Values = values
            };
        }
    }
}