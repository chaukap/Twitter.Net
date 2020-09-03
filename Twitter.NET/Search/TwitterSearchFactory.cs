using System;
using System.Collections.Generic;

namespace Twitter.Net.Search
{
    public class TwitterSearchFactory : SearchFactory<TwitterSearchFactory>
    {
        private readonly string _searchText;
        private string _nextToken;
        private int _maxResults = 10;
        private DateTime _startTime;
        private DateTime _endTime;
        private string _sinceId;
        private string _untilId;

        public TwitterSearchFactory(string searchText)
        {
            _searchText = searchText;
        }

        public TwitterSearchFactory NextToken(string token)
        {
            _nextToken = token;
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

        public override string ToString()
        {
            string search = $"?query={_searchText}&max_results={_maxResults}";

            if (_nextToken != null)
            {
                search += $"&next_token={_nextToken}";
            }

            if (_startTime != null)
            {
                search += $"&start_time={_startTime.ToUniversalTime():yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'}";
            }

            if (_endTime != null)
            {
                search += $"&start_time={_endTime.ToUniversalTime():yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'}";
            }

            if (_sinceId != null)
            {
                search += $"&since_id={_sinceId}";
            }

            if (_untilId != null)
            {
                search += $"&until_id={_untilId}";
            }

            search += AddQueryParam("tweet.fields", _tweetFields);
            search += AddQueryParam("expansions", _expansions);
            search += AddQueryParam("media.fields", _mediaFields);
            search += AddQueryParam("poll.fields", _pollFields);
            search += AddQueryParam("place.fields", _placeFields);
            search += AddQueryParam("user.fields", _userFields);

            return MapEnumNamesToAPINames(search);
        }

        private string AddQueryParam<T>(string key, List<T> values) where T : Enum
        {
            string queryParam = "";

            if (values.Count > 0)
            {
                queryParam += $"&{key}={values[0]}";
                for (int i = 1; i < values.Count; ++i)
                {
                    queryParam += $",{values[i]}";
                }
            }

            return queryParam;
        }
    }
}