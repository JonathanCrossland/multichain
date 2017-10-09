/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using System;

namespace LucidOcean.MultiChain.API.Enums
{
    [Flags]
    public enum BlockChainPermission
    {
        Connect = 1,
        Send = 2,
        Receive = 4,
        Issue = 8,
        Mine = 16,
        Admin = 32,
        Activate = 64,
        Write = 128,
    }
}
