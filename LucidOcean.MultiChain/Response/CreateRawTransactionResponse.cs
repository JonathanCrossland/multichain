namespace LucidOcean.MultiChain.Response
{
    public class CreateRawTransactionResponse
    {
        public JsonRpcResponse<string> TxId { get; internal set; }

        public JsonRpcResponse<string> TxHex { get; internal set; }

        public JsonRpcResponse<SignedTransactionResponse> SignedTransaction { get; internal set; }
    }
}
