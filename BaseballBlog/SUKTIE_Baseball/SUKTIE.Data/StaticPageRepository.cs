using Dapper;
using SUKTIE.Models.Tables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUKTIE.Data
{
    public class StaticPageRepository
    {
        public IEnumerable<StaticPage> StaticPageSelectAll()
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["SUKTIE"].ConnectionString;

                return cn.Query<StaticPage>("StaticPageSelectAll", commandType: CommandType.StoredProcedure);
            }
        }

        public StaticPage Add(StaticPage staticPage)
        {
            var p = new DynamicParameters();

            p.Add("StaticPageId", staticPage.StaticPageId);
            p.Add("StaticPageName", staticPage.StaticPageName);
            p.Add("StaticPageBody", staticPage.StaticPageBody);
            p.Add("UserId", staticPage.UserId);
            p.Add("Status", "Draft");

            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["SUKTIE"].ConnectionString))
            {
                db.Query<StaticPage>("StaticPageAdd", p, commandType: CommandType.StoredProcedure);
            }

            return staticPage;
        }

        public IEnumerable<StaticPage> StaticPageSelectById(int id)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["SUKTIE"].ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@StaticPageId", id);

                return cn.Query<StaticPage>("StaticPageSelectById", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public StaticPage Edit(StaticPage staticPage)
        {
            var p = new DynamicParameters();

            p.Add("StaticPageId", staticPage.StaticPageId);
            p.Add("StaticPageName", staticPage.StaticPageName);
            p.Add("StaticPageBody", staticPage.StaticPageBody);
            p.Add("UserId", staticPage.UserId);
            p.Add("Status", "Draft");

            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["SUKTIE"].ConnectionString))
            {
                db.Query<StaticPage>("StaticPageEdit", p, commandType: CommandType.StoredProcedure);
            }

            return staticPage;
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();

            p.Add("StaticPageId", id);
            

            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["SUKTIE"].ConnectionString))
            {
                db.Query<StaticPage>("StaticPageDelete", p, commandType: CommandType.StoredProcedure);
            }

            
        }


    }
}
