/*=====================================================================
Authors: Jonathan Crossland et al. See github for contributors
Copyright © 2024 Jonathan Crossland (trading as Lucid Ocean). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0

The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LucidOcean.MultiChain.Response
{
    public class PeerResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("addr")]
        public string Addr { get; set; }

        [JsonProperty("services")]
        public string Services { get; set; }

        [JsonProperty("lastsend")]
        public long LastSend { get; set; }

        [JsonProperty("lastrecv")]
        public long LastRecv { get; set; }

        [JsonProperty("bytessent")]
        public long BytesSent { get; set; }

        [JsonProperty("bytesrecv")]
        public long BytesRecv { get; set; }

        [JsonProperty("conntime")]
        public long ConnTime { get; set; }

        [JsonProperty("pingtime")]
        public decimal PingTime { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("subver")]
        public string SubVer { get; set; }

        [JsonProperty("handshakelocal")]
        public string HandshakeLocal { get; set; }

        [JsonProperty("handshake")]
        public string Handshake { get; set; }

        [JsonProperty("inbound")]
        public bool Inbound { get; set; }

        [JsonProperty("startingheight")]
        public int StartingHeight { get; set; }

        [JsonProperty("banscore")]
        public int BanScore { get; set; }

        [JsonProperty("synced_headers")]
        public int SyncedHeaders { get; set; }

        [JsonProperty("synced_blocks")]
        public int SyncedBlocks { get; set; }

        [JsonProperty("inflight")]
        public List<object> Inflight { get; set; }

        public PeerResponse()
        {
            this.Inflight = new List<object>();
        }
    }
}
