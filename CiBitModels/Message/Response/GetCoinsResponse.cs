using System;
using System.Collections.Generic;
using System.Text;
using CiBitUtil.Models;

namespace CiBitUtil.Message.Response
{
    public class GetCoinResponse
    {
        public List<string> Coins { get; set; }

        public GetCoinResponse()
        {
            Coins = new List<string>();
        }
    }
}
