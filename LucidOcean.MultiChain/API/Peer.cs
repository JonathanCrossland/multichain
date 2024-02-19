/*=====================================================================
Authors: Jonathan Crossland et al. See github for contributors
Copyright © 2024 Jonathan Crossland (trading as Lucid Ocean). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0

The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain.API.Enums;
using LucidOcean.MultiChain.Response;
using LucidOcean.MultiChain.Util;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LucidOcean.MultiChain.API
{
    /// <summary>
    /// API relating to Nodes
    /// </summary>
    public class Peer
    {
        internal readonly MultiChainClient _Client = null;

        internal Peer(MultiChainClient client)
        {
            _Client = client;
        }

        /// <summary>
        /// Manually adds or removes a peer-to-peer connection (peers are also discovered and added automatically). 
        /// The ip can be a hostname, IPv4 address, IPv4-as-IPv6 address or IPv6 address. For the entire ip:port you can also use the part after the @ symbol of the other node’s 
        /// nodeaddress, as given by the getinfo command. The command parameter should be one of add (to manually queue a node for the next available slot), 
        /// remove (to remove a node), or onetry (to immediately connect to a node even if a slot is not available).
        /// </summary>
        /// <param name="address"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> AddNodeAsync(string address, AddNodeParam command)
        {
            return _Client.ExecuteAsync<string>("addnode", 0, address, command.ToString().ToLower());
        }

        /// <summary>
        /// Manually adds or removes a peer-to-peer connection (peers are also discovered and added automatically). 
        /// The ip can be a hostname, IPv4 address, IPv4-as-IPv6 address or IPv6 address. For the entire ip:port you can also use the part after the @ symbol of the other node’s 
        /// nodeaddress, as given by the getinfo command. The command parameter should be one of add (to manually queue a node for the next available slot), 
        /// remove (to remove a node), or onetry (to immediately connect to a node even if a slot is not available).
        /// </summary>
        /// <param name="address"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> AddNodec(string address, AddNodeParam command)
        {
            return _Client.Execute<string>("addnode", 0, address, command.ToString().ToLower());
        }

        /// <summary>
        /// If verbose=true, returns information about a node which was added using addnode, or all such nodes if ip(:port) is omitted. If verbose=false, returns a list of added nodes only.
        /// </summary>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<string>>> GetAddedNodeInfoAsync()
        {
            return _Client.ExecuteAsync<List<string>>("getaddednodeinfo", 0, false);
        }
        /// <summary>
        /// If verbose=true, returns information about a node which was added using addnode, or all such nodes if ip(:port) is omitted. If verbose=false, returns a list of added nodes only.
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<List<string>> GetAddedNodeInfo()
        {
            return _Client.Execute<List<string>>("getaddednodeinfo", 0, false);
        }

        /// <summary>
        /// If verbose=true, returns information about a node which was added using addnode, or all such nodes if ip(:port) is omitted. If verbose=false, returns a list of added nodes only.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<string>>> GetAddedNodeInfoAsync(string node)
        {
            return _Client.ExecuteAsync<List<string>>("getaddednodeinfo", 0, false, node);
        }

        /// <summary>
        /// If verbose=true, returns information about a node which was added using addnode, or all such nodes if ip(:port) is omitted. If verbose=false, returns a list of added nodes only.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public JsonRpcResponse<List<string>> GetAddedNodeInfo(string node)
        {
            return _Client.Execute<List<string>>("getaddednodeinfo", 0, false, node);
        }

        /// <summary>
        /// If verbose=true, returns information about a node which was added using addnode, or all such nodes if ip(:port) is omitted. If verbose=false, returns a list of added nodes only.
        /// </summary>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<string>>> GetAddedNodeInfoDetailsAsync()
        {
            return _Client.ExecuteAsync<List<string>>("getaddednodeinfo", 0, true);
        }

        /// <summary>
        /// If verbose=true, returns information about a node which was added using addnode, or all such nodes if ip(:port) is omitted. If verbose=false, returns a list of added nodes only.
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<List<string>> GetAddedNodeInfoDetails()
        {
            return _Client.Execute<List<string>>("getaddednodeinfo", 0, true);
        }
        /// <summary>
        /// If verbose=true, returns information about a node which was added using addnode, or all such nodes if ip(:port) is omitted. If verbose=false, returns a list of added nodes only.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public JsonRpcResponse<List<string>> GetAddedNodeInfoDetails(string node)
        {
            return _Client.Execute<List<string>>("getaddednodeinfo", 0, true, node);
        }
        /// <summary>
        /// If verbose=true, returns information about a node which was added using addnode, or all such nodes if ip(:port) is omitted. If verbose=false, returns a list of added nodes only.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<string>>> GetAddedNodeInfoDetailsAsync(string node)
        {
            return _Client.ExecuteAsync<List<string>>("getaddednodeinfo", 0, true, node);
        }

        /// <summary>
        /// Returns information about the network ports to which the node is connected, and its local IP addresses.
        /// </summary>
        /// <returns></returns>
        public Task<JsonRpcResponse<NetworkInfoResponse>> GetNetworkInfoAsync()
        {
            return _Client.ExecuteAsync<NetworkInfoResponse>("getnetworkinfo", 0);
        }

        /// <summary>
        /// Returns information about the other nodes to which this node is connected. If this is a MultiChain blockchain, includes handshake and handshakelocal fields showing the remote and local address used during the handshaking for that connection.
        /// </summary>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<PeerResponse>>> GetPeerInfoAsync()
        {
            return _Client.ExecuteAsync<List<PeerResponse>>("getpeerinfo", 0);
        }

        /// <summary>
        /// Sends a ping message to all connected nodes to measure network latency and backlog. The results are received asynchronously and retrieved from the pingtime field of the response to getpeerinfo.
        /// </summary>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> PingAsync()
        {
            return _Client.ExecuteAsync<string>("ping", 0);
        }

        public JsonRpcResponse<string> ClearMemPool()
        {
            return _Client.Execute<string>("clearmempool", 0);
        }

        public JsonRpcResponse<string> Pause(NodeTask task)
        {
            return _Client.Execute<string>("pause",0, Enum.GetName(typeof(NodeTask),task).ToLower());
        }

        public JsonRpcResponse<string> Resume(NodeTask task)
        {
            return _Client.Execute<string>("resume", 0, Enum.GetName(typeof(NodeTask), task).ToLower());
        }

        public void SetLastBlock()
        {
            throw new NotImplementedException();
        }



    }
}
