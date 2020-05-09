using CiBitUtil.Message.Request;

namespace CiBitUtil.Message.Response
{
    public class BlockReadyResponse : GetTransactionRequest
    {
        public int Amount { get; set; }
    }
}
