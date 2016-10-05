using System.Collections.Generic;

namespace TweetSearchWPF
{
    public interface ITweetSearch
    {
        IEnumerable<TweetSharp.TwitterStatus> SearchTweets(string hashTag);
    }
}
