using System;
using System.Collections;
using System.Collections.Generic;

namespace Twitter.Net
{
    public class SearchResults
    {

        public List<Tweet> Data { get; set; }
        public Metadata Meta { get; set; }
        public ExpansionData? Includes { get; set; }
        public List<Error>? Errors { get; set; }
    }
}