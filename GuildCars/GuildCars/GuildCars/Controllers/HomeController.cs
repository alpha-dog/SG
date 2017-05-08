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
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            var jepo = new VehiclesJoinedRepo();
            var repo = new VehicleRepo();

            var model = new HomeViewModel();

            model.vehicles = jepo.GetAllVehiclesJoined();
            model.specials = repo.GetSpecials(); 

            return View(model);
        }

        public ActionResult Inventory()
        {
            ViewBag.Message = "Viewbags example text blah blah blah";

            var repo = new VehiclesJoinedRepo();
            var model = repo.GetAllVehiclesJoined();
            
            return View(model);
        }

        public ActionResult Specials()
        {
            ViewBag.Message = "SPECIALS!!!!!";
            var repo = new VehicleRepo();
            var model = new HomeViewModel();
            model.specials = repo.GetSpecials().ToList();

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}