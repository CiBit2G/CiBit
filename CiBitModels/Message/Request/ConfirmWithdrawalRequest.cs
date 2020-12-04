using System;
using System.Collections.Generic;
using System.Text;

namespace CiBitUtil.Message.Request
{
    public class ConfirmWithdrawalRequest: BaseWebRequest
    {
        public int WithdrawalId { get; set; }
        public string SenderId { get; set; }

        public int Status { get; set; }

        public int Amount { get; set; }
    }
}
