using GuildCars.Data.DAL.Repos;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuildCars.Controllers
{
    public class VehicleController : ApiController
    {
        private VehicleRepo _vehicleRepo;

        public VehicleController()//I can overload this method if i want to get back a specific number or sort it in some dumb way
        {
            _vehicleRepo = new VehicleRepo(); 
        }

        // GET: api/Vehicle
        [Route("Vehicles")]
        public IEnumerable<Vehicle> GetAll()
        {
            return _vehicleRepo.GetVehicles();
        }

        // GET: api/Vehicle/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Vehicle
        [Route("Vehicle")]
        [HttpPost]
        public void Add([FromBody]Vehicle vehicle)
        {
            _vehicleRepo.AddVehicle(vehicle);
        }

        // PUT: api/Vehicle/5
        public void Edit(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Vehicle/5
        public void Delete(int id)
        {
        }
    }
}
