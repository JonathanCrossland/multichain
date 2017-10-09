/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain.Explorer.Data;
using LucidOcean.MultiChain.Response;
using LucidOcean.MultiChain.Util;
using System;

namespace LucidOcean.MultiChain.Explorer
{
    public class Transactions
    {
        MultiChainClient _client = null;
        public Transactions()
        {
            _client = new MultiChainClient(ExplorerSettings.Connection);
        }

        public RawTransactionResponse Get(string txid)
        {
            if (string.IsNullOrEmpty(txid)) return null;
            try
            {
                JsonRpcResponse<RawTransactionResponse> obj = _client.Transaction.GetRawTransactionVerbose(txid);
                return obj.Result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int GetTransactionCount()
        {
            int count = 0;
            Blocks b = new Blocks();
            var blocks = b.GetAll();

            foreach (var item in blocks)
            {
                count += item.TxCount;
            }

            return count;
        }
    }
}