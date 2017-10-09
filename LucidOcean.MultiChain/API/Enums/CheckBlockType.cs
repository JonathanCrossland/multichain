/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/

namespace LucidOcean.MultiChain.API.Enums
{
    public enum CheckBlockTypeParam
    {
        ReadFromDisk = 0,
        EnsureEachBlockIsValid = 1,
        CheckCanReadUndoFiles = 2,
        TestEachBlockUndo = 3,
        ReconnectUndoneBlocks = 4
    }
}
