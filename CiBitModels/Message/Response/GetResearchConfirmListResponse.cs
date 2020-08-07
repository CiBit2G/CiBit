using System.Collections.Generic;

namespace CiBitUtil.Message.Response
{
    public class GetResearchConfirmListResponse
    {
        public List<GetResearchConfirmResponse> ResearchConfirmList { get; set; }

        public GetResearchConfirmListResponse()
        {
            ResearchConfirmList = new List<GetResearchConfirmResponse>();
        }
    }
}
