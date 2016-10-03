using System;
using System.Collections.Generic;
using System.Text;

namespace TweetSearchCore
{
    public interface ITweetSearch
    {
        IEnumerable<TweetSharp.TwitterStatus> SearchTweets(string hashTag);
    }
}
