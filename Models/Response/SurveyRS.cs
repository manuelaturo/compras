using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace compras.Models.Response
{
    public class SurveyRS
    {
        public int idSurvey { get; set; }
        public int idQuestion { get; set; }
        public string response { get; set; }
        public string module { get; set; }
        public string company { get; set; }
        public int numEmplouyed { get; set; }

        public SurveyRS() { }
        public SurveyRS(int idSurvey,int idQuestion, string response, string module,
            string company, int numEmplouyed)
        {
            this.idSurvey = idSurvey;
            this.idQuestion = idQuestion;
            this.response = response;
            this.module = module;
            this.company = company;
            this.numEmplouyed = numEmplouyed;
        }
    }
}