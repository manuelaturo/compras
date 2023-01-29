using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace compras.BD.Entities
{
    public class ProductEntity
    {
        public int idProduct { get; set; }
        public string namePrduct { get; set; }
        public string decription { get; set; }
        public string category { get; set; }
        public string keyProduct { get; set; }
        public int item { get; set; }
        public int user { get; set; }
        public string folio { get; set; }
        public string typeimage { get; set; }
        public string image { get; set; }
        public int addUser { get; set; }
        public int updaeUser { get; set; }
        public DateTime updaeDate { get; set; }
        public DateTime addDate { get; set; }

        public ProductEntity()
        {
        }

        public ProductEntity(string namePrduct, string decription, string category,
         string keyProduct,int item,int user,string folio, string typeimage,string image,int addUser,
         int updaeUser, DateTime updaeDate, DateTime addDate)
        {
        }
    }

 
}