﻿using compras.BD;
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
        public List<CoustomerReportComedorRS> getGeneralReportSala()
        {

            List<CoustomerReportComedorRS> response = new List<CoustomerReportComedorRS>();
            List<ReportComedor> responseDAO = new List<ReportComedor>();
            ReportDAO report = new ReportDAO();
            responseDAO = report.GetReportsSalas();
            
            response = assemblerRs(responseDAO);
            replaceNameComedor(response);
            return response;
        }
        public List<CoustomerReportComedorRS> getGeneralReportEvento()
        {

            List<CoustomerReportComedorRS> response = new List<CoustomerReportComedorRS>();
            List<ReportComedor> responseDAO = new List<ReportComedor>();
            ReportDAO report = new ReportDAO();
            responseDAO = report.GetReportsEvento();
            
            response = assemblerRs(responseDAO);
            replaceNameComedor(response);
            return response;
        }

        public List<CoustomerReportComedorRS> getGeneralReport()
        {

            List<CoustomerReportComedorRS> response = new List<CoustomerReportComedorRS>();
            List<ReportComedor> responseDAO = new List<ReportComedor>();
            ReportDAO report = new ReportDAO();
            responseDAO = report.GetReportsComedor();
            //responseDAO.AddRange(report.GetReportsComedor());
            
            response = assemblerRs(responseDAO);
            replaceNameComedor(response);
            return response;
        }

        public List<CoustomerReportComedorRS> getGeneralReportComedor(string initDate, string endDate)
        {
            var dateInit = DateTime.Parse(initDate);
            var dateEnd = DateTime.Parse(endDate);

            List<CoustomerReportComedorRS> response = new List<CoustomerReportComedorRS>();
            List<ReportComedor> responseDAO = new List<ReportComedor>();
            ReportDAO report = new ReportDAO();
            responseDAO = report.GetReportsComedor(dateInit, dateEnd);
            //responseDAO.AddRange(report.GetReportsComedor());
           
            response = assemblerRs(responseDAO);
            replaceNameComedor(response);
            return response;
        }
        public List<CoustomerReportComedorRS> getGeneralReportSalas(string initDate, string endDate)
        {
            var dateInit = DateTime.Parse(initDate);
            var dateEnd = DateTime.Parse(endDate);

            List<CoustomerReportComedorRS> response = new List<CoustomerReportComedorRS>();
            List<ReportComedor> responseDAO = new List<ReportComedor>();
            ReportDAO report = new ReportDAO();
            responseDAO = report.GetReportsSalas (dateInit, dateEnd);
            //responseDAO.AddRange(report.GetReportsComedor());
           
            response = assemblerRs(responseDAO);
            replaceNameComedor(response);
            return response;
        }
        public List<CoustomerReportComedorRS> getGeneralReportEventos(string initDate, string endDate)
        {
            var dateInit = DateTime.Parse(initDate);
            var dateEnd = DateTime.Parse(endDate);

            List<CoustomerReportComedorRS> response = new List<CoustomerReportComedorRS>();
            List<ReportComedor> responseDAO = new List<ReportComedor>();
            ReportDAO report = new ReportDAO();
            responseDAO = report.GetReportsEvento(dateInit, dateEnd);
            //responseDAO.AddRange(report.GetReportsComedor());
           
            response = assemblerRs(responseDAO);
            replaceNameComedor(response);
            return response;
        }
        public void replaceNameComedor(List<CoustomerReportComedorRS> responseDAO)
        {
            responseDAO.ForEach(x =>
            {
                if(x.comedor!= null) {  
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
                    else if (x.comedor.Equals("4"))
                    {
                        x.comedor = "Evento 1";
                    }
                    else if (x.comedor.Equals("5"))
                    {
                        x.comedor = "Evento 2";
                    }
                    else if (x.comedor.Equals("6"))
                    {
                        x.comedor = "Evento 3";
                    }
                    else if (x.comedor.Equals("7"))
                    {
                        x.comedor = "Sala 1";
                    }
                    else if (x.comedor.Equals("8"))
                    {
                        x.comedor = "Sala 2";
                    }
                    else if (x.comedor.Equals("9"))
                    {
                        x.comedor = "Sala 3";
                    }
                }
            });
        }
        public List<CoustomerReportComedorRS> assemblerRs(List<ReportComedor> responseDAO)
        {
            List<CoustomerReportComedorRS> comedorRs = new List<CoustomerReportComedorRS>();
            comedorRs = responseDAO.ConvertAll(x => new CoustomerReportComedorRS(x.image, x.name,
             x.lastName, x.numEmploye, x.date,x.compañia, x.comedor
             x.lastName, x.numEmployed, x.date, x.empresa
                ));
            return comedorRs;
        }


        public List<CoustomerReportComedorRS> getCoustomReport( )
        {
            DateTime dateTime = new DateTime();
            List<CoustomerReportComedorRS> response = new List<CoustomerReportComedorRS>();

            CoustomerReportComedorRS comedorReport = new CoustomerReportComedorRS();

           
            return response;
        }
    }
}