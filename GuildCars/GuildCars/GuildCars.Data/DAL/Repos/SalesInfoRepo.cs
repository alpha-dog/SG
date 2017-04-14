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
    public class SalesInfoRepo : ISalesInfoRepo
    {
        private readonly IDbConnection _db;

        public SalesInfoRepo()
        {
            _db = new SqlConnection(ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString);
        }
        public void DeleteSalesInfo(int SalesInfoId)
        {
            var p = new DynamicParameters();
            p.Add("@SalesInfoId", SalesInfoId);

            _db.Query<SalesInfo>("SalesInfoDelete", p, commandType: CommandType.StoredProcedure);

        }

        public IEnumerable<SalesInfo> GetSalesInfos()
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString;

                return conn.Query<SalesInfo>("SalesInfosSelectAll", commandType: CommandType.StoredProcedure);
                
            }
        }

        public SalesInfo GetSalesInfo(int SalesInfoId)
        {
            var p = new DynamicParameters();
            p.Add("@SalesInfoId", SalesInfoId);

            using (_db)
            {
                return _db.Query<SalesInfo>("SalesInfoSelectById", p, commandType: CommandType.StoredProcedure).SingleOrDefault();

            }
        }


        public void InsertSalesInfo(SalesInfo SalesInfo)
        {
            //this seems too repetitive to be correct
            var p = new DynamicParameters();
            p.Add("SalesInfoId", SalesInfo.SalesInfoId);
            p.Add("FirstName", SalesInfo.FirstName);
            p.Add("LastName", SalesInfo.LastName);
            p.Add("Phone", SalesInfo.Phone);
            p.Add("Email", SalesInfo.Email);
            p.Add("Street1", SalesInfo.Street1);
            p.Add("Street2", SalesInfo.Street2);
            p.Add("City", SalesInfo.City);
            p.Add("State", SalesInfo.State);
            p.Add("Zip", SalesInfo.Zip);
            p.Add("PurchasePrice", SalesInfo.PurchasePrice);
            p.Add("PurchaseTypeId", SalesInfo.PurchaseTypeId);

            //_db.Execute(@"INSERT SalesInfo([FirstName],[LastName]) values (@FirstName, @LastName)", new {FirstName = SalesInfo.FirstName, LastName = SalesInfo.LastName});
            _db.Query<SalesInfo>("SalesInfoAdd", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateSalesInfo(SalesInfo SalesInfo)
        {
            var p = new DynamicParameters();
            p.Add("SalesInfoId", SalesInfo.SalesInfoId);
            p.Add("FirstName", SalesInfo.FirstName);
            p.Add("LastName", SalesInfo.LastName);
            p.Add("Phone", SalesInfo.Phone);
            p.Add("Email", SalesInfo.Email);
            p.Add("Street1", SalesInfo.Street1);
            p.Add("Street2", SalesInfo.Street2);
            p.Add("City", SalesInfo.City);
            p.Add("State", SalesInfo.State);
            p.Add("Zip", SalesInfo.Zip);
            p.Add("PurchasePrice", SalesInfo.PurchasePrice);
            p.Add("PurchaseTypeId", SalesInfo.PurchaseTypeId);

            using (_db)
            {
                _db.Query<SalesInfo>("SalesInfoUpdate", p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
