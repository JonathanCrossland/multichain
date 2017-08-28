/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using System.Diagnostics;

namespace LucidOcean.MultiChain
{
    public static class ResponseLogger<T>
    {
        public static void Log(JsonRpcResponse<T> response)
        {
            if (response == null)
            {
                Debug.WriteLine("Response is NULL");
                return;
            }
            response.IsValidResponse();

            if (response.Result is System.Collections.IEnumerable)
            {
                
                foreach (var item in response.Result as System.Collections.IEnumerable)
                {
                    if (item is char) break;
                    Debug.WriteLine(item);
                }
            }
            else
            {
                Debug.WriteLine(response.Result);
            }
            
            Debug.WriteLine(response.Raw);
            Debug.WriteLine("");
        }
    }
}
