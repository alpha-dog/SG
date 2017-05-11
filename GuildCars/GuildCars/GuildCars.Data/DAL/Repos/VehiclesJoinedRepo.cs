using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models.Queries;
using GuildCars.Data.DAL.Interfaces;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using GuildCars.Models.Tables;

namespace GuildCars.Data.DAL.Repos
{
    public class VehiclesJoinedRepo : IVehiclesJoinedRepo 
    {
        private readonly IDbConnection _db;

        public VehiclesJoinedRepo()
        {
            _db = new SqlConnection(ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString);
        }

        public IEnumerable<VehiclesJoined> GetVehicleJoined(int vehicleId)
        {
            var p = new DynamicParameters();
            p.Add("@VehicleId", vehicleId);
            using (_db)
            {
                return _db.Query<VehiclesJoined>("VehicleSelectWithJoins", p, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<VehiclesJoined> GetAllVehiclesJoined()
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString;

                return conn.Query<VehiclesJoined>("VehicleGetAllWithJoins", commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<VehiclesJoined> GetVehiclesJoined(string searchVal)
        {
            var p = new DynamicParameters();
            p.Add("@SearchVal", searchVal);

            using (_db)
            {
                return _db.Query<VehiclesJoined>("VehicleSearch", p, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<VehiclesJoined> SearchVehiclesWithLINQ (string searchVal, string minPrice, string maxPrice, string minYear, string maxYear)
        {
            var carList = GetAllVehiclesJoined();
            if (!string.IsNullOrWhiteSpace(searchVal))
            {
                carList = carList.Where(v => v.ModelName.ToUpper().StartsWith(searchVal.ToUpper()) || v.Year.StartsWith(searchVal) || v.Make.ToString().ToUpper().StartsWith(searchVal.ToUpper()));
            }
            if (!string.IsNullOrWhiteSpace(minPrice))
            {
                string noDollarMinPrice = minPrice.Remove(0, 1);
                decimal decMinPrice = decimal.Parse(noDollarMinPrice);
                carList = carList.Where(p => p.SalePrice >= decMinPrice);
            }
            if (!string.IsNullOrWhiteSpace(maxPrice))
            {
                string noDollarMaxPrice = maxPrice.Remove(0, 1);
                decimal decMaxPrice = decimal.Parse(noDollarMaxPrice);
                carList = carList.Where(p => p.SalePrice <= decMaxPrice);
            }
            if (!string.IsNullOrWhiteSpace(minYear))
            {
                int intMinYear = int.Parse(minYear);
                carList = carList.Where(y => int.Parse(y.Year) >= intMinYear);
            }
            if (!string.IsNullOrWhiteSpace(maxYear))
            {
                int intMaxYear = int.Parse(maxYear);
                carList = carList.Where(y => int.Parse(y.Year) <= intMaxYear);
            }

            return carList;
                                        
        }
        public IEnumerable<VehicleModels> GetAllModels()
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString;

                return conn.Query<VehicleModels>("GetAllModels", commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<VehicleMake> GetAllMakes()
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString;

                return conn.Query<VehicleMake>("select * from Make", commandType: CommandType.Text);
            }
        }

        public IEnumerable<VehicleBodyStyle> GetAllBodyStyles()
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString;

                return conn.Query<VehicleBodyStyle>("select * from BodyStyle", commandType: CommandType.Text);
            }
        }
        public IEnumerable<VehicleColor> GetAllColors()
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString;

                return conn.Query<VehicleColor>("select * from Color", commandType: CommandType.Text);
            }
        }

        public IEnumerable<VehicleTransmission> GetAllTransmissions()
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString;

                return conn.Query<VehicleTransmission>("select * from Transmission", commandType: CommandType.Text);
            }
        }

        public IEnumerable<VehicleType> GetAllTypes()
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString;

                return conn.Query<VehicleType>("select * from Type", commandType: CommandType.Text);
            }
        }

    }
}
