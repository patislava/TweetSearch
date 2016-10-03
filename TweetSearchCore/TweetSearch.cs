using System.Collections.Generic;
using System.Net;
using TweetSharp;
using TweetSharp.Model;

namespace TweetSearchCore
{
    public class TweetSearch : ITweetSearch
    {
        private TwitterService twitterService;

        public TweetSearch(string consumerKey, string consumerSecret, string accessToken, string accessSecret)
        {
            twitterService = new TwitterService(consumerKey, consumerSecret);
            twitterService.AuthenticateWith(accessToken, accessSecret);
        }

        public IEnumerable<TwitterStatus> SearchTweets(string hashTag)
        {
            TwitterSearchResult tweetsToSearch = null;

            try
            {
                tweetsToSearch = twitterService.Search(new SearchOptions { Q = hashTag, Resulttype = TwitterSearchResultType.Popular, });
            }
            catch (WebException ex)
            {
                throw new WebException(ex.Message);
            }

            if (tweetsToSearch == null)
            {
                return null;
            }

            return tweetsToSearch.Statuses;
        }
    }
}
