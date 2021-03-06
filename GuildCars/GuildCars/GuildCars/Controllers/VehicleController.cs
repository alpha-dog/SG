﻿using GuildCars.Data.DAL.Repos;
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
        private VehiclesJoinedRepo _joinRepo;

        public VehicleController()//I can overload this method if i want to get back a specific number or sort it in some dumb way
        {
            _vehicleRepo = new VehicleRepo();
            _joinRepo = new VehiclesJoinedRepo();
        }

        // GET: api/Vehicle
        [Route("Vehicles")]
        [AcceptVerbs("GET")]
        public IEnumerable<Vehicle> GetAll()
        {
            return _vehicleRepo.GetVehicles();
        }

        // GET: api/Vehicle/5
        [Route("Vehicle/{id}")]
        public IEnumerable<Vehicle> Get(int id)
        {
            return _vehicleRepo.GetVehicle(id);
        }

        // POST: api/Vehicle
        [Authorize]
        [Route("Vehicle")]
        [HttpPost]
        public void Add([FromBody]Vehicle vehicle)
        {
            _vehicleRepo.AddVehicle(vehicle);
        }

        // PUT: api/Vehicle/5
        [Authorize]
        [Route("Vehicle/{id}")]
        [HttpPut]
        [AcceptVerbs("PUT")]
        public void Edit([FromBody]Vehicle vehicle)
        {
            _vehicleRepo.EditVehicle(vehicle);   
        }

        // DELETE: api/Vehicle/5
        [Authorize]
        [Route("Vehicle/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            _vehicleRepo.DeleteVehicle(id);
        }

        [Route("Vehicle/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Search(string searchVal, string minPrice, string maxPrice, string minYear, string maxYear)
        {
            try
            { 
                //var result = _vehicleRepo.SearchVehicles(searchVal);
                var result2 = _joinRepo.SearchVehiclesWithLINQ(searchVal, minPrice, maxPrice, minYear, maxYear);
                return Ok(result2);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
