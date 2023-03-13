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
        public bool deleteQuestions(int idQuestions)
        {
            try
            {
                DateTime registerDate = DateTime.Now;

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    var i = db.Execute("DELETE FROM Questions WHERE idQuestions = @idQuestions",
                        new
                        {
                            idQuestions
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
                    guides = db.Query<QuetionsEntity>("SELECT  idQuestions,question,m.module as nameModule,registerUser  " +
                        "FROM Questions q inner join  module m on q.module = m.idModule", commandType: CommandType.Text).ToList();
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
        public List<QuetionsEntity> GetQuestions(DateTime initDate,DateTime endDate)
        {
            try
            {
                List<QuetionsEntity> guides = new List<QuetionsEntity>();

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@dateInit", initDate);
                    queryParameters.Add("@dateEnd", endDate);
                    guides = db.Query<QuetionsEntity>("SELECT  idQuestions,question,m.module as nameModule,registerUser  " +
                        "FROM Questions q inner join  module m on q.module = m.idModule where registerDate between @dateInit and @dateEnd", queryParameters, commandType: CommandType.Text).ToList();
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
        public List<QuetionsEntity> GetQuestions(int module)
        {
            try
            {
                List<QuetionsEntity> guides = new List<QuetionsEntity>();

                using (var db = new SqlConnection(con))
                {

                    db.Open();
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@module", module);

                    guides = db.Query<QuetionsEntity>("SELECT  idQuestions,question,m.module as nameModule,registerUser  " +
                        "FROM Questions q inner join  module m on q.module = m.idModule Where q.module = @module ", queryParameters, commandType: CommandType.Text).ToList();
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