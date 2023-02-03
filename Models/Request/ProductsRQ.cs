using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace compras.Models.Request
{
    public class ProductsRQ
    {
        public string nameProduct { get; set; }
        public string decription { get; set; }
        public string category { get; set; }
        public string keyProduct { get; set; }
        public int item { get; set; }
        public int addUser { get; set; }
        public string folio { get; set; }
        public string typeimage { get; set; }
        public string image { get; set; }
        public List<int> users{ get; set; }
    }
}