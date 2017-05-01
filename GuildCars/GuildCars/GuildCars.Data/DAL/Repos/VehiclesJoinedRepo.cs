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

namespace GuildCars.Data.DAL.Repos
{
    public class VehiclesJoinedRepo : IVehiclesJoinedRepo 
    {
        private readonly IDbConnection _db;

        public VehiclesJoinedRepo()
        {
            _db = new SqlConnection(ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString);
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

        public IEnumerable<VehiclesJoined> SearchVehiclesWithLINQ (string searchVal)
        {
            var carList = GetAllVehiclesJoined();
            var searchResults = carList.Where(v => v.Model.StartsWith(searchVal) || v.Year.StartsWith(searchVal) || v.Make.ToString().StartsWith(searchVal));
            return searchResults;                            
        }

        /*
        from Vehicle

        join Make
            on Vehicle.MakeId = make.MakeId
        join [Type]
            on Vehicle.TypeId = [Type].TypeId
        join BodyStyle
            on Vehicle.BodyStyleId = BodyStyle.BodyStyleId
        join Transmission
            on Vehicle.TransmissionId = Transmission.TransmissionId
        join Color  
            on Vehicle.ColorId = Color.ColorId
        where Model like @SearchVal + '%' OR 
            [Year] like @SearchVal + '%' OR 
            Make.MakeName like @SearchVal + '%';
         */
    }
}
