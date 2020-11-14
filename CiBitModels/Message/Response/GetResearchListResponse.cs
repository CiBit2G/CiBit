using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace CiBitUtil.Message.Response
{
    public class GetResearchListResponse
    {
        public Dictionary<string, string> ResearchNamesList { get; set; }

        public GetResearchListResponse()
        {
            ResearchNamesList = new Dictionary<string, string>();
        }
    }
}
