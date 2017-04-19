using SUKTIE.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SUKTIE.Models
{
    public class SearchViewModel : BaseViewModel
    {
        public string Hashtag { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}