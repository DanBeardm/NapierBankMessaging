using NapierBankMessaging.Output;
using System.IO;
using System.Windows;

namespace NapierBankMessaging.Models
{
    public class Tweet
    {
        public string TwitterID { get; set; }
        public string TweetText { get; set;}

        public Tweet()
        {
            TwitterID = string.Empty;
            TweetText = string.Empty;
        }

        public bool GetInfo(string body)
        {
            string[] Lines = body.Split("\n");
            TwitterID = Lines[0].Replace("\r", "");
            if (ValidTwitterID())
            {
                TweetText = Lines[1];
                if (ValidTweet())
                {
                    TweetText = Abbreviations(TweetText);
                    MessageBox.Show(TweetText);
                    FindMentions();
                    FindTrends();
                    return true;
                }
            }
            return false;
        }

        public bool ValidTwitterID()
        {
            if (TwitterID[0] == '@' && TwitterID.Length < 15)
            {
                return true;
            }
            MessageBox.Show("Twitter ID must start with @ and a max of 15 characters");
            return false;
        }

        public bool ValidTweet()
        {
            if (TweetText.Length > 140)
            {
                MessageBox.Show("Max 140 characters for tweet");
                return false;
            }
            return true;
        }

        public void FindMentions()
        {
            string[] words = TweetText.Split(" ");
            
            for (int i = 0; i <  words.Length-1; i++)
            {
                string mention = words[i];
                if (mention[0] == '@')
                {
                    MentionList save = new MentionList();
                    if (!save.ToList(mention))
                    {
                        MessageBox.Show("error while saving\n" + save.ErrorCode);
                    }
                    else
                    {
                        MessageBox.Show("Mention Saved");
                    }
                }      
            }
        }

        public void FindTrends()
        {
            string[] words = TweetText.Split(" ");

            for (int i = 0; i < words.Length - 1; i++)
            {
                string trend = words[i];
                if (trend[0] == '#')
                {
                    TrendingList save = new TrendingList();
                    if (!save.ToList(trend))
                    {
                        MessageBox.Show("error while saving\n" + save.ErrorCode);
                    }
                    else
                    {
                        MessageBox.Show("Trend Saved");
                    }
                }
            }
        }
        public string Abbreviations(string message)
        {
            string[] words = message.Split(" ");
            string EditedTweet = string.Empty;

            for (int i = 0; i < words.Length; i++)
            {
                EditedTweet += words[i] + " ";
                string FileName = "textwords.csv";
                string[] Lines = File.ReadAllLines(FileName);

                foreach (string line in Lines)
                {
                    string[] columns = line.Split(",");
                    string abb = columns[0];
                    string abbFull = columns[1];

                    if (string.Equals(abb, words[i]))
                    {
                        EditedTweet += "<" + abbFull + "> ";
                    }
                }
            }
            return EditedTweet;
        }
    }
}
