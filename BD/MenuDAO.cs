using Dapper;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace compras.BD
{
    public class MenuDAO
    {
        private readonly string con = ConfigurationManager.ConnectionStrings["Comedor"].ConnectionString;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public bool addMenu(string Description, int Day)
        {
            try
            {


                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    db.Execute("INSERT INTO Menu (Description, Day) " +
                            " values (@Description, @Day)",
                            new
                            {
                                Description,
                                Day
                            });
                    db.Close();
                    return true;
                }

            }
            catch (SqlException e)
            {
                log.Info("error " + e);
                throw e;
            }
            catch (Exception e)
            {
                log.Info("error " + e);
                throw e;
            }
        }
        public bool updateMenu(string menu, int day)
        {
            try
            {

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    var queryParameters = new DynamicParameters();
                     db.Execute("update Menu set Description = @menu   where day = @day", new { menu, day = day });
                    db.Close();
                    return true;
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
        public string getMenu(int day)
        {
            try
            {
                string guidesPrice = string.Empty;

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@day", day);
                    guidesPrice = db.Query<string>("SELECT Description FROM Menu WHERE Day  = @day", queryParameters,
                        commandType: CommandType.Text).FirstOrDefault();
                    db.Close();
                    return guidesPrice;
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