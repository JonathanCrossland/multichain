using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucidOcean.MultiChain.Response
{
    public class ListStreamIndexesResponse
    {

        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public Boolean Items { get; set; }

        [JsonProperty("keys", NullValueHandling = NullValueHandling.Ignore)]
        public Boolean Keys { get; set; }

        [JsonProperty("publishers", NullValueHandling = NullValueHandling.Ignore)]
        public Boolean Publishers { get; set; }

        [JsonProperty("items-local", NullValueHandling = NullValueHandling.Ignore)]
        public Boolean ItemsLocal { get; set; }

        [JsonProperty("keys-local", NullValueHandling = NullValueHandling.Ignore)]
        public Boolean KeysLocal { get; set; }

        [JsonProperty("publishers-local", NullValueHandling = NullValueHandling.Ignore)]
        public Boolean PublishersLocal { get; set; }
    }
}
