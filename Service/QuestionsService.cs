using compras.BD;
using compras.BD.Entities;
using compras.Models.Request;
using compras.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace compras.Service
{
    public class QuestionsService
    {
        public bool AddQuestions(QuesionsRQ quesions)
        {
            try
            {
                QuestionsDAO dao = new QuestionsDAO();

                return dao.AddQuestions(new QuetionsEntity (quesions.question,quesions.module,quesions.registerUser));
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public List<QuetionsRS> getQuestions()
        {
            try
            {
                List<QuetionsRS> response = new List<QuetionsRS>();
                QuestionsDAO dao = new QuestionsDAO();
               
                decimal costTotal = 0;

               

              
                response = getQuestions(dao.GetQuestions());


                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    public List<QuetionsRS> getQuestions(List<QuetionsEntity> entities )
        {
            return entities.ConvertAll(x => new QuetionsRS(x.question, x.module, x.registerUser));
        }

    }
}