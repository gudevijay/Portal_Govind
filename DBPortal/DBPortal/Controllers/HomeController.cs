﻿using DBPortal.Core;
using DBPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBPortal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Inventory()
        {
            var inventory = new List<InventoryModel>();

            var invData = DBServices.GetTblView("exce sampleprocedure");

            if (invData.Count > 0)
            {
                inventory = DBServices.ToList<InventoryModel>(invData);
            }

            return View(inventory);
        }

        public ActionResult SearchInventory(string searchWord)
        {
            var inventory = new List<InventoryModel>();

            var invData = DBServices.GetTblView("exce sampleprocedure(" + searchWord + ")");

            if (invData.Count > 0)
            {
                inventory = DBServices.ToList<InventoryModel>(invData);
            }

            return PartialView("_InvData", inventory);
        }
    }
}