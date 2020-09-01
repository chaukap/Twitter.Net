using System.Collections.Generic;

namespace Twitter.Net.Stream
{
    public class TwitterFilteredStreamFactory
    {
        public enum TweetField
        {
            attachments,
            author_id,
            context_annotations,
            conversation_id,
            created_at, entities,
            geo,
            id,
            in_reply_to_user_id,
            lang,
            possibly_sensitive,
            public_metrics,
            referenced_tweets,
            source,
            text,
            withheld
        }

        public enum Expansion
        {
            poll_ids,
            media_keys,
            author_id,
            place_id,
            in_reply_to_user_id,
            referenced_tweets,
            mentions_username,
            referenced_tweets_author_id
        }

        public enum MediaField
        {
            duration_ms,
            height,
            media_key,
            preview_image_url,
            public_metrics,
            type,
            url,
            width
        }

        public enum PollField
        {
            duration_minutes,
            end_datetime,
            id,
            options,
            voting_status
        }

        public enum PlaceField
        {
            contained_within,
            country,
            country_code,
            full_name,
            geo,
            id,
            name,
            place_type
        }

        public enum UserField
        {
            created_at,
            description,
            entities,
            id,
            location,
            name,
            pinned_tweet_id,
            profile_image_url,
            protected_user,
            public_metrics,
            url,
            username,
            verified,
            withheld
        }

        private List<TweetField> _tweetFields;
        private List<Expansion> _expansions;
        private List<MediaField> _mediaFields;
        private List<PollField> _pollFields;
        private List<PlaceField> _placeFields;
        private List<UserField> _userFields;

        public TwitterFilteredStreamFactory()
        {
            _tweetFields = new List<TweetField>();
            _expansions = new List<Expansion>();
            _mediaFields = new List<MediaField>();
            _pollFields = new List<PollField>();
            _placeFields = new List<PlaceField>();
            _userFields = new List<UserField>();
        }

        public TwitterFilteredStreamFactory AddTweetField(TweetField tweetField)
        {
            _tweetFields.Add(tweetField);
            return this;
        }
        public TwitterFilteredStreamFactory AddExpansion(Expansion expansion)
        {
            _expansions.Add(expansion);
            return this;
        }
        public TwitterFilteredStreamFactory AddMediaField(MediaField mediaField)
        {
            _mediaFields.Add(mediaField);
            return this;
        }
        public TwitterFilteredStreamFactory AddPollField(PollField pollField)
        {
            _pollFields.Add(pollField);
            return this;
        }
        public TwitterFilteredStreamFactory AddPlaceField(PlaceField placeField)
        {
            _placeFields.Add(placeField);
            return this;
        }
        public TwitterFilteredStreamFactory AddUserField(UserField userField)
        {
            _userFields.Add(userField);
            return this;
        }

        public string ProduceSearchString()
        {
            var tweetFields = AddQueryParam("tweet.fields", _tweetFields);
            var expansions = AddQueryParam("expansions", _expansions);
            var mediaFields = AddQueryParam("media.fields", _mediaFields);
            var pollFields = AddQueryParam("poll.fields", _pollFields);
            var placeFields = AddQueryParam("place.fields", _placeFields);
            var userFields = AddQueryParam("user.fields", _userFields);

            var fullString = "?";
            fullString += tweetFields;
            fullString += fullString.Length > 1 ? $"&{expansions}" : expansions;
            fullString += fullString.Length > 1 ? $"&{mediaFields}" : mediaFields;
            fullString += fullString.Length > 1 ? $"&{pollFields}" : pollFields;
            fullString += fullString.Length > 1 ? $"&{placeFields}" : placeFields;
            fullString += fullString.Length > 1 ? $"&{userFields}" : userFields;

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

        private string MapEnumNamesToAPINames(string query)
        {
            return query.Replace("poll_ids", "attachments.poll_ids")
                .Replace("media_keys", "attachments.media_keys")
                .Replace("place_id", "geo.place_id")
                .Replace("referenced_tweets", "referenced_tweets.id")
                .Replace("mentions_username", "entities.mentions")
                .Replace("referenced_tweets_author_id", "referenced_tweets.id.author_id")
                .Replace("protected_user", "protected");
        }
    }
}