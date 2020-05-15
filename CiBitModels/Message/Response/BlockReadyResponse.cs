using CiBitUtil.Message.Request;

namespace CiBitUtil.Message.Response
{
    public class BlockReadyResponse : GetTransactionRequest
    {
        public string Hash { get; set; }
    }
}
