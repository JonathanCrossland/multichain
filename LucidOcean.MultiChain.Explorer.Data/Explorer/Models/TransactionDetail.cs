/*=====================================================================
Authors: Jonathan Crossland et al. See github for contributors
Copyright © 2024 Jonathan Crossland (trading as Lucid Ocean). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0

The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain.Explorer.Data;
using LucidOcean.MultiChain.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LucidOcean.MultiChain.Explorer
{
    public class TransactionDetail
    {
        public TransactionDetail()
        {
        }

        public string From { get; set; }

        public string To { get; set; }

        public string Action { get; set; }

        public string Confirmations { get; set; }

        public string EventType { get; set; }

        public DateTime BlockTime { get; set; }

        public string TxId { get; set; }
        public string HashFrom { get; set; }
        public string HashTo { get; set; }
        public string EventTypeLabel { get; set; }

        public List<TransactionDetail> Get(RawTransactionResponse model)
        {
            List<TransactionDetail> list = new List<TransactionDetail>();
            TransactionDetail td = new TransactionDetail();
            List<string> addresses = new List<string>();
            bool isExchange = false;
            foreach (var item in model.Vout)
            {
                td.BlockTime = BlockChainHelper.UnixTimeStampToDateTime(model.Time);
                td.TxId = model.TxId;
                td.Confirmations = model.Confirmations + " Confirmations";
                if (item.Assets != null)
                {
                    if (item.Assets.Count == 1)
                    {
                        isExchange = true;
                        AssetBalanceResponse asset = item.Assets.First();
                        // if asset transfer
                        if (asset.Type == "transfer")
                        {
                            td.EventType = "success fa fa-2x fa-arrow-right";
                        }
                        else // if issue of asset
                        {
                            td.EventType = "fa fa-arrow-right";
                            td.EventTypeLabel = "Asset Issued";
                            td.Action = item.Assets.First().Name;
                        }
                        if (item.ScriptPubKey.Addresses.Count > 0)
                        {
                            td.To = item.ScriptPubKey.Addresses.First();
                        }
                    }
                    else
                    {
                        if (item.ScriptPubKey.Addresses.Count > 0)
                        {
                            if (isExchange)
                            {
                                if (string.IsNullOrEmpty(td.From))
                                {
                                    td.From = item.ScriptPubKey.Addresses.First();
                                }
                            }
                            else
                            {
                                addresses.Add(item.ScriptPubKey.Addresses.First());
                            }
                        }

                        // if stream
                        if (item.Items.Count > 0)
                        {
                           td.From = item.Items.First().Publishers?.First;

                            td.Action = item.Items.First().Key;
                            td.To = item.Items.First().StreamRef;

                            if (!string.IsNullOrEmpty(item.Items.First().DataAsAscii))
                            {
                                if (BlockChainHelper.IsJsonObject(item.Items.First().DataAsAscii))
                                {
                                    StreamData data = JsonConvert.DeserializeObject<StreamData>(item.Items.First().DataAsAscii);
                                    if (data != null)
                                    {
                                        td.To = data.Address;
                                        td.HashTo = data.Hash;
                                        td.EventType = "fa fa-arrow-right";
                                    }
                                }
                            }

                            ResolveStreamKey(td);
                        }

                        // if permission change
                        if (item.Permissions.Count > 0)
                        {
                            td.From = ExplorerSettings.Connection.RootNodeAddress;
                            td.To = item.ScriptPubKey.Addresses.First();
                            td.Action = "Permissions Changed";
                        }
                    }
                }
                if (addresses.Count == 1)
                {
                    td.To = addresses.First();
                }
                else if (addresses.Count > 1)
                {
                    td.To = addresses.First();
                    td.From = addresses.Last();
                }

                // is miner
                if (string.IsNullOrEmpty(td.From) && string.IsNullOrEmpty(td.To))
                {
                    td.Confirmations = model.Confirmations + " Confirmations";
                    Blocks blocks = new Blocks();
                    td.From = blocks.GetMiner(model.BlockHash) + "<br/>";
                    td.EventTypeLabel = "Coinbase Miner Transaction";
                }

                if (string.IsNullOrEmpty(td.To))
                {
                    td.To = td.From;
                    td.From = ExplorerSettings.Connection.RootNodeAddress;
                }
            }

            if (string.IsNullOrEmpty(td.Action))
            {
                // to be implemented
            }

            td.To = ResolveAddress(td.To, td);
            td.From = ResolveAddress(td.From, td);

            if (CanAdd(td))
            {
                list.Add(td);
            }
            return list;
        }

        private void ResolveStreamKey(TransactionDetail td)
        {
            if (!string.IsNullOrEmpty(td.Action))
            {
                string from = td.From;
                string to = td.To;
                string hashfrom = td.HashFrom;
                string hashto = td.HashTo;
            }
        }

        private string ResolveAddress(string address, TransactionDetail td)
        {
            string origAddress = address;
            if (!string.IsNullOrEmpty(address))
            {
                if (!address.Contains("<br"))
                {
                    address = $"<a href=\"/BlockChain/Explorer/Address/{address}\">{address}</a>";
                }
            }
            return address;
        }

        private bool CanAdd(TransactionDetail td)
        {
            bool ret = true;
            if (string.IsNullOrEmpty(td.Action) && string.IsNullOrEmpty(td.From) && string.IsNullOrEmpty(td.To) && string.IsNullOrEmpty(td.Action) && string.IsNullOrEmpty(td.EventType))
            {
                ret = false;
            }
            return ret;
        }
    }
}
