using compras.BD.Entities;
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
    public class GuideDAO
    {
        private readonly string con = ConfigurationManager.ConnectionStrings["Comedor"].ConnectionString;

       
        public List<GuidesEntity> GetGuides(DateTime initDate, DateTime endDate)
        {
            try
            {
                List<GuidesEntity> guides = new List<GuidesEntity>();

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@dateInit", initDate);
                    queryParameters.Add("@dateEnd", endDate);

                    guides = db.Query<GuidesEntity>(" SELECT g.Id_Guide, g.numEmpployed, g.Name, g.conpany, g.destination, g.description, g.size, g.kg, g.ledgerAccount, " +
                        "g.costCenter, g.guide, cg.type as guideType, cg.price FROM Guides g INNER JOIN Cat_Guide cg ON g.guide = cg.Id_Guide_Type where registerDate between @dateInit and @dateEnd", commandType: CommandType.Text).ToList();
                    db.Close();
                    return guides;
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
        public List<GuidesEntity> GetGuides()
        {
            try
            {
                List<GuidesEntity> guides = new List<GuidesEntity>();

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    guides = db.Query<GuidesEntity>(" SELECT g.Id_Guide, g.numEmpployed, g.Name, g.conpany, g.destination, g.description, g.size, g.kg, g.ledgerAccount, " +
                        "g.costCenter, g.guide, cg.type as guideType, cg.price FROM Guides g INNER JOIN Cat_Guide cg ON g.guide = cg.Id_Guide_Type", commandType: CommandType.Text).ToList();
                    db.Close();
                    return guides;
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

        public List<CatGuidesEntity> GetIdGuides()
        {
            try
            {
                List<CatGuidesEntity> guides = new List<CatGuidesEntity>();

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    guides = db.Query<CatGuidesEntity>(" SELECT  Id_Guide_Type, price, type  FROM Cat_Guide", commandType: CommandType.Text).ToList();
                    db.Close();
                    return guides;
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

       
        public int Getcount (int guide)
        {
            try
            {
                int guides = 0;

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    guides = db.Query<int>(" select count(guide) from Guides where guide=@guide ",
                        new { guide = guide}).FirstOrDefault();
                    db.Close();
                    return guides;
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