using compras.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace compras.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string usuario, string password)
        {
            return View();
        }

        public ActionResult Autheticacion(string usuario, string password)
        {
            Service.AutenticacionService service = new Service.AutenticacionService();
            bool response = service.checkUsuario(usuario, password);
            if (response)
            {
                return View("ReportesComedor");
            }
            else
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
            }

        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult About2()

        {
            ReportService comedorService = new ReportService();
            return View(comedorService.getGeneralReportSala());
        }
        public ActionResult About3()

        {
            ReportService comedorService = new ReportService();
            return View(comedorService.getGeneralReportEvento());
        }
        public ActionResult About()

        {
            ReportService comedorService = new ReportService();
            return View(comedorService.getGeneralReportSala());
        }

        public ActionResult ReportesComedor()
        {

            return View();
        }
        public ActionResult ComedorPrincipal()
        {

            return View();
        }

        public ActionResult Logout()
        {
            return View("Index");
        }
        public ActionResult About()
        {
            ReportService comedorService = new ReportService();
            return View(comedorService.getGeneralReport());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}