/*=====================================================================
Authors: Jonathan Crossland et al. See github for contributors
Copyright © 2024 Jonathan Crossland (trading as Lucid Ocean). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0

The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain.Explorer.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LucidOcean.MultiChain.Explorer.Data;

namespace LucidOcean.MultiChain.Explorer
{
    public class Assets
    {
        MultiChainClient client = null;
        public Assets()
        {
            client = new MultiChainClient(ExplorerSettings.Connection);
        }

        public async Task<string> GetAllAssets()
        {
            List<AssetBalance> list = new List<AssetBalance>();

            var assets = await client.Asset.ListAssetsAsync();

            foreach (var item in assets.Result)
            {
                AssetBalance balance = new AssetBalance();
                balance.AssetRef = item.AssetRef;
                balance.Name = item.Name;
                balance.TxID = item.GenesisTxId;
                balance.Details = item.Details;

                client.Asset.Subscribe(item.Name, false);
                var transactions = await client.Asset.ListAssetTransactions(item.AssetRef, true);
                foreach (var transaction in transactions.Result)
                {
                    AssetTransaction at = new AssetTransaction();
                    at.Time = transaction.Time;
                    at.Date = BlockChainHelper.UnixTimeStampToDateTime(transaction.Time).ToString();
                    at.TxID = transaction.TxId;
                    at.BlockHash = transaction.BlockHash;
                    if (transaction.Addresses.Count == 1)
                    {
                        KeyValuePair<string, decimal> address = transaction.Addresses.First();

                        at.AddressFrom = "";
                        at.AddressTo = address.Key;
                        at.Qty = address.Value;
                    }
                    else
                    {
                        IOrderedEnumerable<KeyValuePair<string, decimal>> oList = transaction.Addresses.OrderBy(e => e.Value);

                        KeyValuePair<string, decimal> addressFrom = oList.First();
                        KeyValuePair<string, decimal> addressTo = oList.ElementAtOrDefault(1);

                        at.AddressFrom = addressFrom.Key;
                        at.AddressTo = addressTo.Key;
                        at.Qty = addressTo.Value;
                    }
                    balance.Transactions.Add(at);
                }

                list.Add(balance);
            }

            return JsonConvert.SerializeObject(list, Formatting.Indented);
        }

        public int GetAssetCount()
        {
            int count = client.Asset.ListAssets().Result.Count;
            return count;
        }
    }
}
