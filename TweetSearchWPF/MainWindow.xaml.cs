using System.Collections.Generic;
using System.Windows;
using System.Configuration;
using System.Linq;
using System.ComponentModel;
using TweetSharp;

namespace TweetSearchWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TweetSearch tweetSearch = new TweetSearch(ConfigurationManager.AppSettings[0], ConfigurationManager.AppSettings[1],
            ConfigurationManager.AppSettings[2], ConfigurationManager.AppSettings[3]);
        private IInputValidator validator = new InputValidator();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonSearch(object sender, RoutedEventArgs e)
        {
            labelError.Visibility = Visibility.Hidden;

            if (validator.Validate(inputHashtag.Text))
            {
                textBox.Clear();

                IEnumerable<TwitterStatus> response = tweetSearch.SearchTweets(inputHashtag.Text);

                if (response.Any())
                {
                    foreach (var tweet in response)
                        textBox.AppendText(tweet.User.Name + ":\n" + tweet.Text + "\n" + new string('-', 94) + "\n");
                }
                else
                {
                    textBox.AppendText("No tweets found with: " + inputHashtag.Text);
                }
            }
            else
            {
                labelError.Visibility = Visibility.Visible;
            }
        }
    }

   
}

