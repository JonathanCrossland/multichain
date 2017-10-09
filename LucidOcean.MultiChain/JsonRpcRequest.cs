/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LucidOcean.MultiChain
{
    public class JsonRpcRequest : IJsonRpcRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, object> Values { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public JsonRpcRequest()
        {
            this.Values = new Dictionary<string, object>();
        }

        /// <summary>
        /// RPC Method
        /// </summary>
        [JsonProperty("method")]
        public string Method
        {
            get
            {
                return this.GetValue<string>("method");
            }
            set
            {
                this.SetValue("method", value);
            }
        }

        /// <summary>
        /// RPC params
        /// </summary>
        [JsonProperty("params")]
        public object[] Params
        {
            get
            {
                return this.GetValue<object[]>("params");
            }
            set
            {
                this.SetValue("params", value);
            }
        }

        /// <summary>
        /// RPC Id 
        /// </summary>
        [JsonProperty("id")]
        public int Id
        {
            get
            {
                return this.GetValue<int>("id");
            }
            set
            {
                this.SetValue("id", value);
            }
        }


        private void SetValue(string name, object value)
        {
            this.Values[name] = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public T GetValue<T>(string name)
        {
            if (this.Values.ContainsKey(name))
                return (T)this.Values[name];
            else
                return default(T);
       }

    }
}
