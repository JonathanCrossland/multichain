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
    public class Stream
    {
        MultiChainClient _Client = null;

        internal Stream(MultiChainClient client)
        {
            _Client = client;
        }

        public JsonRpcResponse<string> Create(string streamName, object metadata)
        {
            return _Client.Execute<string>("create", 0, "stream", streamName, false, metadata);
        }

        public Task<JsonRpcResponse<string>> CreateAsync(string streamName, object metadata)
        {
            return _Client.ExecuteAsync<string>("create", 0, "stream", streamName, false, metadata);
        }
        public JsonRpcResponse<string> Create(string streamName, bool open, object metadata)
        {
            return _Client.Execute<string>("create", 0, "stream", streamName, open, metadata);
        }

        public Task<JsonRpcResponse<string>> CreateAsync(string streamName, bool open, object metadata)
        {
            return _Client.ExecuteAsync<string>("create", 0, "stream", streamName, open, metadata);
        }

        public JsonRpcResponse<string> CreateFrom(string fromAddress, string streamName, bool open, object metadata)
        {
            return _Client.Execute<string>("create", 0, "stream", fromAddress, streamName, open, metadata);
        }

        public Task<JsonRpcResponse<string>> CreateFromAsync(string fromAddress,string streamName, bool open, object metadata)
        {
            return _Client.ExecuteAsync<string>("create", 0, "stream", fromAddress, streamName, open, metadata);
        }

        public JsonRpcResponse<string> Publish(string streamName, string key, byte[] dataHex)
        {
            return _Client.Execute<string>("publish", 0, streamName, key, Util.Utility.FormatHex(dataHex));
        }

        public Task<JsonRpcResponse<string>> PublishAsync(string streamName, string key, byte[] dataHex)
        {
            return _Client.ExecuteAsync<string>("publish", 0, streamName, key, Util.Utility.FormatHex(dataHex));
        }

        public JsonRpcResponse<string> PublishFrom(string address, string streamName, string key, byte[] dataHex)
        {
            return _Client.Execute<string>("publishfrom", 0, address, streamName, key, Util.Utility.FormatHex(dataHex));
        }

        public Task<JsonRpcResponse<string>> PublishAsyncFrom(string address, string streamName, string key, byte[] dataHex)
        {
            return _Client.ExecuteAsync<string>("publishfrom", 0, address, streamName, key, Util.Utility.FormatHex(dataHex));
        }

        public JsonRpcResponse<List<ListStreamResponse>> ListStreams(string streamName = "*", bool verbose = true, int count = 0, int start = -1)
        {
            return _Client.Execute<List<ListStreamResponse>>("liststreams", 0, streamName, verbose, count, start);
        }

        public Task<JsonRpcResponse<List<ListStreamResponse>>> ListStreamsAsync(string streamName = "*", bool verbose = true, int count = 0, int start = -1)
        {
            return _Client.ExecuteAsync<List<ListStreamResponse>>("liststreams", 0, streamName, verbose, count, start);
        }

        public JsonRpcResponse<ListStreamResponse> GetStreamItem(string streamName = "*", bool verbose = true)
        {
            return _Client.Execute<ListStreamResponse>("getstreamitem", 0, streamName, verbose);
        }

        public Task<JsonRpcResponse<ListStreamResponse>> GetStreamItemAsync(string streamName = "*", bool verbose = true)
        {
            return _Client.ExecuteAsync<ListStreamResponse>("getstreamitem", 0, streamName, verbose);
        }

        public JsonRpcResponse<List<ListStreamItemsResponse>> ListStreamItems(string streamName, bool verbose = true, int count = 0, int start = -1, bool localOrdering = false)
        {
            return _Client.Execute<List<ListStreamItemsResponse>>("liststreamitems", 0, streamName, verbose);
        }

        public Task<JsonRpcResponse<List<ListStreamItemsResponse>>> ListStreamItemsAsync(string streamName, bool verbose = true, int count = 0, int start = -1, bool localOrdering = false)
        {
            return _Client.ExecuteAsync<List<ListStreamItemsResponse>>("liststreamitems", 0, streamName, verbose);
        }

        public JsonRpcResponse<List<ListStreamItemsResponse>> ListStreamKeyItems(string streamName, string key, bool verbose = true, int count = 10, int start = 1, bool localordering = false)
        {
            return _Client.Execute<List<ListStreamItemsResponse>>("liststreamkeyitems", 0, streamName, key, verbose, count, start, localordering);
        }

        public Task<JsonRpcResponse<List<ListStreamItemsResponse>>> ListStreamKeyItemsAsync(string streamName, string key, bool verbose = true, int count = 10, int start = 1, bool localordering = false)
        {
            return _Client.ExecuteAsync<List<ListStreamItemsResponse>>("liststreamkeyitems", 0, streamName, key, verbose, count, start, localordering);
        }
        
        //create
        //createfrom
        //publish
        //publishfrom
        //subscribe
        //unsubscribe
        //getstreamitem
        //gettxoutdata
        //liststreamblockitems
        //liststreamkeyitems
        //liststreamkeys
        //liststreamitems
        //liststreampublisheritems
        //liststreampublishers

    }
}
