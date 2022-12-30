using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace compras.Models
{
    public class CoustomerReportComedorRS
    {
        public string image { get; set; }

        public string name { get; set; }
        public string lastName { get; set; }
        public int numEmploye { get; set; }
        public string comedor { get; set; }
        public DateTime date { get; set; }
        public string empresa { get; set; }

        public CoustomerReportComedorRS() { }
        public CoustomerReportComedorRS(string image, string name,
            string lastName, int numEmploye, DateTime date, string empresa) {
            this.image = image;
            this.name = name;
            this.lastName = lastName;
            this.numEmploye = numEmploye;
            this.date = date;
            this.empresa = empresa;
        
        }
    }
}