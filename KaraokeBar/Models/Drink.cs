using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaraokeBar.Models
{
    public class Drink
    {
        public int DrinkID { get; set; }
        public string DrinkName { get; set; }

        public virtual ICollection<Tab> DrinkTabs { get; set; }
    }
}