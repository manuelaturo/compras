using compras.BD;
using compras.Models;
using compras.Models.Request;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace compras.Service
{
    public class ReportService
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public List<CoustomerReportComedorRS> getGeneralReportSala()
        {

            List<CoustomerReportComedorRS> response = new List<CoustomerReportComedorRS>();
            List<ReportComedor> responseDAO = new List<ReportComedor>();
            ReportDAO report = new ReportDAO();
            responseDAO = report.GetReportsSalas();
            
            response = assemblerRs(responseDAO, null);
  
            return response;
        }

        public CoustomerReportComedorRS getDetailsEvent(int idEvent)
        {
            CoustomerReportComedorRS response = new CoustomerReportComedorRS();
            ReportComedor responseDAO = new ReportComedor();
            List<string> serviceEvent = new List<string>();
            ReportDAO report = new ReportDAO();
            responseDAO = report.GetReportsEventosbyId(idEvent);
            serviceEvent = report.GetServicesEvento(responseDAO.idVisitasEvento);
            response = assemblerEventRsId(responseDAO, serviceEvent);
            return response;
        }
        public List<CoustomerReportComedorRS> getGeneralReportEvento()
        {

            List<CoustomerReportComedorRS> response = new List<CoustomerReportComedorRS>();
            List<ReportComedor> responseDAO = new List<ReportComedor>();
            List<string> serviceEvent = new List<string>();
            ReportDAO report = new ReportDAO();
            responseDAO = report.GetReportsEvento();
            for(int i=0; i < responseDAO.Count; i++)
            {
                serviceEvent = report.GetServicesEvento(responseDAO[i].idVisitasEvento);
                response.Add(assemblerEventRs(responseDAO[i], serviceEvent));
            }
          
            return response;
        }

        public List<CoustomerReportComedorRS> getGeneralReport()
        {

            List<CoustomerReportComedorRS> response = new List<CoustomerReportComedorRS>();
            List<ReportComedor> responseDAO = new List<ReportComedor>();
            ReportDAO report = new ReportDAO();
            responseDAO = report.GetReportsComedor();
            //responseDAO.AddRange(report.GetReportsComedor());
            
            response = assemblerRs(responseDAO, null);

            return response;
        }

        public List<CoustomerReportComedorRS> getGeneralReportComedor(string initDate, string endDate)
        {
            try
            {
                var dateInit = DateTime.ParseExact(initDate, "dd-MM-yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                var dateEnd =  DateTime.ParseExact(endDate, "dd-MM-yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);

                List<CoustomerReportComedorRS> response = new List<CoustomerReportComedorRS>();
                List<ReportComedor> responseDAO = new List<ReportComedor>();
                ReportDAO report = new ReportDAO();
                responseDAO = report.GetReportsComedor(dateInit, dateEnd);
                //responseDAO.AddRange(report.t());

                response = assemblerRs(responseDAO, null);

                return response;
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
                throw;                
            }
            
        }
        public List<CoustomerReportComedorRS> getGeneralReportSalas(string initDate, string endDate)
        {
            try
            {
                var dateInit = DateTime.ParseExact(initDate, "dd-MM-yyyy HH:mm", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                var dateEnd = DateTime.ParseExact(endDate, "dd-MM-yyyy HH:mm", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);

                List<CoustomerReportComedorRS> response = new List<CoustomerReportComedorRS>();
                List<ReportComedor> responseDAO = new List<ReportComedor>();
                ReportDAO report = new ReportDAO();
                responseDAO = report.GetReportsSalas(dateInit, dateEnd);
                //responseDAO.AddRange(report.GetReportsComedor());

                response = assemblerSalaRs(responseDAO);

                return response;
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
           
        }
        public List<CoustomerReportComedorRS> getGeneralReportEventos(string initDate, string endDate)
        {
            try
            {
                var dateInit = DateTime.ParseExact(initDate, "dd-MM-yyyy HH:mm", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                var dateEnd = DateTime.ParseExact(endDate, "dd-MM-yyyy HH:mm", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);

                List<CoustomerReportComedorRS> response = new List<CoustomerReportComedorRS>();
                List<ReportComedor> responseDAO = new List<ReportComedor>();
                ReportDAO report = new ReportDAO();
                responseDAO = report.GetReportsEvento(dateInit, dateEnd);
                //responseDAO.AddRange(report.GetReportsComedor());

                response = assemblerRs(responseDAO, null);
                replaceNameComedor(response);
                return response;
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
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
        public List<CoustomerReportComedorRS> assemblerRs(List<ReportComedor> responseDAO, List<string> services)
        {
            List<CoustomerReportComedorRS> comedorRs = new List<CoustomerReportComedorRS>();
            comedorRs = responseDAO.ConvertAll(x => new CoustomerReportComedorRS(x.id,x.image, x.name,
             x.lastName, x.numEmployed, x.date, getCompany(x.numEmployed, x.empresa), x.comedor, x.days, x.comments, 
             x.service, x.email, x.eventName, x.meetType, x.nameSalaDetail,x.dateEnd,x.numberPeople));
            return comedorRs;
        }
        public CoustomerReportComedorRS assemblerEventRs(ReportComedor responseDAO, List<string> services)
        {
            CoustomerReportComedorRS comedorRs = new CoustomerReportComedorRS(responseDAO.eventName, responseDAO.numEmployed, responseDAO.name,
            responseDAO.lastName, responseDAO.date, responseDAO.dateEnd, responseDAO.numberPeople, responseDAO.locate, responseDAO.logistics, responseDAO.management,
            responseDAO.days, responseDAO.comments, services, getCompany(responseDAO.numEmployed, responseDAO.compañia), responseDAO.placeEvent,responseDAO.autorizationName, responseDAO.idVisitasEvento);

            return comedorRs;
        }
        public CoustomerReportComedorRS assemblerEventRsId(ReportComedor responseDAO, List<string> services)
        {
            CoustomerReportComedorRS comedorRs = new CoustomerReportComedorRS(responseDAO.eventName, responseDAO.numEmployed, responseDAO.name,
            responseDAO.lastName, responseDAO.date, responseDAO.dateEnd, responseDAO.numberPeople, responseDAO.locate, responseDAO.logistics, responseDAO.management,
            responseDAO.days, responseDAO.comments, services, getCompany(responseDAO.numEmployed, responseDAO.compañia), responseDAO.placeEvent, responseDAO.autorizationName, responseDAO.accommodation, responseDAO.costs);

            return comedorRs;
        }
        public List<CoustomerReportComedorRS> assemblerSalaRs(List<ReportComedor> responseDAO)
        {
            List<CoustomerReportComedorRS> comedorRs = new List<CoustomerReportComedorRS>();
            comedorRs = responseDAO.ConvertAll(x => new CoustomerReportComedorRS(x.id,x.image, x.name,
             x.lastName, x.numEmployed, x.date, getCompany(x.numEmployed, x.empresa), x.comedor,
             x.days, x.comments, x.service,x.email,x.eventName,x.meetType,x.nameSalaDetail,x.dateEnd,x.numberPeople));
            return comedorRs;
        }

        private string getCompany(int numEmployed, string company)
        {
            if (company == null)
            {
                string empresa;
                if (numEmployed!= null && numEmployed.ToString().Length > 2)
                {
                     empresa = numEmployed.ToString().Substring(0, 2);
                }
                else
                {
                    return "Sin empresa";
                }
               


                switch ((empresa))
                {
                    case "20":
                        return "Peña Verde";
                    case "30":
                        return "General de Seguros";
                    case "31":
                        return  "General de Seguros";
                    case "40":
                        return  "Servicios Administrados Peña Verde";

                    case "60":
                        return "Call Center";
                    default:
                        return  "Sin empresa";
                }
            }
            return company;
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