using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaraokeBar.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

        public virtual ICollection<Tab> Tabz { get; set; }

    }
}