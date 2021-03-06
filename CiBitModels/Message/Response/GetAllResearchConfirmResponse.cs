﻿using System.Collections.Generic;

namespace CiBitUtil.Message.Response
{
    public class GetAllResearchConfirmResponse : Request.BaseWebRequest
    {
        public List<GetResearchConfirmResponse> Research { get; set; }

        public GetAllResearchConfirmResponse()
        {
            Research = new List<GetResearchConfirmResponse>();
        }
    }
}
