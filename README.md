# Twitter.Net
A .NET wrapper for the [Twitter API v2](https://developer.twitter.com/en/docs/twitter-api/early-access).

I'm actively developing this library but it's far from complete. Namespaces and design patterns will inevibly change, so stay tuned!

## Examples
### Search for tweets
* Use a factory to build the search query:
```
TwitterSearchFactory factory = new TwitterSearchFactory("Chihuahua OR Poodle")
                    .MaxResults(25)
                    .AddTweetField(Fields.TweetField.attachments)
                    .AddTweetField(Fields.TweetField.text)
                    .AddExpansion(Fields.Expansion.mentions_username)
                    .AddMediaField(Fields.MediaField.url)
                    .AddPollField(Fields.PollField.voting_status)
                    .AddPlaceField(Fields.PlaceField.place_type)
                    .AddUserField(Fields.UserField.protected_user);
```
* Create a twitter scraper and search using the factory
```
var results = await scraper.Search(factory);
```

### Create a filtered stream
* Use a factory to select the fields to return with the tweets:
```
var factory = new TwitterFilteredStreamFactory();
factory.AddTweetField(Fields.TweetField.attachments)
    .AddTweetField(Fields.TweetField.text)
    .AddExpansion(Fields.Expansion.mentions_username)
    .AddMediaField(Fields.MediaField.url)
    .AddPollField(Fields.PollField.voting_status)
    .AddPlaceField(Fields.PlaceField.place_type)
    .AddUserField(Fields.UserField.protected_user);
```
* Add rules to the stream:
```
await scraper.FilteredStream.AddRules(new List<StreamRule>()
{
    new StreamRule
    {
        Value = "Corgis",
        Tag = "Find those Corgis!"
    },
    new StreamRule
    {
        Value = "Great Danes",
        Tag = "Like Corgis but bigger!"
    }
});
```
* Start the stream:
```
var scraper = new TwitterScraper("<Bearer Token>");
TwitterStream stream = await scraper.FilteredStream.Stream(factory);
```
* Recieve tweets in real time!
```
stream.NextTweet();
```
