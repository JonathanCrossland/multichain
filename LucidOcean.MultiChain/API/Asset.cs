/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain.Response;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace LucidOcean.MultiChain.API
{
    public class Asset
    {
        MultiChainClient _Client = null;

        internal Asset(MultiChainClient client)
        {
            _Client = client;
        }

        public JsonRpcResponse<string> Issue(string issueAddress, object assetName, int quantity, decimal units, [Optional]object metaData, decimal nativeAmount = 0, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            if (metaData == null)
                return _Client.Execute<string>("issue", 0, issueAddress, assetName, quantity, units, nativeAmount);
            else
                return _Client.Execute<string>("issue", 0, issueAddress, assetName, quantity, units, nativeAmount, metaData);
        }
        public Task<JsonRpcResponse<string>> IssueAsync(string issueAddress, object assetName, int quantity, decimal units, object metaData = null, decimal nativeAmount = 0, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            if (metaData == null)
                return _Client.ExecuteAsync<string>("issue", 0, issueAddress, assetName, quantity, units, nativeAmount);
            else
                return _Client.ExecuteAsync<string>("issue", 0, issueAddress, assetName, quantity, units, nativeAmount, metaData);
        }

        public JsonRpcResponse<string> IssueFrom(string fromAddress, string toAddress, object assetName, int quantity, decimal units, decimal nativeAmount, [Optional]object metaData, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            if (metaData == null)
                return _Client.Execute<string>("issuefrom", 0, fromAddress, toAddress, assetName, quantity, units, nativeAmount);
            else
                return _Client.Execute<string>("issuefrom", 0, fromAddress, toAddress, assetName, quantity, units, nativeAmount, metaData);
        }

        public Task<JsonRpcResponse<string>> IssueFromAsync(string fromAddress, string toAddress, object assetName, int quantity, decimal units, [Optional]object metaData, decimal nativeAmount = 0, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            if (metaData == null)
                return _Client.ExecuteAsync<string>("issuefrom", 0, fromAddress, toAddress, assetName, quantity, units);
            else
                return _Client.ExecuteAsync<string>("issuefrom", 0, fromAddress, toAddress, assetName, quantity, units, metaData);
        }

        public JsonRpcResponse<string> IssueMore(string fromAddress, object assetName, int quantity, [Optional]object metaData)
        {
            if (metaData == null)
                return _Client.Execute<string>("issuemore", 0, fromAddress, assetName, quantity, metaData);
            else
                return _Client.Execute<string>("issuemore", 0, fromAddress, assetName, quantity, metaData);
        }

        public Task<JsonRpcResponse<string>> IssueMoreAsync(string fromAddress, object assetName, int quantity, [Optional]object metaData)
        {
            if (metaData == null)
                return _Client.ExecuteAsync<string>("issuemore", 0, fromAddress, assetName, quantity, metaData);
            else
                return _Client.ExecuteAsync<string>("issuemore", 0, fromAddress, assetName, quantity, metaData);
        }

        public JsonRpcResponse<string> IssueMoreFrom(string fromAddress, string toAddress, object assetName, int quantity, decimal nativeAmount, [Optional]object metaData)
        {
            if (metaData == null)
                return _Client.Execute<string>("issuefrom", 0, fromAddress, toAddress, assetName, quantity, nativeAmount);
            else
                return _Client.Execute<string>("issuefrom", 0, fromAddress, toAddress, assetName, quantity, nativeAmount, metaData);
        }

        public Task<JsonRpcResponse<string>> IssueMoreFromAsync(string fromAddress, string toAddress, object assetName, int quantity, decimal nativeAmount, [Optional]object metaData)
        {
            if (metaData == null)
                return _Client.ExecuteAsync<string>("issuemorefrom", 0, fromAddress, toAddress, assetName, quantity, nativeAmount);
            else
                return _Client.ExecuteAsync<string>("issuemorefrom", 0, fromAddress, toAddress, assetName, quantity, nativeAmount, metaData);
        }

        public JsonRpcResponse<List<AssetResponse>> ListAssets()
        {
            return _Client.Execute<List<AssetResponse>>("listassets", 0, "*", false);
        }

        public JsonRpcResponse<List<AssetResponse>> ListAssets(string assetFilter = "*", bool verbose = false)
        {
            return _Client.Execute<List<AssetResponse>>("listassets", 0, assetFilter, verbose);
        }

        public Task<JsonRpcResponse<List<AssetResponse>>> ListAssetsAsync()
        {
            return _Client.ExecuteAsync<List<AssetResponse>>("listassets", 0, "*", false);
        }

        public Task<JsonRpcResponse<List<AssetResponse>>> ListAssetsAsync(string assetFilter = "*", bool verbose = false)
        {
            return _Client.ExecuteAsync<List<AssetResponse>>("listassets", 0, assetFilter, verbose);
        }

        public Task<JsonRpcResponse<string>> SubscribeAsync(string assetName, bool rescan)
        {
            return _Client.ExecuteAsync<string>("subscribe", 0, assetName, rescan);
        }

        public JsonRpcResponse<string> Subscribe(string assetName, bool rescan)
        {
            return _Client.Execute<string>("subscribe", 0, assetName, rescan);
        }

        public Task<JsonRpcResponse<string>> UnsubscribeAsync(string assetName, bool rescan)
        {
            return _Client.ExecuteAsync<string>("unsubscribe", 0, assetName, rescan);
        }

        public JsonRpcResponse<string> Unsubscribe(string assetName, bool rescan)
        {
            return _Client.Execute<string>("unsubscribe", 0, assetName, rescan);
        }

        public Task<JsonRpcResponse<List<ListAssetTransactionsResponse>>> ListAssetTransactions(string assetName, bool verbose)
        {
            return _Client.ExecuteAsync<List<ListAssetTransactionsResponse>>("listassettransactions", 0, assetName, verbose);
        }

        public Task<JsonRpcResponse<List<ListAssetTransactionsResponse>>> ListAssetTransactions(string assetName, bool verbose, int count, int start, bool localOrdering)
        {
            return _Client.ExecuteAsync<List<ListAssetTransactionsResponse>>("listassettransactions", 0, assetName, verbose, count, start, localOrdering);
        }

        public Task<JsonRpcResponse<ListAssetTransactionsResponse>> GetAssetTransactionAsync(string assetName, string txId, bool verbose = true)
        {
            return _Client.ExecuteAsync<ListAssetTransactionsResponse>("getassettransaction", 0, assetName, txId, verbose);
        }
        
        public JsonRpcResponse<string> Send(string toAddress, string assetName, int amount, string comment = null, string commentTo = null)
        {
            var asset = new Dictionary<string, object>();
            asset[assetName] = amount;
            return _Client.Execute<string>("send", 0, toAddress, asset, comment ?? string.Empty, commentTo ?? string.Empty);
        }
        public Task<JsonRpcResponse<string>> SendAsync(string toAddress, string assetName, int amount, string comment = null, string commentTo = null)
        {
            var asset = new Dictionary<string, object>();
            asset[assetName] = amount;
            return _Client.ExecuteAsync<string>("send", 0, toAddress, asset, comment ?? string.Empty, commentTo ?? string.Empty);
        }

        public JsonRpcResponse<string> SendAsset(string toAddress, string assetName, int amount, int nativeAmount = 0, string comment = null, string commentTo = null)
        {
            var asset = new Dictionary<string, object>();
            asset[assetName] = amount;
            return _Client.Execute<string>("sendasset", 0, toAddress, asset, amount, nativeAmount, comment ?? string.Empty, commentTo ?? string.Empty);
        }
        public Task<JsonRpcResponse<string>> SendAssetAsync(string toAddress, string assetName, int amount, int nativeAmount = 0, string comment = null, string commentTo = null)
        {
            var asset = new Dictionary<string, object>();
            asset[assetName] = amount;
            return _Client.ExecuteAsync<string>("sendasset", 0, toAddress, asset, amount, nativeAmount, comment ?? string.Empty, commentTo ?? string.Empty);
        }

        public Task<JsonRpcResponse<string>> SendAssetFromAsync(string fromAddress, string toAddress, string assetName, decimal quantity, int nativeAmount = 0, string comment = null, string commentTo = null)
        {
            return _Client.ExecuteAsync<string>("sendassetfrom", 0, fromAddress, toAddress, assetName, quantity, nativeAmount, comment ?? string.Empty, commentTo ?? string.Empty);
        }

        public JsonRpcResponse<string> SendAssetFrom(string fromAddress, string toAddress, string assetName, decimal quantity, int nativeAmount = 0, string comment = null, string commentTo = null)
        {
            return _Client.Execute<string>("sendassetfrom", 0, fromAddress, toAddress, assetName, quantity, nativeAmount, comment ?? string.Empty, commentTo ?? string.Empty);
        }

        public JsonRpcResponse<string> SendFrom(string fromAddress, string toAddress, int amount, string comment = null, string commentTo = null)
        {
            return _Client.Execute<string>("sendfrom", 0, toAddress, comment ?? string.Empty, commentTo ?? string.Empty);
        }

        public Task<JsonRpcResponse<string>> SendFromAsync(string fromAddress, string toAddress, int amount, string comment = null, string commentTo = null)
        {
            return _Client.ExecuteAsync<string>("sendfrom", 0, toAddress, comment ?? string.Empty, commentTo ?? string.Empty);
        }

        public JsonRpcResponse<string> SendWithData(string address, decimal amount, byte[] dataHex)
        {
            return _Client.Execute<string>("sendwithdata", 0, address, amount, Util.Utility.FormatHex(dataHex));
        }
        public Task<JsonRpcResponse<string>> SendWithDataAsync(string address, decimal amount, byte[] dataHex)
        {
            return _Client.ExecuteAsync<string>("sendwithdata", 0, address, amount, Util.Utility.FormatHex(dataHex));
        }

        public JsonRpcResponse<string> SendWithDataFrom(string fromAddress, string toAddress, decimal amount, byte[] dataHex)
        {
            return _Client.Execute<string>("sendwithdatafrom", 0, fromAddress, toAddress, amount, Util.Utility.FormatHex(dataHex));
        }
        public Task<JsonRpcResponse<string>> SendWithDataFromAsync(string fromAddress, string toAddress, decimal amount, byte[] dataHex)
        {
            return _Client.ExecuteAsync<string>("sendwithdatafrom", 0, fromAddress, toAddress, amount, Util.Utility.FormatHex(dataHex));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromAddress"></param>
        /// <param name="toAddress"></param>
        /// <param name="assetmovement"> { assetidentifier: "", quantity : 1}</param>
        /// <param name="dataHex"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> SendWithDataFrom(string fromAddress, string toAddress, Dictionary<string, int> assetmovement, byte[] dataHex)
        {
            return _Client.Execute<string>("sendwithdatafrom", 0, fromAddress, toAddress, assetmovement, Util.Utility.FormatHex(dataHex));
        }

        public Task<JsonRpcResponse<string>> SendWithDataFromAsync(string fromAddress, string toAddress, Dictionary<string,int> assetmovement, byte[] dataHex)
        {
            return _Client.ExecuteAsync<string>("sendwithdatafrom", 0, fromAddress, toAddress, assetmovement, Util.Utility.FormatHex(dataHex));
        }

    }
}
