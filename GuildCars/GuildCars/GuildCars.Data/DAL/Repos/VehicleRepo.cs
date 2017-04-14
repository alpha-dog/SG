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
        private readonly IDbConnection _db;

        public VehicleRepo()
        {
            _db = new SqlConnection(ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString);
        }
        //the commented out code below is based off the recommendations from the dapper-web-api tutorial i found: https://www.jeremymorgan.com/blog/programming/how-to-dapper-web-api/
        //private VehicleRepo _secretVehicleRepo = new VehicleRepo();

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
        public void AddVehicle(Vehicle vehicle)
        {
            //this seems too repetitive to be correct
            var p = new DynamicParameters();
            p.Add("VehicleId", vehicle.VehicleId);
            p.Add("Make", vehicle.Make);
            p.Add("Model", vehicle.Model);
            p.Add("TypeId", vehicle.TypeId);
            p.Add("BodyStyleId", vehicle.BodyStyleId);
            p.Add("Year", vehicle.Year);
            p.Add("TransmissionId", vehicle.TransmissionId);
            p.Add("ColorId", vehicle.ColorId);
            p.Add("InteriorId", vehicle.InteriorId);
            p.Add("Mileage", vehicle.Mileage);
            p.Add("VIN", vehicle.VIN);
            p.Add("MSRP", vehicle.MSRP);
            p.Add("SalePrice", vehicle.SalePrice);
            p.Add("Description", vehicle.Description);
            p.Add("PictureFilePath", vehicle.PictureFilePath);


            //_db.Execute(@"INSERT SalesInfo([FirstName],[LastName]) values (@FirstName, @LastName)", new {FirstName = SalesInfo.FirstName, LastName = SalesInfo.LastName});
            _db.Query<Vehicle>("AddVehicles", p, commandType: CommandType.StoredProcedure);
        }

        public void EditVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
        public void DeleteVehicle(int vehicleId)
        {
            throw new NotImplementedException();
        }
    }
}
