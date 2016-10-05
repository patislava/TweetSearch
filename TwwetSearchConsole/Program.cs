using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using TweetSearchWPF;
using TweetSharp;

namespace TweetSearchConsole
{
    internal class Program
    {
        private static void Main()
        {
            TweetSearch tweetSearch = new TweetSearch(ConfigurationManager.AppSettings[0], ConfigurationManager.AppSettings[1],
                ConfigurationManager.AppSettings[2], ConfigurationManager.AppSettings[3]);
            IInputValidator validator = new InputValidator();

            while (true)
            {
                Console.Write("Enter hashtag: ");

                string inputHashtag = Console.ReadLine();

                if (validator.Validate(inputHashtag))
                {
                    IEnumerable<TwitterStatus> response = tweetSearch.SearchTweets(inputHashtag);
                    
                    if (response.Any())
                    {
                        foreach (var r in response)
                            Console.WriteLine(r.User.Name + ":\n" + r.Text + "\n" + new string('-', 94) + "\n");
                    }
                    else
                    {
                        Console.WriteLine("No tweets found with: " + inputHashtag);
                    }
                }
                else
                    Console.WriteLine("Hashtag should start with # symbol and contain at least one character.");
            }
        }
    }
}
