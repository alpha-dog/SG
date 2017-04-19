using SUKTIE.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SUKTIE.Models
{
    public class BaseViewModel
    {
        public List<Post> Recent15 { get; set; }
        public string Hashtag { get; set; }
        public List<StaticPage> StaticPages { get; set; }
    }
}