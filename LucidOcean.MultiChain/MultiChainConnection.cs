/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
namespace LucidOcean.MultiChain
{
    public class MultiChainConnection
    {
        public string Hostname { get; set; } = "localhost";
        public int Port { get; set; } = 8000;
        public bool UseSsl { get; set; }
        public string ChainName { get; set; }
        public string ChainKey { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string RootNodeAddress { get; set; }
        public string BurnAddress { get; set; }
    }
}
