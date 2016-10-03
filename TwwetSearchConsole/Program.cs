using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetSearchCore;

namespace TweetSearchConsole
{
    class Program
    {
        static void Main()
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
                    var response = tweetSearch.SearchTweets(inputHashtag);
                    
                    if (response.Count() > 0)
                    {
                        foreach (var r in response)
                            Console.WriteLine(r.User + ":\n" + r.Text + "\n=======================================================\n");
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
