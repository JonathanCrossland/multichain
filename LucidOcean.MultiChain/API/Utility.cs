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
    /// <summary>
    /// Verified against https://www.multichain.com/developers/json-rpc-api/
    /// </summary>
    public class Utility
    {

        JsonRpcClient _Client = null;

        internal Utility(JsonRpcClient client)
        {
            _Client = client;
        }
        
        public Task<JsonRpcResponse<Dictionary<string, object>>> GetBlockChainParamsAsync()
        {
            return _Client.ExecuteAsync<Dictionary<string, object>>("getblockchainparams", 0);
        }
        public Task<JsonRpcResponse<Dictionary<string, object>>> GetBlockChainParamsAsync(bool displayNames)
        {
            return _Client.ExecuteAsync<Dictionary<string, object>>("getblockchainparams", 0, displayNames);
        }
        public JsonRpcResponse<Dictionary<string, object>> GetBlockChainParams()
        {
            return _Client.Execute<Dictionary<string, object>>("getblockchainparams", 0);
        }
        public JsonRpcResponse<Dictionary<string, object>> GetBlockChainParams(bool displayNames)
        {
            return _Client.Execute<Dictionary<string, object>>("getblockchainparams", 0, displayNames);
        }

        
        public JsonRpcResponse<Dictionary<string, object>> GetRuntimeParams()
        {
            return _Client.Execute<Dictionary<string, object>>("getruntimeparams", 0);
        }
        public Task<JsonRpcResponse<Dictionary<string, object>>> GetRuntimeParamsAsync()
        {
            return _Client.ExecuteAsync<Dictionary<string, object>>("getruntimeparams", 0);
        }


        public Task<JsonRpcResponse<Dictionary<string, object>>> SetRuntimeParamsAsync(string param, string value)
        {
            return _Client.ExecuteAsync<Dictionary<string, object>>("setruntimeparam", 0, param, value);
        }
        public JsonRpcResponse<Dictionary<string, object>> SetRuntimeParams(string param, string value)
        {
            return _Client.Execute<Dictionary<string, object>>("setruntimeparam", 0, param, value);
        }

        public JsonRpcResponse<GetInfoResponse> GetInfo()
        {
            return _Client.Execute<GetInfoResponse>("getinfo", 0);
        }
        public Task<JsonRpcResponse<GetInfoResponse>> GetInfoAsync()
        {
            return _Client.ExecuteAsync<GetInfoResponse>("getinfo", 0);
        }


        public Task<JsonRpcResponse<string>> HelpAsync()
        {
            return _Client.ExecuteAsync<string>("help", 0);
        }
        public Task<JsonRpcResponse<string>> HelpAsync(string command)
        {
            return _Client.ExecuteAsync<string>("help", 0, command);
        }
        public JsonRpcResponse<string> Help()
        {
            return _Client.Execute<string>("help", 0);
        }
        public JsonRpcResponse<string> Help(string command)
        {
            return _Client.Execute<string>("help", 0, command);
        }

        public JsonRpcResponse<object> Stop()
        {
            return _Client.Execute<object>("stop", 0);
        }
        public Task<JsonRpcResponse<object>> StopAsync()
        {
            return _Client.ExecuteAsync<object>("stop", 0);
        }


    }
}
