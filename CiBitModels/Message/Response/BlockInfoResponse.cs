using CiBitUtil.Message.Request;

namespace CiBitUtil.Message.Response
{
    public class BlockInfoResponse : GetTransactionRequest
    {
        public int Amount { get; set; }
    }
}