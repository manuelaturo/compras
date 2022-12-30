﻿using compras.Service;
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


        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult Autheticacion(string usuario, string password)

        {
            Service.AutenticacionService service = new Service.AutenticacionService();
            bool response = service.checkUsuario(usuario, password);
            if (response)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Home/Index");
            }
           
        }
        public ActionResult About()

        {
            ReportService comedorService = new ReportService();
            return View(comedorService.getGeneralReport());
    }
        
        public ActionResult ReportesComedor()

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

