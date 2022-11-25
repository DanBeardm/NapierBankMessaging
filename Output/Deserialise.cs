using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using NapierBankMessaging.Models;
using System.Windows;

namespace NapierBankMessaging.Output
{
    public class Deserialise
    {
        public Deserialise()
        {
            string FileName = "sms.json";
            string jsonString = File.ReadAllText(FileName);
            SmS sms = JsonSerializer.Deserialize<SmS>(jsonString)!;

            MessageBox.Show("Deserialise: "+ sms.Message);
        }
        
    }
}
