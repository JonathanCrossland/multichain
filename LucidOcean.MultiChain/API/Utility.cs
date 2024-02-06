/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain.Response;
using LucidOcean.MultiChain.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LucidOcean.MultiChain.API
{
    /// <summary>
    /// Verified against https://www.multichain.com/developers/json-rpc-api/
    /// </summary>
    public class Utility
    {

        internal readonly JsonRpcClient _Client = null;

        internal Utility(JsonRpcClient client)
        {
            _Client = client;
        }

        /// <summary>
        /// 	Returns a list of values of this blockchain’s parameters, which are fixed by the chain’s genesis block and the same for all nodes.
        /// </summary>
        /// <returns></returns>
        public Task<JsonRpcResponse<Dictionary<string, object>>> GetBlockChainParamsAsync()
        {
            return _Client.ExecuteAsync<Dictionary<string, object>>("getblockchainparams", 0);
        }

        /// <summary>
        /// 	Returns a list of values of this blockchain’s parameters, which are fixed by the chain’s genesis block and the same for all nodes.
        /// </summary>
        /// <param name="displayNames"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<Dictionary<string, object>>> GetBlockChainParamsAsync(bool displayNames)
        {
            return _Client.ExecuteAsync<Dictionary<string, object>>("getblockchainparams", 0, displayNames);
        }

        /// <summary>
        /// 	Returns a list of values of this blockchain’s parameters, which are fixed by the chain’s genesis block and the same for all nodes.
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<Dictionary<string, object>> GetBlockChainParams()
        {
            return _Client.Execute<Dictionary<string, object>>("getblockchainparams", 0);
        }

        /// <summary>
        /// 	Returns a list of values of this blockchain’s parameters, which are fixed by the chain’s genesis block and the same for all nodes.
        /// </summary>
        /// <param name="displayNames"></param>
        /// <returns></returns>
        public JsonRpcResponse<Dictionary<string, object>> GetBlockChainParams(bool displayNames)
        {
            return _Client.Execute<Dictionary<string, object>>("getblockchainparams", 0, displayNames);
        }

        /// <summary>
        /// Returns a selection of this node’s runtime parameters, which are set when the node starts up. Some parameters can be modified while MultiChain is running using setruntimeparam.
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<Dictionary<string, object>> GetRuntimeParams()
        {
            return _Client.Execute<Dictionary<string, object>>("getruntimeparams", 0);
        }

        /// <summary>
        /// Returns a selection of this node’s runtime parameters, which are set when the node starts up. Some parameters can be modified while MultiChain is running using setruntimeparam.
        /// </summary>
        /// <returns></returns>
        public Task<JsonRpcResponse<Dictionary<string, object>>> GetRuntimeParamsAsync()
        {
            return _Client.ExecuteAsync<Dictionary<string, object>>("getruntimeparams", 0);
        }

        /// <summary>
        /// Sets the runtime parameter param to value and immediately applies the change. Currently supported parameters: autosubscribe bantx handshakelocal hideknownopdrops lockadminminerounds lockblock maxshowndata mineemptyrounds miningrequirespeers miningturnover.
        /// </summary>
        /// <param name="param"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<Dictionary<string, object>>> SetRuntimeParamsAsync(string param, string value)
        {
            return _Client.ExecuteAsync<Dictionary<string, object>>("setruntimeparam", 0, param, value);
        }

        /// <summary>
        /// Sets the runtime parameter param to value and immediately applies the change. Currently supported parameters: autosubscribe bantx handshakelocal hideknownopdrops lockadminminerounds lockblock maxshowndata mineemptyrounds miningrequirespeers miningturnover.
        /// </summary>
        /// <param name="param"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public JsonRpcResponse<Dictionary<string, object>> SetRuntimeParams(string param, string value)
        {
            return _Client.Execute<Dictionary<string, object>>("setruntimeparam", 0, param, value);
        }


        /// <summary>
        /// Returns general information about this node and blockchain. MultiChain adds some fields to Bitcoin Core’s response, giving the blockchain’s chainname, description, protocol, peer-to-peer port. There are also incomingpaused and miningpaused fields – see the pause command. The burnaddress is an address with no known private key, to which assets can be sent to make them provably unspendable. The nodeaddress can be passed to other nodes for connecting. The setupblocks field gives the length in blocks of the setup phase in which some consensus constraints are not applied.
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<GetInfoResponse> GetInfo()
        {
           return _Client.Execute<GetInfoResponse>("getinfo", 0);
        }

        /// <summary>
        /// Returns general information about this node and blockchain. MultiChain adds some fields to Bitcoin Core’s response, giving the blockchain’s chainname, description, protocol, peer-to-peer port. There are also incomingpaused and miningpaused fields – see the pause command. The burnaddress is an address with no known private key, to which assets can be sent to make them provably unspendable. The nodeaddress can be passed to other nodes for connecting. The setupblocks field gives the length in blocks of the setup phase in which some consensus constraints are not applied.
        /// </summary>
        /// <returns></returns>
        public Task<JsonRpcResponse<GetInfoResponse>> GetInfoAsync()
        {
            return _Client.ExecuteAsync<GetInfoResponse>("getinfo", 0);
        }

        /// <summary>
        /// Returns a list of available API commands, including MultiChain-specific commands.
        /// </summary>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> HelpAsync()
        {
            return _Client.ExecuteAsync<string>("help", 0);
        }

        /// <summary>
        /// Returns a list of available API commands, including MultiChain-specific commands.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> HelpAsync(string command)
        {
            return _Client.ExecuteAsync<string>("help", 0, command);
        }

        /// <summary>
        /// Returns a list of available API commands, including MultiChain-specific commands.
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<string> Help()
        {
            return _Client.Execute<string>("help", 0);
        }

        /// <summary>
        /// Returns a list of available API commands, including MultiChain-specific commands.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> Help(string command)
        {
            return _Client.Execute<string>("help", 0, command);
        }

        /// <summary>
        /// Shuts down the this blockchain node, i.e. stops the multichaind process.
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<object> Stop()
        {
            return _Client.Execute<object>("stop", 0);
        }

        /// <summary>
        /// Shuts down the this blockchain node, i.e. stops the multichaind process.
        /// </summary>
        /// <returns></returns>
        public Task<JsonRpcResponse<object>> StopAsync()
        {
            return _Client.ExecuteAsync<object>("stop", 0);
        }

    }
}
