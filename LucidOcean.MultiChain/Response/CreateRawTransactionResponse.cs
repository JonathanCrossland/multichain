/*=====================================================================
Authors: Jonathan Crossland et al. See github for contributors
Copyright © 2024 Jonathan Crossland (trading as Lucid Ocean). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0

The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain.Util;

namespace LucidOcean.MultiChain.Response
{
    public class CreateRawTransactionResponse
    {
        public JsonRpcResponse<string> TxId { get; internal set; }

        public JsonRpcResponse<string> TxHex { get; internal set; }

        public JsonRpcResponse<SignedTransactionResponse> SignedTransaction { get; internal set; }
    }
}
