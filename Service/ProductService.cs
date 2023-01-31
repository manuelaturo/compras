using compras.BD;
using compras.BD.Entities;
using compras.Models.Request;
using compras.Models.Response;
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
            try
            {
                ProductDAO dao = new ProductDAO();

                dao.addProduct(assemberEntity(rq));

                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool updateProduct(UpdateProdcuts rq)
        {
            try
            {
                ProductDAO dao = new ProductDAO();

                dao.updateProduct(assemberEntity(rq));

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<ProductsRS> GetProducts()
        {
            try
            {
                ProductDAO dao = new ProductDAO();
                return asemblerRS(dao.GetProducts());
            }catch(Exception e)
            {
                throw e;
            }
        }

        private List<ProductsRS> asemblerRS(List<ProductEntity>entity)
        {
            return entity.ConvertAll(rq => new ProductsRS(rq.idProduct, rq.nameProduct, rq.decription, rq.category,
        rq.keyProduct, rq.item, rq.folio, rq.typeimage, rq.image, rq.addUser));
        }

        private ProductEntity assemberEntity(UpdateProdcuts rq)
        {

            return new ProductEntity(rq.idProduct, rq.namePrduct, rq.decription, rq.category,
        rq.keyProduct, rq.item, rq.folio, rq.typeimage, rq.image, rq.addUser);

        }
        private ProductEntity assemberEntity(ProductsRQ rq)
        {

            return new ProductEntity(rq.nameProduct, rq.decription, rq.category,
        rq.keyProduct, rq.item, rq.folio, rq.typeimage, rq.image, rq.addUser);

        }
    }
}