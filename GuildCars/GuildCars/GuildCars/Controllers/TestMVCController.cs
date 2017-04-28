using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Controllers
{
    public class TestMVCController : Controller
    {
        // GET: TestMVC
        public ActionResult Index()
        {
            return View();
        }

        // GET: TestMVC/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TestMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestMVC/Create
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

        // GET: TestMVC/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TestMVC/Edit/5
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

        // GET: TestMVC/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestMVC/Delete/5
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
