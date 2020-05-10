using CiBitUtil.Attributes;

namespace CiBitUtil.Message.Request
{
    public class GetUserRequest
    {
        [CiBitId]
        public string CibitId { get; set; }
    }
}
