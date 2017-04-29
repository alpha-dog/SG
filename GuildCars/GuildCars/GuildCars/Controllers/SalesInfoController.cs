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
    //NO LONGER NEEDED
    public class SalesInfoController : ApiController
    {
        private SalesInfoRepo _SalesInfoRepo;

        public SalesInfoController() //I can overload this method if i want to get back a specific number or sort it in some dumb way
        {
            _SalesInfoRepo = new SalesInfoRepo();
        }
        // GET: api/SalesInfo
        [Route("SalesInfo")]
        public IEnumerable<SalesInfo> Get()
        {
            return _SalesInfoRepo.GetSalesInfos();
        }

        // GET: api/SalesInfo/5
        [Route("SalesInfo/{id}")]
        public SalesInfo Get(int id)
        {
            return _SalesInfoRepo.GetSalesInfo(id);
        }

        // POST: api/SalesInfo
        [Route("SalesInfo")]
        [HttpPost]
        public void Post([FromBody]SalesInfo SalesInfo)
        {
           _SalesInfoRepo.InsertSalesInfo(SalesInfo);
        }

        // PUT: api/SalesInfo/5
        [Route("SalesInfo/{id}")]
        [HttpPut]
        public void Put([FromBody]SalesInfo SalesInfo)
        {
            _SalesInfoRepo.UpdateSalesInfo(SalesInfo);
        }

        [Route("SalesInfo/{id}")]
        [HttpDelete]
        // DELETE: api/SalesInfo/5
        public void Delete(int id)
        {
            _SalesInfoRepo.DeleteSalesInfo(id);
        }
    }
}
