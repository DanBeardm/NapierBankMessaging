using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace NapierBankMessaging.Output
{
    public class TrendingList
    {
        private readonly string _txtFilePath;
        public string ErrorCode { get; set; }

        public TrendingList()
        {
            _txtFilePath = "TrendingList.txt";

            ErrorCode = string.Empty;
        }

        public bool ToList(string Trend)
        {
            try
            {
                Trend += "\n";
                File.AppendAllText(_txtFilePath, Trend.ToString());
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
