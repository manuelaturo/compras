using compras.BD;
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

            List<CoustomerReportComedorRS> response = new List<CoustomerReportComedorRS>();
            List<ReportComedor> responseDAO = new List<ReportComedor>();
            ReportDAO report = new ReportDAO();
            //responseDAO = report.GetReportsEventoAndSalas();
            responseDAO.AddRange(report.GetReportsComedor());
            replaceNameComedor(responseDAO);
            response = assemblerRs(responseDAO);
            return response;
        }
        public void replaceNameComedor(List<ReportComedor> responseDAO)
        {
            responseDAO.ForEach(x =>
            {
                if (x.comedor.Equals("1"))
                {
                    x.comedor = "Comedor 1";
                }else  if (x.comedor.Equals("2"))
                    {
                        x.comedor = "Comedor 2";
                }
                else if (x.comedor.Equals("3"))
                {
                    x.comedor = "Comedor 3";
                }
            });
        }
        public List<CoustomerReportComedorRS> assemblerRs(List<ReportComedor> responseDAO)
        {
            List<CoustomerReportComedorRS> comedorRs = new List<CoustomerReportComedorRS>();
            comedorRs = responseDAO.ConvertAll(x => new CoustomerReportComedorRS(x.image, x.name,
             x.lastName, x.numEmploye, x.date
                ));
            return comedorRs;
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