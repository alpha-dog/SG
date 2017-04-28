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
    public class SpecialsController : ApiController
    {
        // GET: api/Specials
        [Route("Specials")]
        public IEnumerable<Specials> Get()
        {
            var repo = new VehicleRepo();
            return repo.GetSpecials();
        }

        // GET: api/Specials/5
        [Route("Specials/{id}")]
        public IEnumerable<Specials> GetSpecial(int id)
        {
            var repo = new VehicleRepo();
            return repo.GetSpecial(id);
        }

        // POST: api/Specials
        [Route("Specials")]
        [HttpPost]
        public void Add([FromBody]Specials special)
        {
            var repo = new VehicleRepo();
            repo.AddSpecial(special);
        }


        // DELETE: api/Specials/5
        [Route("Specials/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            var repo = new VehicleRepo();
            repo.DeleteSpecial(id);
        }
    }
}
