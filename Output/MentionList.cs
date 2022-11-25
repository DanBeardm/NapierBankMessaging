using NapierBankMessaging.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NapierBankMessaging.Output
{
    public class MentionList
    {
        private readonly string _txtFilePath;
        public string ErrorCode { get; set; }

        public MentionList()
        {
            _txtFilePath = "MentionList.txt";

            ErrorCode = string.Empty;
        }

        public bool ToList(string Mention)
        {
            try
            {
                Mention += "\n";
                File.AppendAllText(_txtFilePath, Mention.ToString());
                return true;
            }
            catch (Exception ex)
            {
                ErrorCode = ex.ToString();
                return false;
            }
        }

        public string FromList()
        {
            string[] lines = File.ReadAllLines(_txtFilePath);
            string StringBuilder = string.Empty;

            foreach (string line in lines)
            {
                StringBuilder += line + "\n";
            }

            return StringBuilder;
        }
    }
}
