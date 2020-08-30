using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace Twitter.Net.Search
{
    public class TwitterSearchFactory
    {
        public enum TweetFields
        {
            id,
            text,
            public_metrics
        }

        private string _searchText;
        private List<TweetFields> _includedFields;
        private string _token;
        private int _maxResults = 10;
        private DateTime _startTime;
        private DateTime _endTime;
        private string _sinceId;
        private string _untilId;

        public TwitterSearchFactory(string searchText)
        {
            _searchText = searchText;
        }

        public TwitterSearchFactory Include(List<TweetFields> fields)
        {
            _includedFields = fields;
            return this;
        }

        public TwitterSearchFactory Token(string token)
        {
            _token = token;
            return this;
        }

        /// <summary>
        /// Set the maximum results to return. Default is 10.
        /// </summary>
        /// <param name="results">
        /// A value between 10 and 100.
        /// </param>
        /// <returns></returns>
        public TwitterSearchFactory MaxResults(int results)
        {
            _maxResults = (results <= 100 && results >= 10 ? results : 10);
            return this;
        }

        public TwitterSearchFactory StartTime(DateTime time)
        {
            _startTime = time;
            return this;
        }

        public TwitterSearchFactory EndTime(DateTime time)
        {
            _endTime = time;
            return this;
        }

        public TwitterSearchFactory SinceId(string id)
        {
            _sinceId = id;
            return this;
        }

        public TwitterSearchFactory UntilId(string id)
        {
            _untilId = id;
            return this;
        }

        public string ProduceSearchString()
        {
            string search = $"query={_searchText}&max_results={_maxResults}";

            if(_token != null)
            {
                search += $"&next_token={_token}";
            }

            if (_startTime != null)
            {
                search += $"&start_time={_startTime.ToUniversalTime():yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'} ";
            }

            if (_endTime != null)
            {
                search += $"&start_time={_endTime.ToUniversalTime():yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'} ";
            }

            if (_sinceId != null)
            {
                search += $"&since_id={_sinceId}";
            }

            if (_untilId != null)
            {
                search += $"&until_id={_untilId}";
            }

            if (_includedFields.Count > 0)
            {
                search += $"&tweet.fields={_includedFields[0]}";
                for (var i = 1; i < _includedFields.Count; ++i)
                {
                    search += $",{_includedFields[i]}";
                }
            }

            return search;
        }
    }
}