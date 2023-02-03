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
        public string eventName { get; set; }
        public DateTime dateEnd { get; set; }
        public int numberPeople { get; set; }
        public string locate { get; set; }
        public string logistics { get; set; }
        public string management { get; set; }
        public string email { get; set; }
        public string placeEvent { get; set; }
        public string meetType { get; set; }
        public string nameSalaDetail { get; set; }
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
           string days, string comments,string service,string email,string eventName,string meetType,string nameSalaDetail)
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
            this.eventName = eventName;
            this.email = email;
            this.meetType = meetType;
            this.nameSalaDetail = nameSalaDetail;

        }

        public CoustomerReportComedorRS(string eventName, int numEmploye, string name,
           string lastName,  DateTime date,  DateTime dateEnd, int numberPeople, string locate, string logistics, string management,
           string days, string comments, List<string> service, string compañia,string placeEvent)
        {
            this.name = name;
            this.numEmploye = numEmploye;
            this.comedor = comedor;
            this.lastName = lastName;
            this.dateEnd = dateEnd;
            this.date = date;
            this.numberPeople = numberPeople;
            this.locate = locate;
            this.logistics = logistics;
            this.management = management;
            this.days = days;
            this.comments = comments;
            this.eventName = eventName;
            this.serviceEvent = service;
            this.compañia = compañia;
            this.placeEvent = placeEvent;

        }
    }
}