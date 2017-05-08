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

		public IEnumerable<Specials> GetSpecials()
		{
			using (var conn = new SqlConnection())
			{
				conn.ConnectionString = ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString;

				return conn.Query<Specials>("SpecialsGetAll", commandType: CommandType.StoredProcedure);
			}
		}
		public IEnumerable<Specials> GetSpecial(int specialId)
		{
			var p = new DynamicParameters();
			p.Add("@SpecialId", specialId);
			using (_db)
			{
				return _db.Query<Specials>("SpecialSelectById", p, commandType: CommandType.StoredProcedure);
			}
		}
		//the commented out code below is based off the recommendations from the dapper-web-api tutorial i found: https://www.jeremymorgan.com/blog/programming/how-to-dapper-web-api/
		//private VehicleRepo _secretVehicleRepo = new VehicleRepo();

		public void AddSpecial(Specials special)
		{
			var p = new DynamicParameters();

			p.Add("SpecialId", special.SpecialId);
			p.Add("SpecialName", special.SpecialName);
			p.Add("SpecialDetails", special.SpecialDetails);

			using (_db)
			{
				_db.Query<Specials>("SpecialAdd", p, commandType: CommandType.StoredProcedure);
			}
		}

		public void DeleteSpecial(int specialId)
		{
			var p = new DynamicParameters();

			p.Add("SpecialId", specialId);

			using (_db)
			{
				_db.Query<Specials>("SpecialDelete", p, commandType: CommandType.StoredProcedure);
			}
		}


		public IEnumerable<Vehicle> GetVehicles()
		{
			using (var conn = new SqlConnection())
			{
				conn.ConnectionString = ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString;

				return conn.Query<Vehicle>("VehiclesGetAll", commandType: CommandType.StoredProcedure);
			}
		}

		public IEnumerable<Vehicle> GetVehicle(int vehicleId)
		{
			var p = new DynamicParameters();
			p.Add("@VehicleId", vehicleId);
			using (_db)
			{
				return _db.Query<Vehicle>("VehicleSelectById", p, commandType: CommandType.StoredProcedure);
			}
		}

		public IEnumerable<Vehicle> SearchVehicles(string searchVal)
		{
			var p = new DynamicParameters();
			p.Add("@SearchVal", searchVal);
			using (_db)
			{
				return _db.Query<Vehicle>("VehicleSearch", p, commandType: CommandType.StoredProcedure);
			}
		}

		public void AddVehicle(Vehicle vehicle)
		{
			//this seems too repetitive to be correct
			var p = new DynamicParameters();
			p.Add("VehicleId", vehicle.VehicleId);
			p.Add("MakeId", vehicle.MakeId);
			p.Add("ModelId", vehicle.ModelId);
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
			p.Add("IsFeature", vehicle.IsFeature);


			//_db.Execute(@"INSERT SalesInfo([FirstName],[LastName]) values (@FirstName, @LastName)", new {FirstName = SalesInfo.FirstName, LastName = SalesInfo.LastName});
			_db.Query<Vehicle>("AddVehicles", p, commandType: CommandType.StoredProcedure);
		}

		public void EditVehicle(Vehicle vehicle)
		{
			var p = new DynamicParameters();
			p.Add("VehicleId", vehicle.VehicleId);
			p.Add("MakeId", vehicle.MakeId);
			p.Add("ModelId", vehicle.ModelId);
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
			p.Add("IsFeature", vehicle.IsFeature);


			//I'm doing a terrible job of following naming conventions VS and SQL but I'm tired and don't care right now. ToDo update naming conventions later to be consistent
			_db.Query<Vehicle>("VehicleUpdate", p, commandType: CommandType.StoredProcedure);
		}
		public void DeleteVehicle(int vehicleId)
		{
			var p = new DynamicParameters();
			p.Add("@VehicleId", vehicleId);

			_db.Query<Vehicle>("VehicleDelete", p, commandType: CommandType.StoredProcedure);
		}
    }
}
