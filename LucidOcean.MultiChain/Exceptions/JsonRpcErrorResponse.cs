using Newtonsoft.Json;
using System;

namespace LucidOcean.MultiChain.Exceptions
{
    [Serializable]
    public class JsonRpcException : Exception
    {
        public JsonRpcException() { }
        public JsonRpcException(string message) : base(message) { }
        public JsonRpcException(JsonRpcError error) : this($"({error.Code}) {error.Message}", error) { }
        public JsonRpcException(string message, JsonRpcError response) : base(message) { Error = response; }
        public JsonRpcException(string message, JsonRpcError response, Exception inner) : base(message, inner) { Error = response; }
        public JsonRpcException(string message, Exception inner) : base(message, inner) { }

        protected JsonRpcException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public JsonRpcError Error { get; set; }
    }

    public class JsonRpcError
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class JsonRpcErrorResponse
    {
        [JsonProperty("error")]
        public JsonRpcError Error { get; set; }
    }
}
