using compras.BD;
using compras.BD.Entities;
using compras.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace compras.Service
{
    public class ProductService
    {
        public bool addProduct(ProductsRQ rq)
        {
            ProductDAO dao = new ProductDAO();



            return true;
        }

        //private ProductEntity assemberEntity(rq)
        //{

        //}
    }
}