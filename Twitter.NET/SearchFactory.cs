using System;
using System.Collections.Generic;
using System.Text;
using static Twitter.Net.Fields;

namespace Twitter.Net
{
    /// <summary>
    /// Defines the shared functionality of all searches.
    /// </summary>
    public abstract class SearchFactory
    {
        protected List<TweetField> _tweetFields = new List<TweetField>();
        protected List<Expansion> _expansions = new List<Expansion>();
        protected List<MediaField> _mediaFields = new List<MediaField>();
        protected List<PollField> _pollFields = new List<PollField>();
        protected List<PlaceField> _placeFields = new List<PlaceField>();
        protected List<UserField> _userFields = new List<UserField>();

        public SearchFactory AddTweetField(TweetField tweetField)
        {
            _tweetFields.Add(tweetField);
            return this;
        }
        public SearchFactory AddExpansion(Expansion expansion)
        {
            _expansions.Add(expansion);
            return this;
        }
        public SearchFactory AddMediaField(MediaField mediaField)
        {
            _mediaFields.Add(mediaField);
            return this;
        }
        public SearchFactory AddPollField(PollField pollField)
        {
            _pollFields.Add(pollField);
            return this;
        }
        public SearchFactory AddPlaceField(PlaceField placeField)
        {
            _placeFields.Add(placeField);
            return this;
        }
        public SearchFactory AddUserField(UserField userField)
        {
            _userFields.Add(userField);
            return this;
        }

        public abstract override string ToString();

        protected string MapEnumNamesToAPINames(string query)
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
