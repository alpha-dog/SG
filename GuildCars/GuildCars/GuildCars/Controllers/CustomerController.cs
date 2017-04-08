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
    public class CustomerController : ApiController
    {
        private CustomerRepo _customerRepo;

        public CustomerController()
        {
            _customerRepo = new CustomerRepo();
        }
        // GET: api/Customer
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Customer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customer
        [Route("Customer")]
        [HttpPost]
        public bool Post([FromBody]Customer customer)
        {
           return _customerRepo.InsertCustomer(customer);
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
    }
}
