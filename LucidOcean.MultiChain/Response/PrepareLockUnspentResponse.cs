using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucidOcean.MultiChain.Response
{
    
    public class PrepareLockUnspentResponse
    {
        public PrepareLockUnspentResponse()
        {

        }

        [JsonProperty("txid")]
        public string TxId { get; set; }

        [JsonProperty("vout")]
        public string Vout { get; set; }

    }
}
