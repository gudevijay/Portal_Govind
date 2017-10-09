using DBPortal.Core;
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
            DashboardModel model = new DashboardModel();

            model.Critical = new CriticalAlerts();
            model.otherAlerts = new OtherAlerts();
            model.SqlAlerts = new MySqlAlerts();
            model.SybaseAlerts = new SyBaseAlerts();

            return View(model);
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
        public ActionResult Quries()
        {

            return View();
        }

        public JsonResult GetServerNames(string env)
        {
            var results = DBServices.GetTblView("exce sampleprocedure(" + env + ")");
            var serverNames = DBServices.ToList<ServerNames>(results);
            return Json(serverNames, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetQueryResults(QueryResults model)
        {
            var inventory = new List<InventoryModel>();

            var invData = DBServices.GetTblView("exce sampleprocedure");

            if (invData.Count > 0)
            {
                inventory = DBServices.ToList<InventoryModel>(invData);
            }

            return PartialView("_QueryResults", inventory);
        }
    }
}