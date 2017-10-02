using Newtonsoft.Json;

namespace LucidOcean.MultiChain.Response
{
    public class SignedTransactionResponse
    {
        [JsonProperty("hex")]
        public string Hex { get; set; }

        [JsonProperty("complete")]
        public bool IsCompleted { get; set; }
    }
}
