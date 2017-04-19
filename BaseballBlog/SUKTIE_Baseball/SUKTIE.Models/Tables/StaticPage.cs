using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUKTIE.Models.Tables
{
    public class StaticPage
    {
        public int StaticPageId { get; set; }
        public string StaticPageName { get; set; }
        public string StaticPageBody { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }

    }
}
