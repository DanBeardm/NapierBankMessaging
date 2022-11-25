using System;
using System.IO;
using System.Windows;

namespace NapierBankMessaging.Models
{
    public class Email
    {
        public string Address { get; set; }
        public string Subject { get; set; }
        public string MessageText { get; set; }

        public Email()
        {
            Address = string.Empty;
            Subject = string.Empty;
            MessageText = string.Empty;
        }

        public bool FindInfo(string body)
        {
            string[] Lines = body.Split("\n");
            Address = Lines[0].Replace("\r", "");
            int NumberLines = Lines.Length;
            string NextLine = string.Empty;
            if (ValidAddress())
            {
                Subject = Lines[1].Replace("\r", "");
                if (ValidSubject())
                { 
                    for( int i = 2; i < NumberLines; i++)
                    {
                        MessageText += Lines[i] + "\n";
                    }
                    if (ValidMessageText())
                    {
                            MessageText = Quarantine();
                            return true;
                    } 
                }
            }
            return false;
        }
        public bool ValidAddress()
        {
            for (int i = 1; i < Address.Length; i++)
            {
                if (Address[i] == '@')
                {
                    return true;
                }
            }
            MessageBox.Show("Invalid Address");
            return false;
        }

        public bool ValidSubject()
        {
            if (Subject.Length > 20)
            {
                MessageBox.Show("Subject Header has a 20 character limit");
                return false;
            }
            return true;
        }

        public bool ValidMessageText()
        {
            if (MessageText.Length > 1028)
            {
                MessageBox.Show("Max characters is 1028");
                return false;
            }
            return true;
        }

        public string Quarantine()
        {
            string[] words = MessageText.Split(" ");
            string EditedText = string.Empty;
            
            for (int i = 0; i < words.Length; i++)
            {
                
                string url = words[i];
                if (UrlChecker(url))
                {
                    EditedText += "<URL QUARANTINED> ";
                }else
                {
                    EditedText += words[i] + " ";
                }
            }

            return EditedText;
        }

        public bool UrlChecker(string url)
        {
            bool tryCreateResult = Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult);
            if (tryCreateResult == true && uriResult != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
