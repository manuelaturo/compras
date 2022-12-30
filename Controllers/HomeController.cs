﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace compras.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }
        public ActionResult ReportesComedor(string usuario, string password)
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
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}