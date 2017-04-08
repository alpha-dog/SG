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
    public class SalesPersonRepo : ISalesPersonRepo
    {
        public bool DeleteSalesPerson(int salesPersonId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SalesPerson> GetSalesPeople()
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString;
                return conn.Query<SalesPerson>("SalesPersonSelectAll", commandType: CommandType.StoredProcedure); //I'm using system.data so i don't need to fully qualify CommandType
            }
            
        }

        public Customer GetSalesPerson(int SalesPersonId)
        {
            throw new NotImplementedException();
        }

        public bool InsertSalesPerson(SalesPerson salesPerson)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSalesPerson(SalesPerson salesPerson)
        {
            throw new NotImplementedException();
        }
    }
}
