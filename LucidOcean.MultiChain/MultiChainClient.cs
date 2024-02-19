/*=====================================================================
Authors: Jonathan Crossland et al. See github for contributors
Copyright © 2024 Jonathan Crossland (trading as Lucid Ocean). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0

The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain.API;
using LucidOcean.MultiChain.Util;

namespace LucidOcean.MultiChain
{

    /// <summary>
    /// This is the main client wrapper with API calls.
    /// </summary>
    public class MultiChainClient : JsonRpcClient {

        /// <summary>
        /// Create an instance of this client will initialse all internal API types.
        /// For example Address, Peer, Transaction will get this client injected.
        /// You can call Address by itself if you instantiate Address injecting the client yourself.
        /// </summary>
        /// <param name="connection"></param>
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

        /// <summary>
        /// Calls relating to Addresses
        /// </summary>
        public Address Address { get; internal set; }
        /// <summary>
        /// Calls relating to Assets
        /// </summary>
        public Asset Asset { get; internal set; }
        /// <summary>
        /// Calls relating to Blocks
        /// </summary>
        public Block Block { get; internal set; }
        /// <summary>
        /// Calls relating to Peer Nodes
        /// </summary>
        public Peer Peer { get; internal set; }
        /// <summary>
        /// Calls relating to Permissions
        /// </summary>
        public Permission Permission { get; internal set; }
        /// <summary>
        /// Calls relating to Transactions
        /// </summary>
        public Transaction Transaction { get; internal set; }
        /// <summary>
        /// Utility calls
        /// </summary>
        public API.Utility Utility { get; internal set; }
        /// <summary>
        /// Calls relating to Wallet Addresses
        /// </summary>
        public Wallet Wallet { get; internal set; }
        /// <summary>
        /// Calls relating to Streams
        /// </summary>
        public API.Stream Stream { get; set; }

    }
}
