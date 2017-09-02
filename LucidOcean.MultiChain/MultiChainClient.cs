/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain.API;

namespace LucidOcean.MultiChain
{
    public class MultiChainClient : JsonRpcClient {

        public MultiChainClient(MultiChainConnection connection) : base(connection) { Init(); }
        public MultiChainClient(string hostname, int port, string username, string password, string chainName) : base(hostname, port, username, password, chainName) { Init(); }

        internal void Init()
        {
            Address = new API.Address(this);
            Asset = new API.Asset(this);
            Block = new API.Block(this);
            Peer = new API.Peer(this);
            Permission = new API.Permission(this);
            Stream = new API.Stream(this);
            Transaction = new API.Transaction(this);
            Utility = new API.Utility(this);
            Wallet = new API.Wallet(this);
        }

        public Address Address { get; internal set; }
        public Asset Asset { get; internal set; }
        public Block Block { get; internal set; }
        public Peer Peer { get; internal set; }
        public Permission Permission { get; internal set; }
        public Transaction Transaction { get; internal set; }
        public Utility Utility { get; internal set; }
        public Wallet Wallet { get; internal set; }
        public API.Stream Stream { get; set; }

    }
}
