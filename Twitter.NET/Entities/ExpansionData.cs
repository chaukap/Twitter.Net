using System.Collections.Generic;

namespace Twitter.Net
{
    public class ExpansionData
    {
        public List<User> Users { get; set; }
        public List<Tweet> Tweets { get; set; }
        public List<Media> Media { get; set; }
    }
}