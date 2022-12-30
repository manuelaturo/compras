using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace compras.Controllers
{
    public class ReportesController : Controller
    {
        // GET: Reportes
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SearchComedorbyDate(string datesD, string datesH)
        {
            var test = "";
            return null;
        }
    }
}