using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace compras.Models.Response
{
    public class GuidesRS
    {
        public int numEmpployed { get; set; }
        public string Name { get; set; }
        public string conpany { get; set; }
        public string destination { get; set; }
        public string description { get; set; }
        public string size { get; set; }
        public string kg { get; set; }
        public string ledgerAccount { get; set; }
        public string costCenter { get; set; }
        public int guide { get; set; }
        public string guideType { get; set; }

        public GuidesRS() { }
        public GuidesRS(int numEmpployed, string Name, string conpany, string destination, string description,
         string size, string kg, string ledgerAccount, string costCenter, int guide) {

            this.numEmpployed = numEmpployed;
            this.Name = Name;
            this.conpany = conpany;
            this.destination = destination;
            this.description = description;
            this.size = size;
            this.kg = kg;
            this.ledgerAccount = ledgerAccount;
            this.costCenter = costCenter;
            this.guide = guide;
        }  public GuidesRS(int numEmpployed, string Name, string conpany, string destination, string description,
         string size, string kg, string ledgerAccount, string costCenter, int guide, string guideType) {

            this.numEmpployed = numEmpployed;
            this.Name = Name;
            this.conpany = conpany;
            this.destination = destination;
            this.description = description;
            this.size = size;
            this.kg = kg;
            this.ledgerAccount = ledgerAccount;
            this.costCenter = costCenter;
            this.guide = guide;
            this.guideType = guideType;
        }
    }
}