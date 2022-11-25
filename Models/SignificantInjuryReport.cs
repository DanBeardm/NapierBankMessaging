using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace NapierBankMessaging.Models
{
    public class SignificantInjuryReport : Email
    {
        public string SortCode { get; set; }
        public string NatureOfIncedent { get; set; }

        public SignificantInjuryReport()
        {
            SortCode = string.Empty;
            NatureOfIncedent = string.Empty;
        }

        public void FindSortCode(string body)
        {
            SortCode = body;
            MessageBox.Show(SortCode);
        }
    }
}
