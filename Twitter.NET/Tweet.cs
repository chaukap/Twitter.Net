using System;
using System.Collections.Generic;
using System.Text;

namespace Twitter.Net
{
    public class Tweet
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public PublicMetrics Public_Metrics { get; set;}

    }
}
