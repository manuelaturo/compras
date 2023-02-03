using compras.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace compras.Controllers
{
    public class EventosDetailsController : Controller
    {
        // GET: EventosDetails
        public ActionResult Index(int id)
        {
            ReportService service = new ReportService();

            return View(service.getDetailsEvent(id));
        }

        // GET: EventosDetails/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EventosDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventosDetails/Create
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

        // GET: EventosDetails/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EventosDetails/Edit/5
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

        // GET: EventosDetails/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EventosDetails/Delete/5
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
