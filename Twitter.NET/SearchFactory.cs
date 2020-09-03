using System;
using System.Collections.Generic;
using System.Text;
using static Twitter.Net.Fields;

namespace Twitter.Net
{
    /// <summary>
    /// Defines the shared functionality of all searches.
    /// </summary>
    public abstract class SearchFactory<T> where T : SearchFactory<T> // I know, I can't believe this works either
    {
        protected List<TweetField> _tweetFields = new List<TweetField>();
        protected List<Expansion> _expansions = new List<Expansion>();
        protected List<MediaField> _mediaFields = new List<MediaField>();
        protected List<PollField> _pollFields = new List<PollField>();
        protected List<PlaceField> _placeFields = new List<PlaceField>();
        protected List<UserField> _userFields = new List<UserField>();

        public T AddTweetField(TweetField tweetField)
        {
            _tweetFields.Add(tweetField);
            return (T) this;
        }
        public T AddExpansion(Expansion expansion)
        {
            _expansions.Add(expansion);
            return (T) this;
        }
        public T AddMediaField(MediaField mediaField)
        {
            _mediaFields.Add(mediaField);
            return (T) this;
        }
        public T AddPollField(PollField pollField)
        {
            _pollFields.Add(pollField);
            return (T)this;
        }
        public T AddPlaceField(PlaceField placeField)
        {
            _placeFields.Add(placeField);
            return (T)this;
        }
        public T AddUserField(UserField userField)
        {
            _userFields.Add(userField);
            return (T) this;
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
