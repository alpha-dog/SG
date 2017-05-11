using GuildCars.Data.DAL.Repos;
using GuildCars.Models;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
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
            var model = new InventoryAddViewModel();

            var jrepo = new VehiclesJoinedRepo();

            model.Makes = new SelectList(jrepo.GetAllMakes(), "MakeId", "Make");
            model.Models = new SelectList(jrepo.GetAllModels(), "ModelId", "ModelName");
            model.Types = new SelectList(jrepo.GetAllTypes(), "TypeId", "NewOrUsed");
            model.BodyStyles = new SelectList(jrepo.GetAllBodyStyles(), "BodyStyleId", "BodyStyle");
            model.Transmissions = new SelectList(jrepo.GetAllTransmissions(), "TransmissionId", "TransmissionType");
            model.Colors = new SelectList(jrepo.GetAllColors(), "ColorId", "Color");
            
            model.Vehicle = new Vehicle();

            return View(model);
        }

        // GET: TestMVC/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new InventoryAddViewModel();

            var jrepo = new VehiclesJoinedRepo();

            model.Makes = new SelectList(jrepo.GetAllMakes(), "MakeId", "Make");
            model.Models = new SelectList(jrepo.GetAllModels(), "ModelId", "ModelName");
            model.Types = new SelectList(jrepo.GetAllTypes(), "TypeId", "NewOrUsed");
            model.BodyStyles = new SelectList(jrepo.GetAllBodyStyles(), "BodyStyleId", "BodyStyle");
            model.Transmissions = new SelectList(jrepo.GetAllTransmissions(), "TransmissionId", "TransmissionType");
            model.Colors = new SelectList(jrepo.GetAllColors(), "ColorId", "Color");

            var repo = new VehicleRepo();
            model.Vehicle = repo.GetVehicle(id).SingleOrDefault();

            return View(model);
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
