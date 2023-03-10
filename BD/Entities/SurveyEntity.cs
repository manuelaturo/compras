using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace compras.BD.Entities
{
    public class SurveyEntity
    {

        public int idQuestion { get; set; }
        public int idSurvey { get; set; }
        public string response { get; set; }
        public string module { get; set; }
        public string company { get; set; }
        public int numEmplouyed { get; set; }

        public SurveyEntity(){ }
        public SurveyEntity(int idQuestion, string response,string module,
            string company, int numEmplouyed)
        {
            this.idQuestion = idQuestion;
            this.response = response;
            this.module = module;
            this.company = company;
            this.numEmplouyed = numEmplouyed;
        }
    }
}