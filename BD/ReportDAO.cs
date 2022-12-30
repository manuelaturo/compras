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

        private readonly string con = ConfigurationManager.ConnectionStrings["dapper"].ConnectionString;

        public List<ReportComedor> GetReportsEventoAndSalas()
        {
            try
            {
                List<ReportComedor> catFamilyDescriptions = new List<ReportComedor>();

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    catFamilyDescriptions = db.Query<ReportComedor>("SELECT s.IdSala as comedor, s.numEmployed, s.dateInit as date, u.nombre as name,u.Apellido_Paterno + u.Apellido_Materno as lastName" +
                    " from VisitasSalas s left"+
                    " join Usuarios u  on s.numEmployed = u.Numero_Empleado"+
                   " union"+
                   " SELECT s.IdEvento as comedor, s.numEmployed, s.dateInit as date, u.nombre as name, u.Apellido_Paterno + u.Apellido_Materno as lastName" +
                    " from VisitasEvento s left" +
                    " join Usuarios u  on s.numEmployed = u.Numero_Empleado", commandType: CommandType.Text).ToList();
                    db.Close();
                  return catFamilyDescriptions;
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
                List<ReportComedor> catFamilyDescriptions = new List<ReportComedor>();

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    catFamilyDescriptions = db.Query<ReportComedor>("SELECT s.IdSala as comedor, s.numEmployed, s.dateInit as date, u.nombre as name,u.Apellido_Paterno + u.Apellido_Materno as lastName" +
                    " from VisitasSalas s left" +
                    " join Usuarios u  on s.numEmployed = u.Numero_Empleado" 
                   , commandType: CommandType.Text).ToList();
                    db.Close();
                    return catFamilyDescriptions;
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
                List<ReportComedor> catFamilyDescriptions = new List<ReportComedor>();

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    catFamilyDescriptions = db.Query<ReportComedor>(" SELECT s.IdEvento as comedor, s.numEmployed, s.dateInit as date, u.nombre as name, u.Apellido_Paterno + u.Apellido_Materno as lastName" +
                    " from VisitasEvento s left" +
                    " join Usuarios u  on s.numEmployed = u.Numero_Empleado"
                   , commandType: CommandType.Text).ToList();
                    db.Close();
                    return catFamilyDescriptions;
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
                List<ReportComedor> catFamilyDescriptions = new List<ReportComedor>();

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    catFamilyDescriptions = db.Query<ReportComedor>("SELECT   s.idComedor,s.numEmployed,s.days,s.registerdate AS date,s.image, u.nombre as name,u.Apellido_Paterno + u.Apellido_Materno as lastName"+
                    " FROM VisitasComedor s left join Usuarios u  on s.numEmployed = u.Numero_Empleado", commandType: CommandType.Text).ToList();
                    db.Close();
                    return catFamilyDescriptions;
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