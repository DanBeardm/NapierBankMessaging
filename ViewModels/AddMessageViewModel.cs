using NapierBankMessaging.Commands;
using NapierBankMessaging.Models;
using System;
using System.Windows;
using System.Windows.Input;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using NapierBankMessaging.Output;

namespace NapierBankMessaging.ViewModels
{
    public class AddMessageViewModel : BaseViewModel
    {
        public string MessageIDTextBlock { get; private set; }
        public string MessageBodyTextBlock { get; private set; }

        public string MessageIDTextBox { get; set; }
        public string MessageBodyTextBox { get; set; }

        public string AddMessageButtonText { get; private set; }
        public ICommand AddMessageCommand { get; private set; }

        public AddMessageViewModel()
        {
            MessageIDTextBlock = "Message ID";
            MessageBodyTextBlock = "Message Body";

            MessageIDTextBox = string.Empty;
            MessageBodyTextBox = string.Empty;

            AddMessageButtonText = "Process Message";
            AddMessageCommand = new RelayCommand(AddButtonClick);
        }

        private void AddButtonClick()
        {
            //Test Values
            //SmS
            //MessageIDTextBox = "S000000001";
            //MessageBodyTextBox = "17700 900118\nThis is an sms text message that handles abbriviations like BRB and LMAO";
            
            //Email
            //MessageIDTextBox = "E000000001";
            //MessageBodyTextBox = "address@test.com\nSubject Header\nBody of text after the subject header http:\\\\www.anywhere.com needs to be quarantined\nNew line with more text http:\\\\www.anywhere.com \nNew line with more text http:\\\\www.anywhere.com";

            //SIR
            //MessageIDTextBox = "E000000002";
            //MessageBodyTextBox = "address@test.com\nSIR 16\\11\\2022\n99-99-99\nTheft";
            
            //Tweet
            //MessageIDTextBox = "T000000001";
            //MessageBodyTextBox = "@TestID\nTesting tweet shout out @JohnSmith and @SteveSmith #RealOnes LMAO #Blessed";

            if(string.IsNullOrWhiteSpace(MessageIDTextBox) || string.IsNullOrWhiteSpace(MessageBodyTextBox))
            {
                MessageBox.Show("Please enter all values");
                return;
            }
            if (MessageIDTextBox.Length == 10)
            {
                //SmS Message
                if (Equals('S', MessageIDTextBox[0]))
                {
                    SmS sms = new SmS();
                
                    sms.FindPhoneNumber(MessageBodyTextBox);
                    if (sms.ValidPhoneNumber(sms.PhoneNumber))
                    {
                        if (sms.ValidMessage(MessageBodyTextBox))
                        {
                            sms.Message = sms.Abbreviations(MessageBodyTextBox);
                            serialise(sms, "sms.json");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Phone Number!" +sms.PhoneNumber + "\nNumber must be 11 characters long\nbegin with 0 and second charcter is 7");
                    }
                }
                //Email Message
                if (Equals('E', MessageIDTextBox[0]))
                {
                    Email email = new Email();

                    if (email.FindInfo(MessageBodyTextBox))
                    {
                        if (email.Subject[0] == 'S' && email.Subject[1] == 'I' && email.Subject[2] == 'R')
                        {
                            SignificantInjuryReport sir = new SignificantInjuryReport();
                            MessageBox.Show(email.MessageText);
                            sir.FindSortCode(email.MessageText);
                        }
                        serialise(email, "email.json");
                    }
                }
                //Tweet Message
                if (Equals('T', MessageIDTextBox[0]))
                {
                    Tweet tweet = new Tweet();
                    if (tweet.GetInfo(MessageBodyTextBox))
                    {
                        serialise(tweet, "tweet.json");
                    }
                }
            }
            else
            {
                MessageBox.Show("ID is not valid");
            }
        }

        private void serialise(object ClassName, string FileName )
        {
            string jsonString = JsonSerializer.Serialize(ClassName);
            File.AppendAllText(FileName , jsonString + "\n");
        }
    }
}
