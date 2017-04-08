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
    public class VehicleRepo : IVehicleRepo
    {
        //the commented out code below is based off the recommendations from the dapper-web-api tutorial i found: https://www.jeremymorgan.com/blog/programming/how-to-dapper-web-api/
        //private VehicleRepo _secretVehicleRepo = new VehicleRepo();
        public bool DeleteVehicle(int vehicleId)
        {
            throw new NotImplementedException();
        }

        public Vehicle GetVehicle(int vehicleId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehicle> GetVehicles()
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString;

                return conn.Query<Vehicle>("VehiclesSelectAll", commandType: CommandType.StoredProcedure);
            }
        }

        public bool InsertVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public bool UpdateVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
