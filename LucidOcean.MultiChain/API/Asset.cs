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
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace LucidOcean.MultiChain.API
{
    /// <summary>
    /// API for Asset commands
    /// </summary>
    public class Asset
    {
        MultiChainClient _Client = null;

        internal Asset(MultiChainClient client)
        {
            _Client = client;
        }

        /// <summary>
        /// Creates a new asset on the blockchain, sending the initial qty units to address. To create an asset with the default behavior, use an asset name only for name|params. For more control, use an object such as {"name":"asset1","open":true}. If open is true then additional units can be issued in future by the same key which signed the original issuance, via the issuemore or issuemorefrom command. The smallest transactable unit is given by units, e.g. 0.01. If the chain uses a native currency, you can send some with the new asset using the native-amount parameter. Returns the txid of the issuance transaction. For more information, see native assets.
        /// </summary>
        /// <param name="issueAddress"></param>
        /// <param name="assetName"></param>
        /// <param name="quantity"></param>
        /// <param name="units"></param>
        /// <param name="metaData"></param>
        /// <param name="nativeAmount"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <param name="startBlock"></param>
        /// <param name="endBlock"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> Issue(string issueAddress, object assetName, int quantity, decimal units, [Optional]object metaData, decimal nativeAmount = 0, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            if (metaData == null)
                return _Client.Execute<string>("issue", 0, issueAddress, assetName, quantity, units, nativeAmount);
            else
                return _Client.Execute<string>("issue", 0, issueAddress, assetName, quantity, units, nativeAmount, metaData);
        }
        
        /// <summary>
        /// Creates a new asset on the blockchain, sending the initial qty units to address. To create an asset with the default behavior, use an asset name only for name|params. For more control, use an object such as {"name":"asset1","open":true}. If open is true then additional units can be issued in future by the same key which signed the original issuance, via the issuemore or issuemorefrom command. The smallest transactable unit is given by units, e.g. 0.01. If the chain uses a native currency, you can send some with the new asset using the native-amount parameter. Returns the txid of the issuance transaction. For more information, see native assets.
        /// </summary>
        /// <param name="issueAddress"></param>
        /// <param name="assetName"></param>
        /// <param name="quantity"></param>
        /// <param name="units"></param>
        /// <param name="metaData"></param>
        /// <param name="nativeAmount"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <param name="startBlock"></param>
        /// <param name="endBlock"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> IssueAsync(string issueAddress, object assetName, int quantity, decimal units, object metaData = null, decimal nativeAmount = 0, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            if (metaData == null)
                return _Client.ExecuteAsync<string>("issue", 0, issueAddress, assetName, quantity, units, nativeAmount);
            else
                return _Client.ExecuteAsync<string>("issue", 0, issueAddress, assetName, quantity, units, nativeAmount, metaData);
        }

      

        /// <summary>
        /// This works like issue, but with control over the from-address used to issue the asset. It is useful if the node has multiple addresses with issue permissions.
        /// </summary>
        /// <param name="fromAddress"></param>
        /// <param name="toAddress"></param>
        /// <param name="assetName"></param>
        /// <param name="quantity"></param>
        /// <param name="units"></param>
        /// <param name="nativeAmount"></param>
        /// <param name="metaData"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <param name="startBlock"></param>
        /// <param name="endBlock"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> IssueFrom(string fromAddress, string toAddress, object assetName, int quantity, decimal units, decimal nativeAmount, [Optional]object metaData, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            if (metaData == null)
                return _Client.Execute<string>("issuefrom", 0, fromAddress, toAddress, assetName, quantity, units, nativeAmount);
            else
                return _Client.Execute<string>("issuefrom", 0, fromAddress, toAddress, assetName, quantity, units, nativeAmount, metaData);
        }

        /// <summary>
        /// This works like issue, but with control over the from-address used to issue the asset. It is useful if the node has multiple addresses with issue permissions.
        /// </summary>
        /// <param name="fromAddress"></param>
        /// <param name="toAddress"></param>
        /// <param name="assetName"></param>
        /// <param name="quantity"></param>
        /// <param name="units"></param>
        /// <param name="metaData"></param>
        /// <param name="nativeAmount"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <param name="startBlock"></param>
        /// <param name="endBlock"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> IssueFromAsync(string fromAddress, string toAddress, object assetName, int quantity, decimal units, [Optional]object metaData, decimal nativeAmount = 0, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            if (metaData == null)
                return _Client.ExecuteAsync<string>("issuefrom", 0, fromAddress, toAddress, assetName, quantity, units);
            else
                return _Client.ExecuteAsync<string>("issuefrom", 0, fromAddress, toAddress, assetName, quantity, units, metaData);
        }

        /// <summary>
        /// Issues qty additional units of asset, sending them to address. The asset can be specified using its name, ref or issuance txid – see native assets for more information. If the chain uses a native currency, you can send some with the new asset units using the native-amount parameter. Any custom fields will be attached to the new issuance event, and not affect the original values (use listassets with verbose=true to see both sets). Returns the txid of the issuance transaction.
        /// </summary>
        /// <param name="fromAddress"></param>
        /// <param name="assetName"></param>
        /// <param name="quantity"></param>
        /// <param name="metaData"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> IssueMore(string fromAddress, object assetName, int quantity, [Optional]object metaData)
        {
            if (metaData == null)
                return _Client.Execute<string>("issuemore", 0, fromAddress, assetName, quantity, metaData);
            else
                return _Client.Execute<string>("issuemore", 0, fromAddress, assetName, quantity, metaData);
        }

        /// <summary>
        /// Issues qty additional units of asset, sending them to address. The asset can be specified using its name, ref or issuance txid – see native assets for more information. If the chain uses a native currency, you can send some with the new asset units using the native-amount parameter. Any custom fields will be attached to the new issuance event, and not affect the original values (use listassets with verbose=true to see both sets). Returns the txid of the issuance transaction.
        /// </summary>
        /// <param name="fromAddress"></param>
        /// <param name="assetName"></param>
        /// <param name="quantity"></param>
        /// <param name="metaData"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> IssueMoreAsync(string fromAddress, object assetName, int quantity, [Optional]object metaData)
        {
            if (metaData == null)
                return _Client.ExecuteAsync<string>("issuemore", 0, fromAddress, assetName, quantity, metaData);
            else
                return _Client.ExecuteAsync<string>("issuemore", 0, fromAddress, assetName, quantity, metaData);
        }

        /// <summary>
        /// This works like issuemore, but with control over the from-address used.
        /// </summary>
        /// <param name="fromAddress"></param>
        /// <param name="toAddress"></param>
        /// <param name="assetName"></param>
        /// <param name="quantity"></param>
        /// <param name="nativeAmount"></param>
        /// <param name="metaData"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> IssueMoreFrom(string fromAddress, string toAddress, object assetName, int quantity, decimal nativeAmount, [Optional]object metaData)
        {
            if (metaData == null)
                return _Client.Execute<string>("issuefrom", 0, fromAddress, toAddress, assetName, quantity, nativeAmount);
            else
                return _Client.Execute<string>("issuefrom", 0, fromAddress, toAddress, assetName, quantity, nativeAmount, metaData);
        }

        /// <summary>
        /// This works like issuemore, but with control over the from-address used.
        /// </summary>
        /// <param name="fromAddress"></param>
        /// <param name="toAddress"></param>
        /// <param name="assetName"></param>
        /// <param name="quantity"></param>
        /// <param name="nativeAmount"></param>
        /// <param name="metaData"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> IssueMoreFromAsync(string fromAddress, string toAddress, object assetName, int quantity, decimal nativeAmount, [Optional]object metaData)
        {
            if (metaData == null)
                return _Client.ExecuteAsync<string>("issuemorefrom", 0, fromAddress, toAddress, assetName, quantity, nativeAmount);
            else
                return _Client.ExecuteAsync<string>("issuemorefrom", 0, fromAddress, toAddress, assetName, quantity, nativeAmount, metaData);
        }

        /// <summary>
        /// Returns information about assets issued on the blockchain. Pass an asset name, ref or issuance txid in assets to retrieve information about one asset only, an array thereof for multiple assets, or * for all assets. In assets with multiple issuance events, the top-level issuetxid and details fields refer to the first issuance only – set verbose to true for details about each of the individual issuances. Use count and start to retrieve part of the list only, with negative start values (like the default) indicating the most recently created assets. Extra fields are shown for assets to which this node is subscribed.
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<List<AssetResponse>> ListAssets()
        {
            return _Client.Execute<List<AssetResponse>>("listassets", 0, "*", false);
        }

        /// <summary>
        /// Returns information about assets issued on the blockchain. Pass an asset name, ref or issuance txid in assets to retrieve information about one asset only, an array thereof for multiple assets, or * for all assets. In assets with multiple issuance events, the top-level issuetxid and details fields refer to the first issuance only – set verbose to true for details about each of the individual issuances. Use count and start to retrieve part of the list only, with negative start values (like the default) indicating the most recently created assets. Extra fields are shown for assets to which this node is subscribed.
        /// </summary>
        /// <param name="assetFilter"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public JsonRpcResponse<List<AssetResponse>> ListAssets(string assetFilter = "*", bool verbose = false)
        {
            return _Client.Execute<List<AssetResponse>>("listassets", 0, assetFilter, verbose);
        }

        /// <summary>
        /// Returns information about assets issued on the blockchain. Pass an asset name, ref or issuance txid in assets to retrieve information about one asset only, an array thereof for multiple assets, or * for all assets. In assets with multiple issuance events, the top-level issuetxid and details fields refer to the first issuance only – set verbose to true for details about each of the individual issuances. Use count and start to retrieve part of the list only, with negative start values (like the default) indicating the most recently created assets. Extra fields are shown for assets to which this node is subscribed.
        /// </summary>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<AssetResponse>>> ListAssetsAsync()
        {
            return _Client.ExecuteAsync<List<AssetResponse>>("listassets", 0, "*", false);
        }

        /// <summary>
        /// Returns information about assets issued on the blockchain. Pass an asset name, ref or issuance txid in assets to retrieve information about one asset only, an array thereof for multiple assets, or * for all assets. In assets with multiple issuance events, the top-level issuetxid and details fields refer to the first issuance only – set verbose to true for details about each of the individual issuances. Use count and start to retrieve part of the list only, with negative start values (like the default) indicating the most recently created assets. Extra fields are shown for assets to which this node is subscribed.
        /// </summary>
        /// <param name="assetFilter"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<AssetResponse>>> ListAssetsAsync(string assetFilter = "*", bool verbose = false)
        {
            return _Client.ExecuteAsync<List<AssetResponse>>("listassets", 0, assetFilter, verbose);
        }

        /// <summary>
        /// Instructs the node to start tracking one or more asset(s) or stream(s). These are specified using a name, ref or creation/issuance txid, or for multiple items, an array thereof. If rescan is true, the node will reindex all items from when the assets and/or streams were created, as well as those in other subscribed entities. Returns null if successful. See also the autosubscribe runtime parameter.
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="rescan"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> SubscribeAsync(string assetName, bool rescan = true)
        {
            return _Client.ExecuteAsync<string>("subscribe", 0, assetName, rescan);
        }

        /// <summary>
        /// Instructs the node to start tracking one or more asset(s) or stream(s). These are specified using a name, ref or creation/issuance txid, or for multiple items, an array thereof. If rescan is true, the node will reindex all items from when the assets and/or streams were created, as well as those in other subscribed entities. Returns null if successful. See also the autosubscribe runtime parameter.
        /// </summary>
        /// <param name="assetNames"></param>
        /// <param name="rescan"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> SubscribeAsync(string[] assetNames, bool rescan = true)
        {
            return _Client.ExecuteAsync<string>("subscribe", 0, assetNames, rescan);
        }

        /// <summary>
        /// Instructs the node to start tracking one or more asset(s) or stream(s). These are specified using a name, ref or creation/issuance txid, or for multiple items, an array thereof. If rescan is true, the node will reindex all items from when the assets and/or streams were created, as well as those in other subscribed entities. Returns null if successful. See also the autosubscribe runtime parameter.
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="rescan"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> Subscribe(string assetName, bool rescan = true)
        {
            return _Client.Execute<string>("subscribe", 0, assetName, rescan);
        }

        /// <summary>
        /// Instructs the node to start tracking one or more asset(s) or stream(s). These are specified using a name, ref or creation/issuance txid, or for multiple items, an array thereof. If rescan is true, the node will reindex all items from when the assets and/or streams were created, as well as those in other subscribed entities. Returns null if successful. See also the autosubscribe runtime parameter.
        /// </summary>
        /// <param name="assetNames"></param>
        /// <param name="rescan"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> Subscribe(string[] assetNames, bool rescan = true)
        {
            return _Client.Execute<string>("subscribe", 0, assetNames, rescan);
        }

        /// <summary>
        /// Instructs the node to stop tracking one or more asset(s) or stream(s). Assets or streams are specified using a name, ref or creation/issuance txid, or for multiple items, an array thereof.
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> UnsubscribeAsync(string assetName)
        {
            return _Client.ExecuteAsync<string>("unsubscribe", 0, assetName);
        }

        /// <summary>
        /// Instructs the node to stop tracking one or more asset(s) or stream(s). Assets or streams are specified using a name, ref or creation/issuance txid, or for multiple items, an array thereof.
        /// </summary>
        /// <param name="assetNames"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> UnsubscribeAsync(string[] assetNames)
        {
            return _Client.ExecuteAsync<string>("unsubscribe", 0, new object[] { assetNames });
        }

        /// <summary>
        /// Instructs the node to stop tracking one or more asset(s) or stream(s). Assets or streams are specified using a name, ref or creation/issuance txid, or for multiple items, an array thereof.
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> Unsubscribe(string assetName)
        {
            return _Client.Execute<string>("unsubscribe", 0, assetName);
        }

        /// <summary>
        /// Instructs the node to stop tracking one or more asset(s) or stream(s). Assets or streams are specified using a name, ref or creation/issuance txid, or for multiple items, an array thereof.
        /// </summary>
        /// <param name="assetNames"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> Unsubscribe(string[] assetNames)
        {
            return _Client.Execute<string>("unsubscribe", 0, new object[] { assetNames });
        }

        /// <summary>
        /// Lists transactions involving asset, passed as an asset name, ref or issuance txid, to which the node must be subscribed. Set verbose to true for additional information about each transaction. Use count and start to retrieve part of the list only, with negative start values (like the default) indicating the most recent items. Set local-ordering to true to order transactions by when first seen by this node, rather than their order in the chain.
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<ListAssetTransactionsResponse>>> ListAssetTransactions(string assetName, bool verbose)
        {
            return _Client.ExecuteAsync<List<ListAssetTransactionsResponse>>("listassettransactions", 0, assetName, verbose);
        }

        /// <summary>
        /// Lists transactions involving asset, passed as an asset name, ref or issuance txid, to which the node must be subscribed. Set verbose to true for additional information about each transaction. Use count and start to retrieve part of the list only, with negative start values (like the default) indicating the most recent items. Set local-ordering to true to order transactions by when first seen by this node, rather than their order in the chain.
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="verbose"></param>
        /// <param name="count"></param>
        /// <param name="start"></param>
        /// <param name="localOrdering"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<ListAssetTransactionsResponse>>> ListAssetTransactions(string assetName, bool verbose, int count, int start, bool localOrdering)
        {
            return _Client.ExecuteAsync<List<ListAssetTransactionsResponse>>("listassettransactions", 0, assetName, verbose, count, start, localOrdering);
        }

        /// <summary>
        /// Retrieves a specific transaction txid involving asset, passed as an asset name, ref or issuance txid, to which the node must be subscribed. Set verbose to true for additional information about the transaction.
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="txId"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<ListAssetTransactionsResponse>> GetAssetTransactionAsync(string assetName, string txId, bool verbose = true)
        {
            return _Client.ExecuteAsync<ListAssetTransactionsResponse>("getassettransaction", 0, assetName, txId, verbose);
        }

        /// <summary>
        /// Sends one or more assets to address, returning the txid. In Bitcoin Core, the amount field is the quantity of the bitcoin currency. For MultiChain, an {"asset":qty, ...} object can be used for amount, in which each asset is an asset name, ref or issuance txid, and each qty is the quantity of that asset to send (see native assets). Use "" as the asset inside this object to specify a quantity of the native blockchain currency. See also sendasset for sending a single asset and sendfrom to control the address whose funds are used.
        /// </summary>
        /// <param name="toAddress"></param>
        /// <param name="assetName"></param>
        /// <param name="amount"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <returns></returns>
        public Util.JsonRpcResponse<string> Send(string toAddress, string assetName, int amount, string comment = null, string commentTo = null)
        {
            var asset = new Dictionary<string, object>();
            asset[assetName] = amount;
            return _Client.Execute<string>("send", 0, toAddress, asset, comment ?? string.Empty, commentTo ?? string.Empty);
        }

        /// <summary>
        /// Sends one or more assets to address, returning the txid. In Bitcoin Core, the amount field is the quantity of the bitcoin currency. For MultiChain, an {"asset":qty, ...} object can be used for amount, in which each asset is an asset name, ref or issuance txid, and each qty is the quantity of that asset to send (see native assets). Use "" as the asset inside this object to specify a quantity of the native blockchain currency. See also sendasset for sending a single asset and sendfrom to control the address whose funds are used.
        /// </summary>
        /// <param name="toAddress"></param>
        /// <param name="assetName"></param>
        /// <param name="amount"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> SendAsync(string toAddress, string assetName, int amount, string comment = null, string commentTo = null)
        {
            var asset = new Dictionary<string, object>();
            asset[assetName] = amount;
            return _Client.ExecuteAsync<string>("send", 0, toAddress, asset, comment ?? string.Empty, commentTo ?? string.Empty);
        }

        /// <summary>
        /// Sends qty of asset to address, returning the txid. The asset can be specified using its name, ref or issuance txid – see native assets for more information. See also sendassetfrom to control the address whose funds are used, send for sending multiple assets in one transaction, and sendfrom to combine both of these.
        /// </summary>
        /// <param name="toAddress"></param>
        /// <param name="assetName"></param>
        /// <param name="amount"></param>
        /// <param name="nativeAmount"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> SendAsset(string toAddress, string assetName, int amount, int nativeAmount = 0, string comment = null, string commentTo = null)
        {
            var asset = new Dictionary<string, object>();
            asset[assetName] = amount;
            return _Client.Execute<string>("sendasset", 0, toAddress, asset, amount, nativeAmount, comment ?? string.Empty, commentTo ?? string.Empty);
        }

        /// <summary>
        /// Sends qty of asset to address, returning the txid. The asset can be specified using its name, ref or issuance txid – see native assets for more information. See also sendassetfrom to control the address whose funds are used, send for sending multiple assets in one transaction, and sendfrom to combine both of these.
        /// </summary>
        /// <param name="toAddress"></param>
        /// <param name="assetName"></param>
        /// <param name="amount"></param>
        /// <param name="nativeAmount"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> SendAssetAsync(string toAddress, string assetName, int amount, int nativeAmount = 0, string comment = null, string commentTo = null)
        {
            var asset = new Dictionary<string, object>();
            asset[assetName] = amount;
            return _Client.ExecuteAsync<string>("sendasset", 0, toAddress, asset, amount, nativeAmount, comment ?? string.Empty, commentTo ?? string.Empty);
        }

        /// <summary>
        /// This works like sendasset, but with control over the from-address whose funds are used. Any change from the transaction is sent back to from-address. See also sendfrom for sending multiple assets in one transaction.
        /// </summary>
        /// <param name="fromAddress"></param>
        /// <param name="toAddress"></param>
        /// <param name="assetName"></param>
        /// <param name="quantity"></param>
        /// <param name="nativeAmount"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> SendAssetFromAsync(string fromAddress, string toAddress, string assetName, decimal quantity, int nativeAmount = 0, string comment = null, string commentTo = null)
        {
            return _Client.ExecuteAsync<string>("sendassetfrom", 0, fromAddress, toAddress, assetName, quantity, nativeAmount, comment ?? string.Empty, commentTo ?? string.Empty);
        }

        /// <summary>
        /// This works like sendasset, but with control over the from-address whose funds are used. Any change from the transaction is sent back to from-address. See also sendfrom for sending multiple assets in one transaction.
        /// </summary>
        /// <param name="fromAddress"></param>
        /// <param name="toAddress"></param>
        /// <param name="assetName"></param>
        /// <param name="quantity"></param>
        /// <param name="nativeAmount"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> SendAssetFrom(string fromAddress, string toAddress, string assetName, decimal quantity, int nativeAmount = 0, string comment = null, string commentTo = null)
        {
            return _Client.Execute<string>("sendassetfrom", 0, fromAddress, toAddress, assetName, quantity, nativeAmount, comment ?? string.Empty, commentTo ?? string.Empty);
        }

        /// <summary>
        /// This works like send, but with control over the from-address whose funds are used. Any change from the transaction is sent back to from-address.
        /// </summary>
        /// <param name="fromAddress"></param>
        /// <param name="toAddress"></param>
        /// <param name="amount"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> SendFrom(string fromAddress, string toAddress, int amount, string comment = null, string commentTo = null)
        {
            return _Client.Execute<string>("sendfrom", 0, toAddress, comment ?? string.Empty, commentTo ?? string.Empty);
        }

        /// <summary>
        /// This works like send, but with control over the from-address whose funds are used. Any change from the transaction is sent back to from-address.
        /// </summary>
        /// <param name="fromAddress"></param>
        /// <param name="toAddress"></param>
        /// <param name="amount"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> SendFromAsync(string fromAddress, string toAddress, int amount, string comment = null, string commentTo = null)
        {
            return _Client.ExecuteAsync<string>("sendfrom", 0, toAddress, comment ?? string.Empty, commentTo ?? string.Empty);
        }

        /// <summary>
        /// This works like send, but with an additional data-only transaction output. To include raw data, pass a data-hex hexadecimal string. To publish the data to a stream, pass an object {"for":stream,"key":"...","data":"..."} where stream is a stream name, ref or creation txid, the key is in text form, and the data is hexadecimal.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="amount"></param>
        /// <param name="dataHex"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> SendWithData(string address, decimal amount, byte[] dataHex)
        {
            return _Client.Execute<string>("sendwithdata", 0, address, amount, Util.Utility.FormatHex(dataHex));
        }

        /// <summary>
        /// This works like send, but with an additional data-only transaction output. To include raw data, pass a data-hex hexadecimal string. To publish the data to a stream, pass an object {"for":stream,"key":"...","data":"..."} where stream is a stream name, ref or creation txid, the key is in text form, and the data is hexadecimal.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="amount"></param>
        /// <param name="dataHex"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> SendWithDataAsync(string address, decimal amount, byte[] dataHex)
        {
            return _Client.ExecuteAsync<string>("sendwithdata", 0, address, amount, Util.Utility.FormatHex(dataHex));
        }

        /// <summary>
        /// This works like sendwithdata, but with control over the from-address whose funds are used. Any change from the transaction is sent back to from-address.
        /// </summary>
        /// <param name="fromAddress"></param>
        /// <param name="toAddress"></param>
        /// <param name="amount"></param>
        /// <param name="dataHex"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> SendWithDataFrom(string fromAddress, string toAddress, decimal amount, byte[] dataHex)
        {
            return _Client.Execute<string>("sendwithdatafrom", 0, fromAddress, toAddress, amount, Util.Utility.FormatHex(dataHex));
        }

        /// <summary>
        /// This works like sendwithdata, but with control over the from-address whose funds are used. Any change from the transaction is sent back to from-address.
        /// </summary>
        /// <param name="fromAddress"></param>
        /// <param name="toAddress"></param>
        /// <param name="amount"></param>
        /// <param name="dataHex"></param>
        /// <returns></returns>
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

        /// <summary>
        /// This works like sendwithdata, but with control over the from-address whose funds are used. Any change from the transaction is sent back to from-address.
        /// </summary>
        /// <param name="fromAddress"></param>
        /// <param name="toAddress"></param>
        /// <param name="assetmovement"></param>
        /// <param name="dataHex"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> SendWithDataFromAsync(string fromAddress, string toAddress, Dictionary<string,int> assetmovement, byte[] dataHex)
        {
            return _Client.ExecuteAsync<string>("sendwithdatafrom", 0, fromAddress, toAddress, assetmovement, Util.Utility.FormatHex(dataHex));
        }

    }
}
