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

        public CustomerController() //I can overload this method if i want to get back a specific number or sort it in some dumb way
        {
            _customerRepo = new CustomerRepo();
        }
        // GET: api/Customer
        [Route("Customers")]
        public IEnumerable<Customer> Get()
        {
            return _customerRepo.GetCustomers();
        }

        // GET: api/Customer/5
        [Route("Customer/{id}")]
        public Customer Get(int id)
        {
            return _customerRepo.GetCustomer(id);
        }

        // POST: api/Customer
        [Route("Customer")]
        [HttpPost]
        public void Post([FromBody]Customer customer)
        {
           _customerRepo.InsertCustomer(customer);
        }

        // PUT: api/Customer/5
        [Route("Customer")]
        [HttpPut]
        public void Put([FromBody]Customer customer)
        {
            _customerRepo.UpdateCustomer(customer);
        }

        [Route("Customer/{id}")]
        [HttpDelete]
        // DELETE: api/Customer/5
        public void Delete(int id)
        {
            _customerRepo.DeleteCustomer(id);
        }
    }
}
