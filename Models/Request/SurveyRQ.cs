using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace compras.Models.Request
{
    public class SurveyRQ
    {
        public int idQuestion { get; set; } 
        public string response { get; set; } 
        public string module { get; set; } 
        public string company { get; set; } 
        public int numEmplouyed { get; set; } 
    }
}