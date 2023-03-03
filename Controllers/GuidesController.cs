using compras.Service;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace compras.Controllers
{
    public class GuidesController  : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ActionResult GetGuides()
        {

            GuideService service = new GuideService();
            return View(service.getGuides());
        }

    }
}