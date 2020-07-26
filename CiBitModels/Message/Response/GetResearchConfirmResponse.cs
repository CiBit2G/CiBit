using System;

namespace CiBitUtil.Message.Response
{
    public class GetResearchConfirmResponse
    {
        public DateTime DateOfResearch { get; set; }
        public string CiBitId { get; set; }
        public string ReseachName { get; set; }
        public string Status { get; set; }
    }
}
