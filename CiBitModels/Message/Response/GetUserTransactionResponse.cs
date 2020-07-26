using System;
namespace CiBitUtil.Message.Response
{
    public class GetUserTransactionResponse
    {
        public string Date { get; set; }
        public string Receiver { get; set; }
        public int Amount { get; set; }
        public string Research { get; set; }
        public string Status { get; set; }
        public bool isReceiver { get; set; }
    }
}
