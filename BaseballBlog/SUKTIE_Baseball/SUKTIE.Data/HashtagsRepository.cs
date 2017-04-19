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
    public class HashtagsRepository
    {
        public IEnumerable<Hashtag> HashtagsSelectAll()
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["SUKTIE"].ConnectionString;

                return cn.Query<Hashtag>("HashtagsSelectAll", commandType: CommandType.StoredProcedure);
            }
        }
        public IEnumerable<Hashtag> HashtagSelectById(int id)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["SUKTIE"].ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@HashtagId", id);

                return cn.Query<Hashtag>("HashtagSelectById", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public Hashtag Add(Hashtag Hashtag)
        {
            var p = new DynamicParameters();

            p.Add("HashtagId", Hashtag.HashtagId);
            p.Add("HashtagName", Hashtag.HashtagName);

            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["SUKTIE"].ConnectionString))
            {
                Hashtag = db.Query<Hashtag>("HashtagAdd", p, commandType: CommandType.StoredProcedure).Single();
            }

            return Hashtag;
        }
        public IEnumerable<Hashtag> HashtagSelectByPostId(int postId)
        {


            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["SUKTIE"].ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@PostId", postId);

                return cn.Query<Hashtag>("HashtagSelectByPostId", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public void AssociateHashtagsWithPost (IEnumerable<string> postTags, Post post)
        {
            var alreadyAssocHashtags = HashtagSelectByPostId(post.PostId);
            var allHashtags = HashtagsSelectAll();
            foreach (var postTag in postTags)
            {
                var foundTag = allHashtags.SingleOrDefault(h => h.HashtagName == '#' + postTag);
                if (foundTag == null)
                {
                    foundTag = new Hashtag()
                    {
                        HashtagName = '#' + postTag
                    };

                    foundTag = Add(foundTag);
                }
                if (!alreadyAssocHashtags.Any(h => h.HashtagName == foundTag.HashtagName))
                {
                    using (var cn = new SqlConnection())
                    {
                        cn.ConnectionString = ConfigurationManager.ConnectionStrings["SUKTIE"].ConnectionString;

                        var parameters = new DynamicParameters();
                        parameters.Add("@PostId", post.PostId);
                        parameters.Add("@HashtagId", foundTag.HashtagId);

                        cn.Execute("HashtagAssociateWithPost", parameters, commandType: CommandType.StoredProcedure);
                    }
                }
            }
        }
    }
}
