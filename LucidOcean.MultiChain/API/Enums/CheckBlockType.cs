/*=====================================================================
Authors: Jonathan Crossland et al. See github for contributors
Copyright © 2024 Jonathan Crossland (trading as Lucid Ocean). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0

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
