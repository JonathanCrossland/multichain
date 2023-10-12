using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucidOcean.MultiChain.Response
{
    /// <summary>
    /// {"restrict":"offchain,onchain,write,read"}
    /// </summary>
    public class ListStreamRestrictResponse
    {

        [JsonProperty("offchain", NullValueHandling = NullValueHandling.Ignore)]
        public Boolean OffChain { get; set; }

        [JsonProperty("onchain", NullValueHandling = NullValueHandling.Ignore)]
        public Boolean OnChain { get; set; }

        [JsonProperty("write", NullValueHandling = NullValueHandling.Ignore)]
        public Boolean Write { get; set; }

        [JsonProperty("read", NullValueHandling = NullValueHandling.Ignore)]
        public Boolean Read { get; set; }

    }
}
