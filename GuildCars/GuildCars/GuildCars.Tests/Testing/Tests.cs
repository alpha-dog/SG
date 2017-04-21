using GuildCars.Data.DAL.Repos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Tests.Testing
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Init()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString))
            {
                var command = new SqlCommand();
                command.CommandText = "CarReset";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Connection = conn;
                conn.Open();

                command.ExecuteNonQuery();
            }
        }

        [Test]
        public void CanLoadVehicles()
        {
            var repo = new VehicleRepo();
            var vehicles = repo.GetVehicles().ToList();

            Assert.AreEqual(2, vehicles.Count);

            Assert.AreEqual("VW", vehicles[0].MakeId);
        }

        [Test]
        public void CanLoadSalesInfos()
        {
            var repo = new SalesInfoRepo();
            var SalesInfos = repo.GetSalesInfos().ToList();

            Assert.AreEqual(2, SalesInfos.Count);
            Assert.AreEqual("Marshawn", SalesInfos[0].FirstName);
            Assert.AreEqual("David", SalesInfos[1].LastName);
        }

        [Test]
        public void Can()
        {
            var repo = new SalesPersonRepo();
            var SalesPeople = repo.GetSalesPeople().ToList();

            Assert.AreEqual(2, SalesPeople.Count);
            Assert.AreEqual("Joby", SalesPeople[0].FirstName);
        }



    }
}
