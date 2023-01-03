using compras.Service;
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
            ReportService reportService = new ReportService();
            return View(reportService.getGeneralReportComedor(datesD, datesH));
        }
        public ActionResult SearchSalarbyDate(string datesD, string datesH)
        {
            ReportService reportService = new ReportService();
            return View(reportService.getGeneralReportSalas(datesD, datesH));
        }
        public ActionResult SearchEventobyDate(string datesD, string datesH)
        {
            ReportService reportService = new ReportService();
            return View(reportService.getGeneralReportEventos(datesD, datesH));
        }
    }
}