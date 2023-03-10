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
    public class SurveyDAO
    {
        private readonly string con = ConfigurationManager.ConnectionStrings["Comedor"].ConnectionString;

        public bool AddSurvey(SurveyEntity quiz)
        {
            try
            {
                DateTime registerDate = DateTime.Now;

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    var result = db.Execute("INSERT INTO Survey  (idQuestion,response,module,company,numEmplouyed) " +
                        "VALUES (@idQuestion,@response,Qmodule,@company,@numEmplouyed)",

                        new
                        {
                            quiz.idQuestion,
                            quiz.module,
                            quiz.numEmplouyed,
                            quiz.response,
                            quiz.company,
                            registerDate
                        });
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
        public List<SurveyEntity> GetSurvey()
        {
            try
            {
                List<SurveyEntity> quiz = new List<SurveyEntity>();

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    quiz = db.Query<SurveyEntity>("SELECT  idSurvey ,idQuestion,response,module,company,numEmplouyed FROM Survey", commandType: CommandType.Text).ToList();
                    db.Close();
                    return quiz;
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