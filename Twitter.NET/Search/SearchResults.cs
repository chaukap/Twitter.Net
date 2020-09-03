using System;
using System.Collections.Generic;
using System.Linq;

namespace Twitter.Net.Search
{
    public class SearchResults
    {
        public List<Tweet> Data { get; set; }
        public Metadata Meta { get; set; }
        public List<string> GetTextList()
        {
            var result = new List<string>();
            foreach(var tweet in Data)
            {
                result.Add(tweet.Text);
            }
            return result;
        }
        public List<string> GetTextList(Func<Tweet, bool> comparator)
        {
            var result = new List<string>();
            var selectedTweets = Data.Where(comparator).ToList();

            foreach (var tweet in selectedTweets)
            {
                result.Add(tweet.Text);
            }
            return result;
        }
    }
}