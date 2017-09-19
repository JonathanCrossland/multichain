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

        /// <summary>
        /// 	Generates one or more public/private key pairs, which are not stored in the wallet or drawn from the node’s key pool, ready for external key management. For each key pair, the address, pubkey (as embedded in transaction inputs) and privkey (used for signatures) is provided.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public JsonRpcResponse<MultiSignatureResponse> CreateKeyPairs(int count)
        {
            return _Client.Execute<MultiSignatureResponse>("createkeypairs", 0, count);
        }

        /// <summary>
        /// 	Generates one or more public/private key pairs, which are not stored in the wallet or drawn from the node’s key pool, ready for external key management. For each key pair, the address, pubkey (as embedded in transaction inputs) and privkey (used for signatures) is provided.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<MultiSignatureResponse>>> CreateKeyPairsAsync(int count)
        {
            return _Client.ExecuteAsync<List<MultiSignatureResponse>>("createkeypairs", 0, count);
        }

        /// <summary>
        /// Creates a pay-to-scripthash (P2SH) multisig address. Funds sent to this address can only be spent by transactions signed by nrequired of the specified keys. Each key can be a full hexadecimal public key, or an address if the corresponding key is in the node’s wallet. Returns an object containing the P2SH address and corresponding redeem script.
        /// </summary>
        /// <param name="nRequired"></param>
        /// <param name="addresses"></param>
        /// <returns></returns>
        public JsonRpcResponse<MultiSignatureResponse> CreateMultiSig(int nRequired, IEnumerable<string> addresses)
        {
            return _Client.Execute<MultiSignatureResponse>("createmultisig", 0, nRequired, addresses);
        }

        /// <summary>
        /// Creates a pay-to-scripthash (P2SH) multisig address. Funds sent to this address can only be spent by transactions signed by nrequired of the specified keys. Each key can be a full hexadecimal public key, or an address if the corresponding key is in the node’s wallet. Returns an object containing the P2SH address and corresponding redeem script.
        /// </summary>
        /// <param name="nRequired"></param>
        /// <param name="addresses"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<MultiSignatureResponse>> CreateMultiSigAsync(int nRequired, IEnumerable<string> addresses)
        {
            return _Client.ExecuteAsync<MultiSignatureResponse>("createkeypairs", 0, nRequired, addresses);
        }

        /// <summary>
        /// Returns information about address including a check for its validity.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public JsonRpcResponse<AddressResponse> ValidateAddress(string address)
        {
            return _Client.Execute<AddressResponse>("validateaddress", 0, address);
        }

        /// <summary>
        /// Returns information about address including a check for its validity.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<AddressResponse>> ValidateAddressAsync(string address)
        {
            return _Client.ExecuteAsync<AddressResponse>("validateaddress", 0, address);
        }
        
    }
}
