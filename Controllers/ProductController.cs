using compras.Models.Request;
using compras.Models.Response;
using compras.Service;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace compras.Controllers
{
    public class ProductController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ActionResult Products(string usuario, string password)

        {
            log.Info("inicio compras");
            return View();
        }
        public ActionResult CreateProduct(ProductsRQ product)
        {
            try
            {

                ProductService comedorService = new ProductService();

                if (comedorService.addProduct(product))
                {
                    return RedirectToAction("Index");
                }

                return new HttpStatusCodeResult((int)HttpStatusCode.NoContent);

            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
            }

        }
        public ActionResult UpdateComedor(ProductsRQ product)
        {
            try
            {

                ProductService comedorService = new ProductService();

                if (comedorService.addProduct(product))
                {
                    return RedirectToAction("Index");
                }

                return new HttpStatusCodeResult((int)HttpStatusCode.NoContent);

            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
            }

        }
        public ActionResult GetProdcuts()
        {
            try
            {
                List<ProductsRS> rs = new List<ProductsRS>();
                ProductService productService = new ProductService();
                rs = productService.GetProducts();
                return View(rs);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

    }
}