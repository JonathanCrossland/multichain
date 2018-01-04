using System.Threading.Tasks;
using LucidOcean.MultiChain.Util;

namespace LucidOcean.MultiChain.API.V2
{
    public static partial class StreamExtensions
    {
        /// <summary>
        /// This works like publish, but publishes the item from from-address. It is useful if a stream is open or the node has multiple addresses with per-stream write permissions.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="address"></param>
        /// <param name="streamName"></param>
        /// <param name="keys"></param>
        /// <param name="dataHex"></param>
        /// <returns></returns>
        public static JsonRpcResponse<string> PublishFrom(this Stream stream, string address, string streamName, string[] keys, byte[] dataHex)
        {
            return stream._Client.Execute<string>("publishfrom", 0, address, streamName, keys, Util.Utility.FormatHex(dataHex));
        }

        /// <summary>
        /// This works like publish, but publishes the item from from-address. It is useful if a stream is open or the node has multiple addresses with per-stream write permissions.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="address"></param>
        /// <param name="streamName"></param>
        /// <param name="keys"></param>
        /// <param name="dataHex"></param>
        /// <returns></returns>
        public static Task<JsonRpcResponse<string>> PublishFromAsync(this Stream stream, string address, string streamName, string[] keys, byte[] dataHex)
        {
            return stream._Client.ExecuteAsync<string>("publishfrom", 0, address, streamName, keys, Util.Utility.FormatHex(dataHex));
        }

        /// <summary>
        /// This works like publish, but publishes the item from from-address. It is useful if a stream is open or the node has multiple addresses with per-stream write permissions.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="address"></param>
        /// <param name="streamName"></param>
        /// <param name="keys"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static JsonRpcResponse<string> PublishFrom(this Stream stream, string address, string streamName, string[] keys, string text)
        {
            return stream._Client.Execute<string>("publishfrom", 0, address, streamName, keys, new { text });
        }

        /// <summary>
        /// This works like publish, but publishes the item from from-address. It is useful if a stream is open or the node has multiple addresses with per-stream write permissions.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="address"></param>
        /// <param name="streamName"></param>
        /// <param name="keys"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static Task<JsonRpcResponse<string>> PublishFromAsync(this Stream stream, string address, string streamName, string[] keys, string text)
        {
            return stream._Client.ExecuteAsync<string>("publishfrom", 0, address, streamName, keys, new { text });
        }

        /// <summary>
        /// This works like publish, but publishes the item from from-address. It is useful if a stream is open or the node has multiple addresses with per-stream write permissions.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="address"></param>
        /// <param name="streamName"></param>
        /// <param name="keys"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public static JsonRpcResponse<string> PublishFrom(this Stream stream, string address, string streamName, string[] keys, object json)
        {
            return stream._Client.Execute<string>("publishfrom", 0, address, streamName, keys, new { json });
        }

        /// <summary>
        /// This works like publish, but publishes the item from from-address. It is useful if a stream is open or the node has multiple addresses with per-stream write permissions.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="address"></param>
        /// <param name="streamName"></param>
        /// <param name="keys"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public static Task<JsonRpcResponse<string>> PublishFromAsync(this Stream stream, string address, string streamName, string[] keys, object json)
        {
            return stream._Client.ExecuteAsync<string>("publishfrom", 0, address, streamName, keys, new { json });
        }
    }
}
