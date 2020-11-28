using System;
using System.Collections.Generic;
using System.Text;

namespace CiBitUtil.Message.Response
{
   public class NewTransactionResponse
    {
        public bool IsSuccessful { get; set; }
        public string Token { get; set; }
    }
}
