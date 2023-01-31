using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace compras.Models.Response
{
    public class ProductsRS
    {
        public int idProduct { get; set; }
        public string nameProduct { get; set; }
        public string decription { get; set; }
        public string category { get; set; }
        public string keyProduct { get; set; }
        public int item { get; set; }
        public string folio { get; set; }
        public string typeimage { get; set; }
        public string image { get; set; }
        public int addUser { get; set; }
        public int updaeUser { get; set; }
        public DateTime updaeDate { get; set; }
        public DateTime addDate { get; set; }

        public ProductsRS() { }
        public ProductsRS(int idProduct, string nameProduct, string decription, string category,
        string keyProduct, int item, string folio, string typeimage, string image, int addUser)
        {
            this.idProduct = idProduct;
            this.nameProduct = nameProduct;
            this.decription = decription;
            this.category = category;
            this.keyProduct = keyProduct;
            this.item = item;
            this.folio = folio;
            this.typeimage = typeimage;
            this.image = image;
            this.addUser = addUser;
        }

    }

}