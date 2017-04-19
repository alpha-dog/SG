using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SUKTIE.Models.Tables
{
    public class Post
    {
        public int PostId { get; set; }
        public string PostName { get; set; }
        [AllowHtml]
        public string PostText { get; set; }
        public string UserId { get; set; }
        public DateTime PostDate { get; set; }
        public string Status { get; set; }

    }
}
