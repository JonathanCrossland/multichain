using System.Threading.Tasks;
using LucidOcean.MultiChain.Util;

namespace LucidOcean.MultiChain.API.V2
{
    public static partial class StreamExtensions
    {
        /// <summary>
        /// Publishes an item in stream, passed as a stream name, ref or creation txid, with array of keys provided in text form and data-hex in hexadecimal.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="streamName"></param>
        /// <param name="keys"></param>
        /// <param name="dataHex"></param>
        /// <returns></returns>
        public static JsonRpcResponse<string> Publish(this Stream stream, string streamName, string[] keys, byte[] dataHex)
        {
            return stream._Client.Execute<string>("publish", 0, streamName, keys, Util.Utility.FormatHex(dataHex));
        }

        /// <summary>
        /// Publishes an item in stream, passed as a stream name, ref or creation txid, with array of keys provided in text form and data-hex in hexadecimal.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="streamName"></param>
        /// <param name="keys"></param>
        /// <param name="dataHex"></param>
        /// <returns></returns>
        public static Task<JsonRpcResponse<string>> PublishAsync(this Stream stream, string streamName, string[] keys, byte[] dataHex)
        {
            return stream._Client.ExecuteAsync<string>("publish", 0, streamName, keys, Util.Utility.FormatHex(dataHex));
        }

        /// <summary>
        /// Publishes an item in stream, passed as a stream name, ref or creation txid, with array of keys provided in text form and data in textual form.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="streamName"></param>
        /// <param name="keys"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static JsonRpcResponse<string> Publish(this Stream stream, string streamName, string[] keys, string text)
        {
            return stream._Client.Execute<string>("publish", 0, streamName, keys, new { text });
        }

        /// <summary>
        /// Publishes an item in stream, passed as a stream name, ref or creation txid, with array of keys provided in text form and data in textual form.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="streamName"></param>
        /// <param name="keys"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static Task<JsonRpcResponse<string>> PublishAsync(this Stream stream, string streamName, string[] keys, string text)
        {
            return stream._Client.ExecuteAsync<string>("publish", 0, streamName, keys, new { text });
        }

        /// <summary>
        /// Publishes an item in stream, passed as a stream name, ref or creation txid, with array of keys provided in text form and JSON data.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="streamName"></param>
        /// <param name="keys"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public static JsonRpcResponse<string> Publish(this Stream stream, string streamName, string[] keys, object json)
        {
            return stream._Client.Execute<string>("publish", 0, streamName, keys, new { json });
        }

        /// <summary>
        /// Publishes an item in stream, passed as a stream name, ref or creation txid, with array of keys provided in text form and JSON data.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="streamName"></param>
        /// <param name="keys"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public static Task<JsonRpcResponse<string>> PublishAsync(this Stream stream, string streamName, string[] keys, object json)
        {
            return stream._Client.ExecuteAsync<string>("publish", 0, streamName, keys, new { json });
        }
    }
}
