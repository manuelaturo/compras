﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace compras.BD
{
    public class ReportDAO
    {

        private readonly string con = ConfigurationManager.ConnectionStrings["Comedor"].ConnectionString;

        public List<ReportComedor> GetReportsEventoAndSalas()
        {
            try
            {
                List<ReportComedor> report = new List<ReportComedor>();

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    report = db.Query<ReportComedor>(" SELECT e. idVisitasEvento as idEvent, e.eventName, e.numEmployed, name,lastName" +
                    " e.dateInit as date,  e.DateEnd as dateEnd, e.numberPeople, l.Name as locate, e.logistics FROM VisitasEvento e" +
                    " left join Usuarios u  on e.numEmployed = u.Numero_Empleado" +
                   " left join Cat_Locale l on e.locale  = l.Id_Locale", commandType: CommandType.Text).ToList();
                    db.Close();
                  return report;
                }

            }
            catch (SqlException e)
            {
                    throw e;
            }
            catch (Exception e)
            {
                   throw e;
            }
        }

        public List<ReportComedor> GetReportsSalas()
        {
            try
            {
                List<ReportComedor> report = new List<ReportComedor>();

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    report = db.Query<ReportComedor>("SELECT cs.Description as comedor,csr.Description as service, s.numEmployed, s.dateInit as date,s.Name,s.LastName, cc.nombre as Empresa" +
                    " ,cs.Description, csr.Description,s.correo as email,s.NombreEvento as eventName,s.comments,mt.name as meetType from VisitasSalas s  left" +
                    " join Usuarios u  on s.numEmployed = u.Numero_Empleado" +
                    " left join  Cat_Compañias cc on u.Compañia  =cc.idCompañia " +
                    " inner join Cat_Sala cs on s.IdSala = cs.idCatSala " +
                    "inner join Cat_Servicios csr on s.services = csr.Id_Servicios_Eventos " +
                    "left join Cat_MeetsType mt on mt.Id_Meet = s.meetType"
                   , commandType: CommandType.Text).ToList();
                    db.Close();
                    return report;
                }

            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<ReportComedor> GetReportsSalas(DateTime initDate, DateTime endDate)
        {
            try
            {
                List<ReportComedor> report = new List<ReportComedor>();

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@dateInit", initDate);
                    queryParameters.Add("@dateEnd", endDate);

                    report = db.Query<ReportComedor>("SELECT cs.Description as comedor,csr.Description as service, s.numEmployed, s.dateInit as date,s.Name,s.LastName, cc.nombre as Empresa" +
                    " ,cs.Description, csr.Description,s.correo as email,s.NombreEvento as eventName,mt.name as meetType from VisitasSalas s  left" +
                    " join Usuarios u  on s.numEmployed = u.Numero_Empleado" +
                    " left join  Cat_Compañias cc on u.Compañia  =cc.idCompañia " +
                    " inner join Cat_Sala cs on s.IdSala = cs.idCatSala " +
                    "inner join Cat_Servicios csr on s.services = csr.Id_Servicios_Eventos "+
                    "left join Cat_MeetsType mt on mt.Id_Meet = s.meetType" +
                    "where s.dateInit  between @dateInit   and @dateEnd"
                   , queryParameters,commandType: CommandType.Text).ToList();
                    db.Close();
                    return report;
                }

            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public List<ReportComedor> GetReportsEvento()
        {
            try
            {
                List<ReportComedor> report = new List<ReportComedor>();

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    report = db.Query<ReportComedor>(" SELECT e.idVisitasEvento, e.eventName, e.numEmployed, e.Name,e.LastName,e.placeEvent, " +
                    " e.dateInit as date, e.dateEnd, e.numberPeople, l.Name as locate, e.logistics,  cm.Name as management,e.comennts ,cc.Nombre as compañia FROM VisitasEvento e " +
                    " left join Usuarios u  on e.numEmployed = u.Numero_Empleado " +
                    " left join Cat_Locale l on e.locale  = l.Id_Locale" +
                    " left join Cat_Managements cm on e.management = cm.Id_Management" +
                    " left join Cat_Compañias cc on u.Compañia = cc.idCompañia"
                   , commandType: CommandType.Text).ToList();
                    db.Close();
                    return report;
                }

            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<string> GetServicesEvento(int idEvent)
        {
            try
            {
                List<string> report = new List<string>(); 
                
                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@idEvent", idEvent);
                    report = db.Query<string>(" select cs.Description from Services_Event se " +
                    " INNER JOIN Cat_Servicios cs  on cs.Id_Servicios_Eventos = se.service " +
                    " where se.event= @idEvent "
                   , queryParameters, commandType: CommandType.Text).ToList();
                    db.Close();
                    return report;
                }

            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<ReportComedor> GetReportsEvento(DateTime initDate, DateTime endDate)
        {
            try
            {
                List<ReportComedor> report = new List<ReportComedor>();

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@dateInit", initDate);
                    queryParameters.Add("@dateEnd", endDate);

                    report = db.Query<ReportComedor>(" SELECT s.IdEvento as comedor, s.numEmployed, s.dateInit as date, s.Name,s.LastName, cc.nombre as Empresa,s.placeEvent" +
                    " from VisitasEvento s left" +
                    " join Usuarios u  on s.numEmployed = u.Numero_Empleado " +
                    "left join  Cat_Compañias cc on u.Compañia  =cc.idCompañia" +
                    " where s.dateInit  between @dateInit   and @dateEnd"
                   , queryParameters,commandType: CommandType.Text).ToList();
                    db.Close();
                    return report;
                }

            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public List<ReportComedor> GetReportsComedor()
        {
            try
            {
                List<ReportComedor> report = new List<ReportComedor>();

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                     report = db.Query<ReportComedor>("SELECT   ccom.Nombre as comedor,s.numEmployed,s.days,s.registerdate AS date,s.image,s.Name,s.LastName, cc.nombre as Empresa" +
                    ",s.comments  FROM VisitasComedor s left join Usuarios u " +
                    " on s.numEmployed = u.Numero_Empleado " +
                    "left join  Cat_Compañias cc on s.company = cc.idCompañia " +
                    "inner join Cat_Comedor ccom on s.idComedor = ccom.Id_Comedor", commandType: CommandType.Text).ToList();
                    db.Close();
                    return report;
                }

            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<ReportComedor> GetReportsComedor(DateTime dateInit, DateTime dateEnd)
        {
            try
            {
                List<ReportComedor> report = new List<ReportComedor>();

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@dateInit", dateInit);
                    queryParameters.Add("@dateEnd", dateEnd);
                    report = db.Query<ReportComedor>("SELECT   ccom.Nombre as comedor,s.numEmployed,s.days,s.registerdate AS date,s.image,s.Name,s.LastName, cc.nombre as Empresa" +
                    ",s.comments  FROM VisitasComedor s left join Usuarios u " +
                    " on s.numEmployed = u.Numero_Empleado " +
                    "left join  Cat_Compañias cc on s.company = cc.idCompañia " +
                    "inner join Cat_Comedor ccom on s.idComedor = ccom.Id_Comedor"+
                    " where s.registerdate  between @dateInit   and @dateEnd", queryParameters, commandType: CommandType.Text).ToList();
                    db.Close();
                    return report;
                }

            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}