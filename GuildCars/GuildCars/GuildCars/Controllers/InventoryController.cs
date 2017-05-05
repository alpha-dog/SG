using GuildCars.Data.DAL.Repos;
using GuildCars.Models;
using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Controllers
{
    public class InventoryController : Controller
    {
        public ActionResult Index2()
        {
            ViewBag.Message = "Viewbags example text blah blah blah";

            var model = new InventoryViewModel();

            var repo = new VehiclesJoinedRepo();
            model.VehiclesJoined = repo.GetAllVehiclesJoined();

            model.SalesRange = model.VehiclesJoined.OrderBy(s => s.SalePrice).Select(s => s.SalePrice.ToString("c")).Distinct();
            model.YearRange = model.VehiclesJoined.OrderBy(y => y.Year).Select(y => y.Year.ToString()).Distinct();

            //var repo2 = new VehicleRepo();
            //model.Vehicles = repo2.GetVehicles();
            

            return View(model);
        }

        // GET: TestMVC/Details/5
        public ActionResult Details(int id)
        {
            var repo = new VehiclesJoinedRepo();
            var model = repo.GetVehicleJoined(id).SingleOrDefault(); 
            return View(model);
        }

        // GET: TestMVC/Create
        public ActionResult Add()
        {
            var model = new VehiclesJoined();
            return View(model);
        }
        //public ActionResult Add()
        //{
        //    var model = new ListingAddViewModel();

        //    var statesRepo = StatesRepositoryFactory.GetRepository();
        //    var bathroomRepo = BathroomTypesRepositoryFactory.GetRepository();

        //    model.States = new SelectList(statesRepo.GetAll(), "StateId", "StateId");
        //    model.BathroomTypes = new SelectList(bathroomRepo.GetAll(), "BathroomTypeId", "BathroomTypeName");
        //    model.Listing = new Listing();

        //    return View(model);
        //}


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
