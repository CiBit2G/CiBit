namespace CiBitUtil.Message.Request
{
    public class ConfirmUserRequest: BaseWebRequest
    {
        public string CibitId { get; set; }

        public int Status { get; set; }
    }
}
