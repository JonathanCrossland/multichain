using LucidOcean.MultiChain.Util;
using System.Diagnostics;

namespace MultiChainTests
{
    public static class ResponseLogger<T>
    {
        public static void Log(T value)
        {
            Debug.WriteLine(value);
            Debug.WriteLine("");
        }

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