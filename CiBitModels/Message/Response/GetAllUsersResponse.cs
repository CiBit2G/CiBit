﻿using CiBitUtil.Models;
using System.Collections.Generic;

namespace CiBitUtil.Message.Response
{
    public class GetAllUsersResponse
    {
        public List<GetUserConfirmResponse> Users { get; set; }

        public GetAllUsersResponse()
        {
            Users = new List<GetUserConfirmResponse>();
        }
    }
}
