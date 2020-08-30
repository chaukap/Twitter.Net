using System.Runtime.CompilerServices;

namespace Twitter.Net
{
    public class Metadata
    {
        public string Newest_Id { get; set; }
        public string Oldest_Id { get; set; }
        public int Result_Count { get; set; }
        public string Next_Token { get; set; }
    }
}