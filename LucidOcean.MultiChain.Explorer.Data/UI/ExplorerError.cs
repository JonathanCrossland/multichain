/*=====================================================================
Authors: Jonathan Crossland et al. See github for contributors
Copyright © 2024 Jonathan Crossland (trading as Lucid Ocean). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0

The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using System.Collections.Generic;

namespace LucidOcean.MultiChain.Explorer.Data.UI
{
    /// <summary>
    /// UI Helper model for displaying errors and informational messages in the explorer
    /// </summary>
    public class ExplorerError
    {
        public ExplorerError() { }      

        public List<string> Errors { get; set; } = new List<string>();
        public List<string> Success { get; set; } = new List<string>();
        public List<string> Info { get; set; } = new List<string>();
        public List<string> Warnings { get; set; } = new List<string>();
    }
}
