using System;
using System.Collections.Generic;
using System.Text;

namespace CiBitUtil.Message.Response
{
    public class UserSettingsResponse
    {
        public bool IsSuccessful { get; set; }
        public string Token { get; set; }
    }
}
