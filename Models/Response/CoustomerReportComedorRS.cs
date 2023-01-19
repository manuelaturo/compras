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
        public string compañia { get; set; }
        public DateTime date { get; set; }
        public string empresa { get; set; }
        public string days { get; set; }
        public string comments { get; set; }
        public string service { get; set; }
        public List<string> serviceEvent { get; set; }

        public CoustomerReportComedorRS() { }
        public CoustomerReportComedorRS(string image, string name,
            string lastName, int numEmploye, DateTime date, string compañia, string comedor,
            string days, string comments) {
            this.image = image;
            this.name = name;
            this.comedor = comedor;
            this.lastName = lastName;
            this.numEmploye = numEmploye;
            this.date = date;
            this.empresa = compañia;
            this.compañia = compañia;
            this.days = days;
            this.comments = comments;


        }
        public CoustomerReportComedorRS(string image, string name,
           string lastName, int numEmploye, DateTime date, string compañia, string comedor,
           string days, string comments,string service)
        {
            this.image = image;
            this.name = name;
            this.comedor = comedor;
            this.lastName = lastName;
            this.numEmploye = numEmploye;
            this.date = date;
            this.empresa = compañia;
            this.compañia = compañia;
            this.days = days;
            this.comments = comments;
            this.service = service;


        }
    }
}