using System.IO;
using System.Windows;

namespace NapierBankMessaging.Models
{
    
    public class SmS
    {

        public string Message { get; set; }
        public string PhoneNumber { get; set; }

        public SmS()
        { 
            Message = string.Empty;
            PhoneNumber = string.Empty;
        }

        public void FindPhoneNumber(string body)
        {
            string[] lines = body.Split("\n");
            PhoneNumber = lines[0];
            PhoneNumber = PhoneNumber.Replace("\r", "");
        }

        public bool ValidPhoneNumber(string number)
        {
            if (number.Length == 11 && number[0] == '0' && number[1] == '7')
            {
                foreach (char digit in number)
                {
                    if (digit > '0' || digit < '9')
                    {
                        MessageBox.Show( "Valid Phone Number: " + number);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ValidMessage(string body)
        {
            int MaxLength = 140;
            string[] sentences = body.Split("\n");
            if (sentences[1].Length > MaxLength)
            {
                MessageBox.Show("Too many Characters\n Limit 140 Characters");
                return false;
            }
            return true;
        }
        public string Abbreviations(string message)
        {
            string[] sentences = message.Split("\n");
            string[] words = sentences[1].Split(" ");
            string EditedMessage = string.Empty;
            for(int i = 0; i < words.Length; i++)
            {
                EditedMessage += words[i] + " ";
                string FileName = "textwords.csv";
                string[] Lines = File.ReadAllLines(FileName);

                foreach (string line in Lines)
                {
                    string[] columns = line.Split(",");
                    string abb = columns[0];
                    string abbFull = columns[1];

                    if (string.Equals(abb, words[i]))
                    {
                        EditedMessage += "<" + abbFull + "> ";
                    }
                } 
            }
            return EditedMessage;
        }
    }
}
