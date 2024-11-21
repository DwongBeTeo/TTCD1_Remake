using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT2_TDD_2210900097_Remake.Areas.TDDAdmin.Controllers
{
    public class AdminDashboardController : Controller
    {
        // GET: TDDAdmin/AdminDashboard
        public ActionResult Index()
        {
            ViewBag.Layout = "~/Areas/TDDAdmin/Views/Shared/_Layout.cshtml";
            return View();
        }
    }
}