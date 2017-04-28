using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Vehicle> vehicles { get; set; }
        public IEnumerable<Specials> specials { get; set; }

    }

    public class InventoryViewModel
    {

    }
}