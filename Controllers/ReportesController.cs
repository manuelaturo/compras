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

            List<compras.Models.CoustomerReportComedorRS> reportComedorRs = new List<compras.Models.CoustomerReportComedorRS>();
            ReportService reportService = new ReportService();
            reportComedorRs = reportService.getGeneralReportComedor(datesD, datesH);
            return View(reportComedorRs);
        }
        public ActionResult SearchSalarbyDate(string datesD, string datesH)
        {
            List<compras.Models.CoustomerReportComedorRS> reportComedorRs = new List<compras.Models.CoustomerReportComedorRS>();
            ReportService reportService = new ReportService();
            reportService.getGeneralReportSalas(datesD, datesH);
            return View(reportComedorRs);
        }
        public ActionResult SearchEventobyDate(string datesD, string datesH)
        {
            List<compras.Models.CoustomerReportComedorRS> reportComedorRs = new List<compras.Models.CoustomerReportComedorRS>();
            ReportService reportService = new ReportService();
            reportComedorRs = reportService.getGeneralReportEventos(datesD, datesH);

            return View(reportComedorRs);
        }
    }
}