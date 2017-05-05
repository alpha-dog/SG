using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.Models
{
    public class InventoryViewModel
    {
        public IEnumerable<VehiclesJoined> VehiclesJoined { get; set; }
        //public IEnumerable<Vehicle> Vehicles { get; set; }
        public IEnumerable<string> SalesRange { get; set; }
        public IEnumerable<string> YearRange { get; set; }
    }

    
}