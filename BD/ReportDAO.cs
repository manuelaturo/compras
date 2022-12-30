using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace compras.BD
{
    public class ReportDAO
    {

        private readonly string con = ConfigurationManager.ConnectionStrings["Comedor"].ConnectionString;

      /*  public List<CatFamilyDescription> GetCatFamilyDescriptions()
        {
            log.Info("llega a CatFamilyDescriptionDAO GetCatFamilyDescriptions");
            try
            {
                List<CatFamilyDescription> catFamilyDescriptions = new List<CatFamilyDescription>();

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    catFamilyDescriptions = db.Query<CatFamilyDescription>("SELECT * FROM	catFamilyDescription", commandType: CommandType.Text).ToList();
                    db.Close();
                    log.Debug("CatFamilyDescriptionDAO GetCatFamilyDescriptions return:" + JsonConvert.SerializeObject(catFamilyDescriptions));
                    return catFamilyDescriptions;
                }

            }
            catch (SqlException e)
            {
                log.Error("Can't get catFamilyDescriptions: " + e);
                throw e;
            }
            catch (Exception e)
            {
                log.Error("Can't get catFamilyDescriptions: " + e);
                throw e;
            }
        }*/
    }
}