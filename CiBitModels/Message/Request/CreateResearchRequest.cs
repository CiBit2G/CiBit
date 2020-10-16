using CiBitUtil.Attributes;

namespace CiBitUtil.Message.Request
{
    public class CreateResearchRequest : AddResearchRequest
    {
        [CiBitId]
        public string CiBitId { get; set; }

        [CiBitId]
        public string Abstract { get; set; }
    }
}
