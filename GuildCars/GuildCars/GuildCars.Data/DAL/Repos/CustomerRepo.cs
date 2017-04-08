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
        public bool DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool InsertCustomer(Customer customer)
        {
            throw new NotImplementedException();    
        }

        public bool UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
