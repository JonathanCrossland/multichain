/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/

namespace LucidOcean.MultiChain.Explorer.Data
{
    public static class ExplorerSettings
    {
        public static MultiChainConnection Connection = null;
        public static int PageSize = 50;

        static ExplorerSettings()
        {

            Connection = new MultiChainConnection()
            {
                Hostname = "192.168.192.1",
                Port = 9264,
                Username = "multichainrpc",
                Password = "Ajm2VNf2MdGK8ULQiMGg7Q4C8Jy2XBJrzNJ5y9Mj7qaS",
                ChainName = "LucidOceanTestChain",
                BurnAddress = "1XXXXXXXYBXXXXXXd3XXXXXXZ1XXXXXXXeChio",
                RootNodeAddress = "1JZpnFNYw3zQbyGKqve7rDWben3PuC2g3bhwBP"
            };
        }
    }
}
