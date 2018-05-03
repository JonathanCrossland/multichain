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
using System.Threading.Tasks;

namespace LucidOcean.MultiChain.API
{
    /// <summary>
    /// Stream Related API calls
    /// </summary>
    public class Stream
    {
        internal MultiChainClient _Client = null;

        internal Stream(MultiChainClient client)
        {
            _Client = client;
        }

        /// <summary>
        /// Creates a new stream on the blockchain called name. Pass the value "stream" in the type parameter (the create API can also be used to create upgrades). If open is true then anyone with global send permissions can publish to the stream, otherwise publishers must be explicitly granted per-stream write permissions. Returns the txid of the transaction creating the stream.
        /// Creates a new (as yet unapproved) upgrade on the blockchain called name. Pass the value "upgrade" in the type parameter (the create API can also be used to create streams) and false for the open parameter. For now, only the protocol version can be upgraded, for example from 10008 to 10009. You can also pass {"protocol-version":100xx,"startblock":yy} to create an upgrade that will only be applied after a certain block height. Note that an address requires both admin and create permissions to create an upgrade. Returns the txid of the transaction creating the upgrade.
        /// </summary>
        /// <param name="streamName"></param>
        /// <param name="metadata"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> Create(string streamName, object metadata)
        {
            return _Client.Execute<string>("create", 0, "stream", streamName, false, metadata);
        }

        /// <summary>
        /// Creates a new stream on the blockchain called name. Pass the value "stream" in the type parameter (the create API can also be used to create upgrades). If open is true then anyone with global send permissions can publish to the stream, otherwise publishers must be explicitly granted per-stream write permissions. Returns the txid of the transaction creating the stream.
        /// Creates a new (as yet unapproved) upgrade on the blockchain called name. Pass the value "upgrade" in the type parameter (the create API can also be used to create streams) and false for the open parameter. For now, only the protocol version can be upgraded, for example from 10008 to 10009. You can also pass {"protocol-version":100xx,"startblock":yy} to create an upgrade that will only be applied after a certain block height. Note that an address requires both admin and create permissions to create an upgrade. Returns the txid of the transaction creating the upgrade.
        /// </summary>
        /// <param name="streamName"></param>
        /// <param name="metadata"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> CreateAsync(string streamName, object metadata)
        {
            return _Client.ExecuteAsync<string>("create", 0, "stream", streamName, false, metadata);
        }

        /// <summary>
        /// Creates a new stream on the blockchain called name. Pass the value "stream" in the type parameter (the create API can also be used to create upgrades). If open is true then anyone with global send permissions can publish to the stream, otherwise publishers must be explicitly granted per-stream write permissions. Returns the txid of the transaction creating the stream.
        /// Creates a new (as yet unapproved) upgrade on the blockchain called name. Pass the value "upgrade" in the type parameter (the create API can also be used to create streams) and false for the open parameter. For now, only the protocol version can be upgraded, for example from 10008 to 10009. You can also pass {"protocol-version":100xx,"startblock":yy} to create an upgrade that will only be applied after a certain block height. Note that an address requires both admin and create permissions to create an upgrade. Returns the txid of the transaction creating the upgrade.
        /// </summary>
        /// <param name="streamName"></param>
        /// <param name="open"></param>
        /// <param name="metadata"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> Create(string streamName, bool open, object metadata)
        {
            return _Client.Execute<string>("create", 0, "stream", streamName, open, metadata);
        }

        /// <summary>
        /// Creates a new stream on the blockchain called name. Pass the value "stream" in the type parameter (the create API can also be used to create upgrades). If open is true then anyone with global send permissions can publish to the stream, otherwise publishers must be explicitly granted per-stream write permissions. Returns the txid of the transaction creating the stream.
        /// Creates a new (as yet unapproved) upgrade on the blockchain called name. Pass the value "upgrade" in the type parameter (the create API can also be used to create streams) and false for the open parameter. For now, only the protocol version can be upgraded, for example from 10008 to 10009. You can also pass {"protocol-version":100xx,"startblock":yy} to create an upgrade that will only be applied after a certain block height. Note that an address requires both admin and create permissions to create an upgrade. Returns the txid of the transaction creating the upgrade.
        /// </summary>
        /// <param name="streamName"></param>
        /// <param name="open"></param>
        /// <param name="metadata"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> CreateAsync(string streamName, bool open, object metadata)
        {
            return _Client.ExecuteAsync<string>("create", 0, "stream", streamName, open, metadata);
        }

        /// <summary>
        /// This works like create, but with control over the from-address used to create the upgrade. It is useful if the node has multiple addresses with both admin and create permissions.
        /// </summary>
        /// <param name="fromAddress"></param>
        /// <param name="streamName"></param>
        /// <param name="open"></param>
        /// <param name="metadata"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> CreateFrom(string fromAddress, string streamName, bool open, object metadata)
        {
            return _Client.Execute<string>("createfrom", 0, fromAddress, "stream", streamName, open, metadata);
        }

        /// <summary>
        /// This works like create, but with control over the from-address used to create the upgrade. It is useful if the node has multiple addresses with both admin and create permissions.
        /// </summary>
        /// <param name="fromAddress"></param>
        /// <param name="streamName"></param>
        /// <param name="open"></param>
        /// <param name="metadata"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> CreateFromAsync(string fromAddress, string streamName, bool open, object metadata)
        {
            return _Client.ExecuteAsync<string>("createfrom", 0, fromAddress, "stream", streamName, open, metadata);
        }

        /// <summary>
        /// Publishes an item in stream, passed as a stream name, ref or creation txid, with key provided in text form and data-hex in hexadecimal.
        /// </summary>
        /// <param name="streamName"></param>
        /// <param name="key"></param>
        /// <param name="dataHex"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> Publish(string streamName, string key, byte[] dataHex)
        {
            return _Client.Execute<string>("publish", 0, streamName, key, Util.Utility.FormatHex(dataHex));
        }

        /// <summary>
        /// Publishes an item in stream, passed as a stream name, ref or creation txid, with key provided in text form and data-hex in hexadecimal.
        /// </summary>
        /// <param name="streamName"></param>
        /// <param name="key"></param>
        /// <param name="dataHex"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> PublishAsync(string streamName, string key, byte[] dataHex)
        {
            return _Client.ExecuteAsync<string>("publish", 0, streamName, key, Util.Utility.FormatHex(dataHex));
        }

        /// <summary>
        /// This works like publish, but publishes the item from from-address. It is useful if a stream is open or the node has multiple addresses with per-stream write permissions.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="streamName"></param>
        /// <param name="key"></param>
        /// <param name="dataHex"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> PublishFrom(string address, string streamName, string key, byte[] dataHex)
        {
            return _Client.Execute<string>("publishfrom", 0, address, streamName, key, Util.Utility.FormatHex(dataHex));
        }

        /// <summary>
        /// This works like publish, but publishes the item from from-address. It is useful if a stream is open or the node has multiple addresses with per-stream write permissions.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="streamName"></param>
        /// <param name="key"></param>
        /// <param name="dataHex"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> PublishFromAsync(string address, string streamName, string key, byte[] dataHex)
        {
            return _Client.ExecuteAsync<string>("publishfrom", 0, address, streamName, key, Util.Utility.FormatHex(dataHex));
        }

        /// <summary>
        /// Returns information about streams created on the blockchain. Pass a stream name, ref or creation txid in streams to retrieve information about one stream only, an array thereof for multiple streams, or * for all streams. Use count and start to retrieve part of the list only, with negative start values (like the default) indicating the most recently created streams. Extra fields are shown for streams to which this node has subscribed.
        /// </summary>
        /// <param name="streamName"></param>
        /// <param name="verbose"></param>
        /// <param name="count"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public JsonRpcResponse<List<ListStreamResponse>> ListStreams(string streamName = "*", bool verbose = true, int count = int.MaxValue, int start = int.MinValue)
        {
            return _Client.Execute<List<ListStreamResponse>>("liststreams", 0, streamName, verbose, count, start);
        }

        /// <summary>
        /// Returns information about streams created on the blockchain. Pass a stream name, ref or creation txid in streams to retrieve information about one stream only, an array thereof for multiple streams, or * for all streams. Use count and start to retrieve part of the list only, with negative start values (like the default) indicating the most recently created streams. Extra fields are shown for streams to which this node has subscribed.
        /// </summary>
        /// <param name="streamName"></param>
        /// <param name="verbose"></param>
        /// <param name="count"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<ListStreamResponse>>> ListStreamsAsync(string streamName = "*", bool verbose = true, int count = int.MaxValue, int start = int.MinValue)
        {
            return _Client.ExecuteAsync<List<ListStreamResponse>>("liststreams", 0, streamName, verbose, count, start);
        }

        /// <summary>
        /// Retrieves a specific item with txid from stream, passed as a stream name, ref or creation txid, to which the node must be subscribed. Set verbose to true for additional information about the item’s transaction. If an item’s data is larger than the maxshowndata runtime parameter, it will be returned as an object whose fields can be used with gettxoutdata.
        /// </summary>
        /// <param name="streamName"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public JsonRpcResponse<ListStreamResponse> GetStreamItem(string streamName = "*", bool verbose = true)
        {
            return _Client.Execute<ListStreamResponse>("getstreamitem", 0, streamName, verbose);
        }

        /// <summary>
        /// Retrieves a specific item with txid from stream, passed as a stream name, ref or creation txid, to which the node must be subscribed. Set verbose to true for additional information about the item’s transaction. If an item’s data is larger than the maxshowndata runtime parameter, it will be returned as an object whose fields can be used with gettxoutdata.
        /// </summary>
        /// <param name="streamName"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<ListStreamResponse>> GetStreamItemAsync(string streamName = "*", bool verbose = true)
        {
            return _Client.ExecuteAsync<ListStreamResponse>("getstreamitem", 0, streamName, verbose);
        }

        /// <summary>
        /// Lists items in stream, passed as a stream name, ref or creation txid. Set verbose to true for additional information about each item’s transaction. Use count and start to retrieve part of the list only, with negative start values (like the default) indicating the most recent items. Set local-ordering to true to order items by when first seen by this node, rather than their order in the chain. If an item’s data is larger than the maxshowndata runtime parameter, it will be returned as an object whose fields can be used with gettxoutdata.
        /// </summary>
        /// <param name="streamName"></param>
        /// <param name="verbose"></param>
        /// <param name="count"></param>
        /// <param name="start"></param>
        /// <param name="localOrdering"></param>
        /// <returns></returns>
        public JsonRpcResponse<List<ListStreamItemsResponse>> ListStreamItems(string streamName, bool verbose = true, int? count = null, int? start = null, bool? localOrdering = null)
        {
            if (count != null && start != null && localOrdering != null)
            {
                return _Client.Execute<List<ListStreamItemsResponse>>("liststreamitems", 0, streamName, verbose, count.Value, start.Value, localOrdering.Value);
            }

            if (count != null && start != null)
            {
                return _Client.Execute<List<ListStreamItemsResponse>>("liststreamitems", 0, streamName, verbose, count.Value, start.Value);
            }

            if (count != null)
            {
                return _Client.Execute<List<ListStreamItemsResponse>>("liststreamitems", 0, streamName, verbose, count.Value);
            }

            return _Client.Execute<List<ListStreamItemsResponse>>("liststreamitems", 0, streamName, verbose);
        }

        /// <summary>
        /// Lists items in stream, passed as a stream name, ref or creation txid. Set verbose to true for additional information about each item’s transaction. Use count and start to retrieve part of the list only, with negative start values (like the default) indicating the most recent items. Set local-ordering to true to order items by when first seen by this node, rather than their order in the chain. If an item’s data is larger than the maxshowndata runtime parameter, it will be returned as an object whose fields can be used with gettxoutdata.
        /// </summary>
        /// <param name="streamName"></param>
        /// <param name="verbose"></param>
        /// <param name="count"></param>
        /// <param name="start"></param>
        /// <param name="localOrdering"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<ListStreamItemsResponse>>> ListStreamItemsAsync(string streamName, bool verbose = true, int? count = null, int? start = null, bool? localOrdering = null)
        {
            if (count != null && start != null && localOrdering != null)
            {
                return _Client.ExecuteAsync<List<ListStreamItemsResponse>>("liststreamitems", 0, streamName, verbose, count.Value, start.Value, localOrdering.Value);
            }

            if (count != null && start != null)
            {
                return _Client.ExecuteAsync<List<ListStreamItemsResponse>>("liststreamitems", 0, streamName, verbose, count.Value, start.Value);
            }

            if (count != null)
            {
                return _Client.ExecuteAsync<List<ListStreamItemsResponse>>("liststreamitems", 0, streamName, verbose, count.Value);
            }

            return _Client.ExecuteAsync<List<ListStreamItemsResponse>>("liststreamitems", 0, streamName, verbose);
        }

        /// <summary>
        /// This works like liststreamitems, but listing items with the given key only.
        /// </summary>
        /// <param name="streamName"></param>
        /// <param name="key"></param>
        /// <param name="verbose"></param>
        /// <param name="count"></param>
        /// <param name="start"></param>
        /// <param name="localordering"></param>
        /// <returns></returns>
        public JsonRpcResponse<List<ListStreamItemsResponse>> ListStreamKeyItems(string streamName, string key, bool verbose = true, int count = 10, int start = 1, bool localordering = false)
        {
            return _Client.Execute<List<ListStreamItemsResponse>>("liststreamkeyitems", 0, streamName, key, verbose, count, start, localordering);
        }

        /// <summary>
        /// This works like liststreamitems, but listing items with the given key only.
        /// </summary>
        /// <param name="streamName"></param>
        /// <param name="key"></param>
        /// <param name="verbose"></param>
        /// <param name="count"></param>
        /// <param name="start"></param>
        /// <param name="localordering"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<ListStreamItemsResponse>>> ListStreamKeyItemsAsync(string streamName, string key, bool verbose = true, int count = 10, int start = 1, bool localordering = false)
        {
            return _Client.ExecuteAsync<List<ListStreamItemsResponse>>("liststreamkeyitems", 0, streamName, key, verbose, count, start, localordering);
        }

        /// <summary>
        /// Provides information about keys in stream, passed as a stream name, ref or creation txid. Pass a single key in keys to retrieve information about one key only, pass an array for multiple keys, or * for all keys. Set verbose to true to include information about the first and last item with each key shown. See liststreamitems for details of the count, start and local-ordering parameters.
        /// </summary>
        /// <param name="streamName"></param>
        /// <param name="keys"></param>
        /// <param name="verbose"></param>
        /// <param name="count"></param>
        /// <param name="start"></param>
        /// <param name="localOrdering"></param>
        /// <returns></returns>
        public JsonRpcResponse<List<ListStreamKeyResponse>> ListStreamKeys(string streamName, List<string> keys, bool verbose = false, int count = int.MaxValue, int start = 0, bool localOrdering = false)
        {
            return _Client.Execute<List<ListStreamKeyResponse>>("liststreamkeys", 0, streamName, keys, verbose, count, start, localOrdering);
        }

        /// <summary>
        /// Provides information about keys in stream, passed as a stream name, ref or creation txid. Pass a single key in keys to retrieve information about one key only, pass an array for multiple keys, or * for all keys. Set verbose to true to include information about the first and last item with each key shown. See liststreamitems for details of the count, start and local-ordering parameters.
        /// </summary>
        /// <param name="streamName"></param>
        /// <param name="keys"></param>
        /// <param name="verbose"></param>
        /// <param name="count"></param>
        /// <param name="start"></param>
        /// <param name="localOrdering"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<ListStreamKeyResponse>>> ListStreamKeysAsync(string streamName, List<string> keys, bool verbose = false, int count = int.MaxValue, int start = 0, bool localOrdering = false)
        {
            return _Client.ExecuteAsync<List<ListStreamKeyResponse>>("liststreamkeys", 0, streamName, keys, verbose, count, start, localOrdering);
        }

        /// <summary>
        /// This works like liststreamitems, but listing items published by the given address only.
        /// </summary>
        /// <param name="streamName"></param>
        /// <param name="address"></param>
        /// <param name="verbose"></param>
        /// <param name="count"></param>
        /// <param name="start"></param>
        /// <param name="localOrdering"></param>
        /// <returns></returns>
        public JsonRpcResponse<List<string>> ListStreamPublisherItems(string streamName, string address, bool verbose = false, int count = int.MaxValue, int start = 0, bool localOrdering = false)
        {
            return _Client.Execute<List<string>>("liststreampublisheritems", 0, streamName, address, verbose, count, start, localOrdering);
        }

        /// <summary>
        /// This works like liststreamitems, but listing items published by the given address only.
        /// </summary>
        /// <param name="streamName"></param>
        /// <param name="address"></param>
        /// <param name="verbose"></param>
        /// <param name="count"></param>
        /// <param name="start"></param>
        /// <param name="localOrdering"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<string>>> ListStreamPublisherItemsAsync(string streamName, string address, bool verbose = false, int count = int.MaxValue, int start = 0, bool localOrdering = false)
        {
            return _Client.ExecuteAsync<List<string>>("liststreampublisheritems", 0, streamName, address, verbose, count, start, localOrdering);
        }

        /// <summary>
        /// This works like liststreamitems, but listing items published by the given address only.
        /// </summary>
        /// <param name="streamName"></param>
        /// <param name="address"></param>
        /// <param name="verbose"></param>
        /// <param name="count"></param>
        /// <param name="start"></param>
        /// <param name="localOrdering"></param>
        /// <returns></returns>
        public JsonRpcResponse<List<string>> ListStreamPublishers(string streamName, List<string> address, bool verbose = false, int count = int.MaxValue, int start = 0, bool localOrdering = false)
        {
            return _Client.Execute<List<string>>("liststreampublishers", 0, streamName, address, verbose, count, start, localOrdering);
        }

        /// <summary>
        /// This works like liststreamitems, but listing items published by the given address only.
        /// </summary>
        /// <param name="streamName"></param>
        /// <param name="address"></param>
        /// <param name="verbose"></param>
        /// <param name="count"></param>
        /// <param name="start"></param>
        /// <param name="localOrdering"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<string>>> ListStreamPublishersAsync(string streamName, List<string> address, bool verbose = false, int count = int.MaxValue, int start = 0, bool localOrdering = false)
        {
            return _Client.ExecuteAsync<List<string>>("liststreampublishers", 0, streamName, address, verbose, count, start, localOrdering);
        }
        
    }
}
