using System.Collections.Generic;
using System.Net;
using TweetSharp;

namespace TweetSearchWPF
{
    public class TweetSearch : ITweetSearch
    {
        private readonly TwitterService _twitterService;

        public TweetSearch(string consumerKey, string consumerSecret, string accessToken, string accessSecret)
        {
            _twitterService = new TwitterService(consumerKey, consumerSecret);
            _twitterService.AuthenticateWith(accessToken, accessSecret);
        }

        public IEnumerable<TwitterStatus> SearchTweets(string hashTag)
        {
            TwitterSearchResult tweetsToSearch;

            try
            {
                tweetsToSearch = _twitterService.Search(new SearchOptions { Q = hashTag, Resulttype = TwitterSearchResultType.Popular, });
            }
            catch (WebException ex)
            {
                throw new WebException(ex.Message);
            }

            return tweetsToSearch?.Statuses;
        }
    }
}
