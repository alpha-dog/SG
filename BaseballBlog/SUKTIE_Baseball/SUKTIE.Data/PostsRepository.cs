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
    public class PostsRepository
    {
        public IEnumerable<Post> PostsSelectAll()
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["SUKTIE"].ConnectionString;

                return cn.Query<Post>("PostsSelectAll", commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Post> PostsSelectByHashtagId(int hashtagId)
        {


            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["SUKTIE"].ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@HashtagId", hashtagId);

                return cn.Query<Post>("PostSelectByHashtagId", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public IEnumerable<Post> PostsSelectMostRecent()
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["SUKTIE"].ConnectionString;

                return cn.Query<Post>("PostSelectMostRecent", commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Post> PostsSelect15()
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["SUKTIE"].ConnectionString;

                return cn.Query<Post>("PostsSelectNewest15", commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Post> PostSelectById(int id)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["SUKTIE"].ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@PostId", id);

                return cn.Query<Post>("PostSelectById", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public Post Add(Post post)
        {
            var p = new DynamicParameters();

            p.Add("PostId", post.PostId);
            p.Add("PostName", post.PostName);
            p.Add("PostText", post.PostText);
            p.Add("UserId", post.UserId);
            p.Add("PostDate", DateTime.Now);
            p.Add("Status", "Draft");

            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["SUKTIE"].ConnectionString))
            {
                post = db.Query<Post>("PostAdd", p, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }

            return post;
        }

        public IEnumerable<Post> PostsSelectByHashtagName(string hashtagName)
        {


            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["SUKTIE"].ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@HashtagName", hashtagName);

                return cn.Query<Post>("PostSelectByHashtagName", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

