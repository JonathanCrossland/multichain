/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain.Explorer.Data;
using LucidOcean.MultiChain.Response;
using System;
using System.Collections.Generic;

namespace LucidOcean.MultiChain.Explorer
{
    public class Address
    {
        MultiChainClient _client = null;
        public Address()
        {
            _client = new MultiChainClient(ExplorerSettings.Connection);
        }

        public List<AddressTransactionResponse> Get(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            try
            {
                _client.Wallet.ImportAddress(id);
                List<AddressTransactionResponse> transactions = _client.Wallet.ListAddressTransactions(id, 999, 0, true).Result;                
                return transactions;
            }
            catch (Exception)
            {
                return null;                
            }            
        }
    }
}
