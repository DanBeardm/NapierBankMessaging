

namespace NapierBankMessaging.Models
{
    public class SmS
    {
        public string SenderName { get; set; }
        public string Message { get; set; }
        public SmS()
        {
            SenderName = string.Empty;
            Message = string.Empty;
        }
    }
}
