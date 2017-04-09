using GuildCars.Data.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models.Tables;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using System.Data;

namespace GuildCars.Data.DAL.Repos
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly IDbConnection _db;

        public CustomerRepo()
        {
            _db = new SqlConnection(ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString);
        }
        public void DeleteCustomer(int customerId)
        {
            var p = new DynamicParameters();
            p.Add("@CustomerId", customerId);

            _db.Query<Customer>("CustomerDelete", p, commandType: CommandType.StoredProcedure);

        }

        public IEnumerable<Customer> GetCustomers()
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString;

                return conn.Query<Customer>("CustomersSelectAll", commandType: CommandType.StoredProcedure);
                
            }
        }

        public Customer GetCustomer(int customerId)
        {
            var p = new DynamicParameters();
            p.Add("@CustomerId", customerId);

            using (_db)
            {
                return _db.Query<Customer>("CustomerSelectById", p, commandType: CommandType.StoredProcedure).SingleOrDefault();

            }
        }


        public void InsertCustomer(Customer customer)
        {
            _db.Execute(@"INSERT Customer([FirstName],[LastName]) values (@FirstName, @LastName)", new {FirstName = customer.FirstName, LastName = customer.LastName});
        }

        public void UpdateCustomer(Customer customer)
        {
            var p = new DynamicParameters();
            p.Add("CustomerId", customer.CustomerId);
            p.Add("FirstName", customer.FirstName);
            p.Add("LastName", customer.LastName);


            using (_db)
            {
                _db.Query<Customer>("CustomerUpdate", p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
