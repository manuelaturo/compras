using compras.Models;
using compras.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace compras.Service
{
    public class ReportService
    {
        public List<CoustomerReportComedorRS> getGeneralReport()
        {
            DateTime dateTime = new DateTime();
            List<CoustomerReportComedorRS> response = new List<CoustomerReportComedorRS>();

            CoustomerReportComedorRS comedorReport = new CoustomerReportComedorRS();

            
            return response;
        }


        public List<CoustomerReportComedorRS> getCoustomReport(CoustomerReportComedorRQ report)
        {
            DateTime dateTime = new DateTime();
            List<CoustomerReportComedorRS> response = new List<CoustomerReportComedorRS>();

            CoustomerReportComedorRS comedorReport = new CoustomerReportComedorRS();

           
            return response;
        }
    }
}