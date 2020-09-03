# Twitter.Net
A .NET wrapper for the Twitter API v2.

I'm actively developing this library but it's far from complete. Namespaces and design patterns will inevibly change, so stay tuned!

## Examples
### Search for tweets
* Use a factory to build the search query:
```
TwitterSearchFactory factory = new TwitterSearchFactory("bitcoin OR crypto OR cryptocurrency")
                    .MaxResults(25)
                    .Include(new List<TwitterSearchFactory.TweetFields>() {
                        TwitterSearchFactory.TweetFields.id,
                        TwitterSearchFactory.TweetFields.public_metrics,
                        TwitterSearchFactory.TweetFields.text
                    });
```
* Create a twitter scraper and Search using the factory
```
var scraper = new TwitterScraper("<Bearer Token>");
var results = await scraper.Search(factory);
```

### Create a filtered stream
* Use a factory to select the fields to return with the tweets: (I know, I need to consolidate the namespaces)
```
var factory = new TwitterFilteredStreamFactory();
factory.AddTweetField(TwitterFilteredStreamFactory.TweetField.attachments)
    .AddTweetField(TwitterFilteredStreamFactory.TweetField.text)
    .AddExpansion(TwitterFilteredStreamFactory.Expansion.mentions_username)
    .AddMediaField(TwitterFilteredStreamFactory.MediaField.url)
    .AddPollField(TwitterFilteredStreamFactory.PollField.voting_status)
    .AddPlaceField(TwitterFilteredStreamFactory.PlaceField.place_type)
    .AddUserField(TwitterFilteredStreamFactory.UserField.protected_user);
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
System.IO.Stream stream = await scraper.FilteredStream.Stream(factory);
```
* Then read the stream like any other input!
```
stream.ReadLine();
```
