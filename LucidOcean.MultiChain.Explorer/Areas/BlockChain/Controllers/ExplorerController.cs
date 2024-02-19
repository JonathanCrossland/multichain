/*=====================================================================
Authors: Jonathan Crossland et al. See github for contributors
Copyright © 2024 Jonathan Crossland (trading as Lucid Ocean). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0

The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain.Explorer.Data;
using LucidOcean.MultiChain.Explorer.Data.Statistics;
using LucidOcean.MultiChain.Explorer.Data.UI;
using LucidOcean.MultiChain.Response;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LucidOcean.MultiChain.Explorer.Areas.BlockChain.Controllers
{
    public class ExplorerController : Controller
    {
        Blocks _blocks = new Blocks();
        Transactions _transaction = new Transactions();
        Address _address = new Address();

        /// <summary>
        /// Shows all blocks in the BlockChain with a simple paging filter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Index(int id = 0)
        {
            int totalblocks = _blocks.GetBlockCount();
            List<BlockResponse> blocks = _blocks.Get(id);
            if (id == 0)
            {
                id = totalblocks;
            }

            int next = id + ExplorerSettings.PageSize;
            int prev = id - ExplorerSettings.PageSize;

            ViewBag.IndexPrev = null;
            if (prev < 0)
            {
                prev = 0;
            }
            ViewBag.IndexNext = null;
            if (next > totalblocks)
            {
                next = 0;
            }
            ViewBag.IndexPrev = prev;
            ViewBag.IndexNext = next;

            return View(blocks);
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            SearchResult result = BlockChainHelper.GetSearchAction(search);
            if (result.Action == "Index")
            {
                ExplorerError error = new ExplorerError();
                error.Errors.Add("No records found. Try again or contact us for assistance");

                TempData["Errors"] = error;
            }
            return RedirectToAction(result.Action, result.Controller, result.RouteValue);
        }

        /// <summary>
        /// Get BlockChain Statistics for the current node the explorer is inspecting
        /// </summary>
        /// <returns></returns>
        public ActionResult GetStats()
        {
            BlockChainStatistics bcs = new BlockChainStatistics();
            bcs = bcs.Get();

            return View("Parts/_BlockChainStats", bcs);
        }

        /// <summary>
        /// Get block information for a given hash or height
        /// </summary>
        /// <param name="id">blockhash or height</param>
        /// <returns></returns>
        public ActionResult Block(string id)
        {
            BlockResponse b = _blocks.Get(id);
            if (b == null)
            {
                ExplorerError error = new ExplorerError();
                error.Errors.Add("Block not found. Try again or contact us for assistance");

                TempData["Errors"] = error;                
                return RedirectToAction("Index");
            }

            return View(b);
        }

        /// <summary>
        /// Render transaction details from a given transaction hash
        /// </summary>
        /// <param name="id">Transaction hash</param>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult RenderTransaction(string id)
        {
            RawTransactionResponse vtr = _transaction.Get(id);
            TransactionDetail td = new TransactionDetail();
            List<TransactionDetail> list = td.Get(vtr);
            return View("Parts/txDetails", list);
        }

        /// <summary>
        /// Get transaction details for a given transaction hash
        /// </summary>
        /// <param name="id">Transaction Hash</param>
        /// <returns></returns>
        public ActionResult Tx(string id)
        {
            RawTransactionResponse vtr = _transaction.Get(id);

            if (vtr == null)
            {
                ExplorerError error = new ExplorerError();
                error.Errors.Add("Transaction not found. Try again or contact us for assistance");

                TempData["Errors"] = error;
                return RedirectToAction("Index");
            }

            return View(vtr);
        }

        /// <summary>
        /// This will import the address details then show all transactions for the particular address
        /// </summary>
        /// <param name="id">Wallet Address</param>
        /// <returns></returns>
        public ActionResult Address(string id)
        {
            List<AddressTransactionResponse> items = _address.Get(id);
            if (items == null)
            {
                ExplorerError error = new ExplorerError();
                error.Errors.Add("Address not found. Try again or contact us for assistance");

                TempData["Errors"] = error;                
                return RedirectToAction("Index");
            }

            AddressDetail ad = new AddressDetail();
            ad.Address = id;
            ad.Transactions.AddRange(items);
            return View(ad);
        }

        public ActionResult Streams()
        {
            return View();
        }
    }

}