using CiBitUtil.Attributes;

namespace CiBitUtil.Message.Request
{
    public class GetUserRequest : BaseWebRequest
    {
        [CiBitId]
        public string CibitId { get; set; }
    }
}
