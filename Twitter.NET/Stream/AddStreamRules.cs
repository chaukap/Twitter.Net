using System;
using System.Collections.Generic;
using System.Text;

namespace Twitter.Net.Stream
{
    internal class AddStreamRules
    {
        public List<StreamRule> Add { get; set; }
        public AddStreamRules(List<StreamRule> rules)
        {
            Add = rules;
        }
    }
}
