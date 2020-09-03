using System;
using System.Collections.Generic;
using System.Text;

namespace Twitter.Net
{
    /// <summary>
    /// All fields that can be returned with tweets
    /// </summary>
    public static class Fields
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

        /// <summary>
        /// User-related data that can be returned with tweets
        /// </summary>
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
    }
}
