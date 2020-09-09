using System.Collections.Generic;
using static Twitter.Net.Fields;

namespace Twitter.Net.Stream
{
    public class TwitterStreamFactory : SearchFactory<TwitterStreamFactory>
    {
        public override string ToString()
        {
            var tweetFields = AddQueryParam("tweet.fields", _tweetFields);
            var expansions = AddQueryParam("expansions", _expansions);
            var mediaFields = AddQueryParam("media.fields", _mediaFields);
            var pollFields = AddQueryParam("poll.fields", _pollFields);
            var placeFields = AddQueryParam("place.fields", _placeFields);
            var userFields = AddQueryParam("user.fields", _userFields);

            var fullString = "?";
            if(_tweetFields.Count > 0)
            {
                fullString += tweetFields;
            }
            if (_expansions.Count > 0)
            {
                fullString += fullString.Length > 1 ? $"&{expansions}" : expansions;
            }
            if (_mediaFields.Count > 0)
            {
                fullString += fullString.Length > 1 ? $"&{mediaFields}" : mediaFields;
            }
            if (_pollFields.Count > 0)
            {
                fullString += fullString.Length > 1 ? $"&{pollFields}" : pollFields;
            }
            if (_placeFields.Count > 0)
            {
                fullString += fullString.Length > 1 ? $"&{placeFields}" : placeFields;
            }
            if (_userFields.Count > 0)
            {
                fullString += fullString.Length > 1 ? $"&{userFields}" : userFields;
            }

            if(fullString.Length == 1)
            {
                return "";
            }

            return MapEnumNamesToAPINames(fullString);
        }

        private string AddQueryParam<T>(string key, List<T> values) where T : System.Enum
        {
            string queryParam = "";

            if (values.Count > 0)
            {
                queryParam += $"{key}={values[0]}";
                for (int i = 1; i < values.Count; ++i)
                {
                    queryParam += $",{values[i]}";
                }
            }

            return queryParam;
        }
    }
}