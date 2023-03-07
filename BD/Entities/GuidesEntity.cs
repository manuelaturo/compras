using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace compras.BD.Entities
{
    public class GuidesEntity
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
        public decimal price { get; set; }
    }
}