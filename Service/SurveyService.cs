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
    public class SurveyService
    {
        public bool AddSurvey (SurveyRQ rQ)
        {
            try
            {
                SurveyDAO dao = new SurveyDAO();

                return dao.AddSurvey(new SurveyEntity(rQ.idQuestion, rQ.response, rQ.module, rQ.company, rQ.numEmplouyed));
            }catch(Exception e)
            {
                throw e;
            }
        }
        public List<SurveyRS> getSurvey()
        {
            try
            {
                List<SurveyRS> response = new List<SurveyRS>();
                SurveyDAO dao = new SurveyDAO();

                response = assemblerSurvey(dao.GetSurvey());

                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<SurveyRS> assemblerSurvey(List<SurveyEntity> entities)
        {
            return entities.ConvertAll(e => new SurveyRS(e.idQuestion, e.idQuestion,
                e.response, e.module, e.company, e.numEmplouyed));
        }

    }
}