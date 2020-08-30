using System.Runtime.CompilerServices;

namespace Twitter.Net.Stream
{
    public class StreamRulesSummary
    {
        public int Created { get; set; }
        public int Not_Created { get; set; }
        public int Valid { get; set; }
        public int Invalid { get; set; }
    }
}