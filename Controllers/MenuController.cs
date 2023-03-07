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
    public class MenuController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateMenu(string menu, int day)
        {
            try
            {

                log.Info("inicio CreateComedor");
                MenuService menuService = new MenuService();

                if (menuService.insertMenu(menu, day))
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
        // GET: Menu/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Menu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Menu/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Menu/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Menu/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Menu/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Menu/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
