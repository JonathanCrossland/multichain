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
    /// Non Wallet Addresses checked against https://www.multichain.com/developers/json-rpc-api/
    /// </summary>
    public class Address
    {
        MultiChainClient _Client = null;

        internal Address(MultiChainClient client)
        {
            _Client = client;
        }

        public JsonRpcResponse<MultiSignatureResponse> CreateKeyPairs(int count)
        {
            return _Client.Execute<MultiSignatureResponse>("createkeypairs", 0, count);
        }

        public Task<JsonRpcResponse<List<MultiSignatureResponse>>> CreateKeyPairsAsync(int count)
        {
            return _Client.ExecuteAsync<List<MultiSignatureResponse>>("createkeypairs", 0, count);
        }

        public JsonRpcResponse<MultiSignatureResponse> CreateMultiSig(int nRequired, IEnumerable<string> addresses)
        {
            return _Client.Execute<MultiSignatureResponse>("createmultisig", 0, nRequired, addresses);
        }

        public Task<JsonRpcResponse<MultiSignatureResponse>> CreateMultiSigAsync(int nRequired, IEnumerable<string> addresses)
        {
            return _Client.ExecuteAsync<MultiSignatureResponse>("createkeypairs", 0, nRequired, addresses);
        }

        public JsonRpcResponse<AddressResponse> ValidateAddress(string address)
        {
            return _Client.Execute<AddressResponse>("validateaddress", 0, address);
        }

        public Task<JsonRpcResponse<AddressResponse>> ValidateAddressAsync(string address)
        {
            return _Client.ExecuteAsync<AddressResponse>("validateaddress", 0, address);
        }



    }
}
