using Dapper;
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
                    report = db.Query<ReportComedor>("SELECT s.IdSala as comedor, s.numEmployed, s.dateInit as date, u.nombre as name,u.Apellido_Paterno + u.Apellido_Materno as lastName" +
                    " from VisitasSalas s left"+
                    " join Usuarios u  on s.numEmployed = u.Numero_Empleado"+
                   " union"+
                   " SELECT s.IdEvento as comedor, s.numEmployed, s.dateInit as date, u.nombre as name, u.Apellido_Paterno + u.Apellido_Materno as lastName,u.Compañia" +
                    " from VisitasEvento s left" +
                    " join Usuarios u  on s.numEmployed = u.Numero_Empleado", commandType: CommandType.Text).ToList();
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
                    report = db.Query<ReportComedor>("SELECT s.IdSala as comedor, s.numEmployed, s.dateInit as date, u.nombre as name,u.Apellido_Paterno + u.Apellido_Materno as lastName, cc.nombre as Empresa" +
                    " from VisitasSalas s left" +
                    " join Usuarios u  on s.numEmployed = u.Numero_Empleado" +
                    " left join  Cat_Compañias cc on u.Compañia  =cc.idCompañia"
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

                    report = db.Query<ReportComedor>("SELECT s.IdSala as comedor, s.numEmployed, s.dateInit as date, u.nombre as name,u.Apellido_Paterno + u.Apellido_Materno as lastName,cc.nombre as Empresa" +
                    " from VisitasSalas s left" +
                    " join Usuarios u  on s.numEmployed = u.Numero_Empleado " +
                    "left join  Cat_Compañias cc on u.Compañia  =cc.idCompañia "+
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
                    report = db.Query<ReportComedor>(" SELECT s.IdEvento as comedor, s.numEmployed, s.dateInit as date, u.nombre as name, u.Apellido_Paterno + u.Apellido_Materno as lastName, cc.nombre as Empresa" +
                    " from VisitasEvento s left" +
                    " join Usuarios u  on s.numEmployed = u.Numero_Empleado " +
                    "left join  Cat_Compañias cc on u.Compañia  =cc.idCompañia"
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

                    report = db.Query<ReportComedor>(" SELECT s.IdEvento as comedor, s.numEmployed, s.dateInit as date, u.nombre as name, u.Apellido_Paterno + u.Apellido_Materno as lastName, cc.nombre as Empresa" +
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
                     report = db.Query<ReportComedor>("SELECT   s.idComedor as comedor,s.numEmployed,s.days,s.registerdate AS date,s.image, u.nombre as name,u.Apellido_Paterno + u.Apellido_Materno as lastName, cc.nombre as Empresa" +
                    " FROM VisitasComedor s left join Usuarios u " +
                    "left join  Cat_Compañias cc on u.Compañia  =cc.idCompañia" +
                    " on s.numEmployed = u.Numero_Empleado", commandType: CommandType.Text).ToList();
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
                    report = db.Query<ReportComedor>("SELECT   s.idComedor as comedor,s.numEmployed,s.days,s.registerdate AS date,s.image, u.nombre as name,u.Apellido_Paterno + u.Apellido_Materno as lastName,cc.nombre as Empresa" +
                    " FROM VisitasComedor s left join Usuarios u  on s.numEmployed = u.Numero_Empleado " +
                    "left join  Cat_Compañias cc on u.Compañia  =cc.idCompañia" +
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