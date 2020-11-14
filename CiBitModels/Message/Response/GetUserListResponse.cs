using System;
using System.Collections.Generic;
using System.Text;

namespace CiBitUtil.Message.Response
{
    public class GetUserListResponse
    {
        public Dictionary<string, string> UserNamesList { get; set; }

        public GetUserListResponse()
        {
            UserNamesList = new Dictionary<string, string>();
        }
    }
}
