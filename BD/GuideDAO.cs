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

        public List<GuidesEntity> GetGuides()
        {
            try
            {
                List<GuidesEntity> guides = new List<GuidesEntity>();

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    guides = db.Query<GuidesEntity>("SELECT Id_Guide,numEmpployed,Name,conpany,destination," +
                        "description,size,kg,ledgerAccount,costCenter,guide FROM Guides", commandType: CommandType.Text).ToList();
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