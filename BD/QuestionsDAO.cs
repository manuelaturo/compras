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
    public class QuestionsDAO
    {
        private readonly string con = ConfigurationManager.ConnectionStrings["Comedor"].ConnectionString;

        public bool UpdateQuestions(QuetionsEntity quiz)
        {
            try
            {
                DateTime registerDate = DateTime.Now;

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    var result = db.Execute("UPDATE Questions  " +
                        " SET question = @question , module = @module " +
                        " WHERE idQuestions = @idQuestions",
                        new
                        {
                            quiz.question,
                            quiz.module,
                           quiz.idQuestions
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

        public bool AddQuestions(QuetionsEntity quiz)
        {
            try
            {
                DateTime registerDate = DateTime.Now;

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    _ = db.Execute("INSERT INTO Questions" +
                        " (question , module,registerUser,registerDate) VALUES " +
                        "(@question, @module,@registerUser,@registerDate)",
                        new
                        {
                            quiz.question,
                            quiz.module,
                            quiz.registerUser,
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
        public List<QuetionsEntity> GetQuestions()
        {
            try
            {
                List<QuetionsEntity> guides = new List<QuetionsEntity>();

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    guides = db.Query<QuetionsEntity>("SELECT  idQuestions,question,module,registerUser    FROM Questions", commandType: CommandType.Text).ToList();
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
        public List<QuetionsEntity> GetQuestions(string module)
        {
            try
            {
                List<QuetionsEntity> guides = new List<QuetionsEntity>();

                using (var db = new SqlConnection(con))
                {

                    db.Open();
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@module", module);

                    guides = db.Query<QuetionsEntity>("SELECT  idQuestions,question,module,registerUser    FROM Questions" +
                        "Where module like @module ", queryParameters, commandType: CommandType.Text).ToList();
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