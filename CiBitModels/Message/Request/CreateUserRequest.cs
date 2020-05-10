namespace CiBitUtil.Message.Request
{
    public class CreateUserRequest : AddUserRequest
    {

        public string ArticleName { get; set; }

        public int CitationCount { get; set; }
    }
}
