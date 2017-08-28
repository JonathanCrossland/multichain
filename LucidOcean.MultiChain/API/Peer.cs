/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LucidOcean.MultiChain.API
{
    public class Peer
    {
        MultiChainClient _Client = null;

        internal Peer(MultiChainClient client)
        {
            _Client = client;
        }

        public Task<JsonRpcResponse<string>> AddNodeAsync(string address, AddNodeParam command)
        {
            return _Client.ExecuteAsync<string>("addnode", 0, address, command.ToString().ToLower());
        }


        public Task<JsonRpcResponse<List<string>>> GetAddedNodeInfoAsync()
        {
            return _Client.ExecuteAsync<List<string>>("getaddednodeinfo", 0, false);
        }

        public Task<JsonRpcResponse<List<string>>> GetAddedNodeInfoAsync(string node)
        {
            return _Client.ExecuteAsync<List<string>>("getaddednodeinfo", 0, false, node);
        }

        public Task<JsonRpcResponse<List<string>>> GetAddedNodeInfoDetailsAsync()
        {
            return _Client.ExecuteAsync<List<string>>("getaddednodeinfo", 0, true);
        }

        public Task<JsonRpcResponse<List<string>>> GetAddedNodeInfoDetailsAsync(string node)
        {
            return _Client.ExecuteAsync<List<string>>("getaddednodeinfo", 0, true, node);
        }

        public Task<JsonRpcResponse<NetworkInfoResponse>> GetNetworkInfoAsync()
        {
            return _Client.ExecuteAsync<NetworkInfoResponse>("getnetworkinfo", 0);
        }

        public Task<JsonRpcResponse<List<PeerResponse>>> GetPeerInfoAsync()
        {
            return _Client.ExecuteAsync<List<PeerResponse>>("getpeerinfo", 0);
        }

        public Task<JsonRpcResponse<string>> PingAsync()
        {
            return _Client.ExecuteAsync<string>("ping", 0);
        }




        //clearmempool
        //pause
        //resume
        //setlastblock

      
    }
}
