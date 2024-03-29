﻿/*=====================================================================
Authors: Jonathan Crossland et al. See github for contributors
Copyright © 2024 Jonathan Crossland (trading as Lucid Ocean). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0

The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain.Exceptions;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LucidOcean.MultiChain.Util
{
    public class JsonRpcClient
    {
        private MultiChainConnection _Connection = new MultiChainConnection();
        public event EventHandler<EventArgs<JsonRpcRequest>> Executing;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        public JsonRpcClient(MultiChainConnection connection)
        {
            _Connection = connection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="chainName"></param>
        public JsonRpcClient(string hostname, int port, string username, string password, string chainName)
        {
            _Connection.Hostname = hostname;
            _Connection.Port = port;
            _Connection.Username = username;
            _Connection.Password = password;
            _Connection.ChainName = chainName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method"></param>
        /// <param name="id"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JsonRpcResponse<T> Execute<T>(string method, int id, params object[] args)
        {
            JsonRpcResponse<T> response = new JsonRpcResponse<T>();
            Task.Run(async () =>
            {
                response = await ExecuteAsync<T>(method, id, args);
            }).GetAwaiter().GetResult();

            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method"></param>
        /// <param name="id"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public async Task<JsonRpcResponse<T>> ExecuteAsync<T>(string method, int id, params object[] args)
        {
            Trace.WriteLine($"RPC: {method} {id}");
            for (int i = 0; i < args.Length; i++)
            {
                Trace.WriteLine($"RPC Param {i + 1}: {args[i]}");
            }
            var ps = new JsonRpcRequest()
            {
                Method = method,
                Params = args,
                Id = id
            };

            this.OnExecuting(new EventArgs<JsonRpcRequest>(ps));

            var jsonOut = JsonConvert.SerializeObject(ps.Values);
            var url = this.ServiceUrl;
            try
            {
                string jsonRet = null;
                JsonRpcResponse<T> ret = null;

                using (var client = HttpClientHelper.GetHttpClientWithBasicAuth(url, _Connection.Username, _Connection.Password))
                {
                    var httpContent = new StringContent(jsonOut, Encoding.UTF8, "application/json-rpc");
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        RequestUri = new Uri(url),
                        Content = httpContent,
                    };

                    var result = await client.SendAsync(request);
                    jsonRet = await result.Content.ReadAsStringAsync();
                }

                try
                {
                    ret = JsonConvert.DeserializeObject<JsonRpcResponse<T>>(jsonRet);
                }
                catch (Exception jsonEx)
                {
                    Trace.WriteLine(jsonEx);
                    var errorResponse = JsonConvert.DeserializeObject<JsonRpcErrorResponse>(jsonRet);
                    throw new JsonRpcException(errorResponse.Error);
                }

                ret.Raw = jsonRet;

                if (ret.Error == null && !ret.Id.HasValue && ret.Result == null)
                {
                    ret = null;
                }

                return ret;
            }
            catch (Exception ex) when (!(ex is JsonRpcException))
            {
                var nEXt = ex;
                string errormsg = null;
                while (nEXt != null)
                {
                    if (nEXt is WebException)
                    {
                        var webEx = (WebException)nEXt;
                        if (webEx.Response != null)
                        {
                            HttpWebResponse resp = (HttpWebResponse)webEx.Response;
                            if (resp.StatusCode !=  HttpStatusCode.OK)
                            {
                                if (resp.ContentType != "application/json")  throw ex;
                            }

                            using (var stream = webEx.Response.GetResponseStream())
                                errormsg = new StreamReader(stream).ReadToEnd();
                        }
                        if (errormsg == null) throw ex;
                        if (errormsg == "Forbidden") throw ex;

                        break;
                    }

                    nEXt = nEXt.InnerException;
                }

                var errorResponse = JsonConvert.DeserializeObject<JsonRpcErrorResponse>(errormsg);
                throw new JsonRpcException(errorResponse.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnExecuting(EventArgs<JsonRpcRequest> e)
        {
            if (this.Executing != null)
                this.Executing(this, e);
        }

        /// <summary>
        /// 
        /// </summary>
        private string ServiceUrl
        {
            get
            {
                var protocol = "https";
                if (!(_Connection.UseSsl))
                    protocol = "http";
                return string.Format("{0}://{1}:{2}/", protocol, _Connection.Hostname, _Connection.Port);
            }
        }

        private ICredentials GetCredentials()
        {
            if (this.HasCredentials)
                return new NetworkCredential(_Connection.Username, _Connection.Password);
            else
                return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool HasCredentials
        {
            get
            {
                return !(string.IsNullOrEmpty(_Connection.Username));
            }
        }
    }
}
