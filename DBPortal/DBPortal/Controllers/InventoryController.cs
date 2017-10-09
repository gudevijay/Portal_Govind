using DBPortal.Core;
using DBPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBPortal.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
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
    }
}