using log4net;
﻿using compras.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using compras.Models.Request;

namespace compras.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ActionResult Index(string usuario, string password)

        {
            string module = "Comedor";
            QuestionsService service = new QuestionsService();

            service.SendEmail(module);
            log.Info("inicio compras");
            return View();
        }

        public ActionResult Autheticacion(string usuario, string password)
        {
            Service.AutenticacionService service = new Service.AutenticacionService();
            bool response = service.checkUsuario(usuario, password);
            if (response)
            {
                //return View("ReportesComedor");
                return new HttpStatusCodeResult((int)HttpStatusCode.OK);
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

        public ActionResult ReportesSala()

        {
            ReportService comedorService = new ReportService();
            return View(comedorService.getGeneralReportSala());
        }
        public ActionResult ReportesEvento()

        {
            ReportService comedorService = new ReportService();
            return View(comedorService.getGeneralReportEvento());
        }



        public ActionResult ReportesComedor()
        {

            ReportService comedorService = new ReportService();
            return View(comedorService.getGeneralReport());
        } 

        public ActionResult ComedorPrincipal()
        {

            return View();
        }

        public ActionResult Logout()
        {
            return View("Index");
        }
        

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}