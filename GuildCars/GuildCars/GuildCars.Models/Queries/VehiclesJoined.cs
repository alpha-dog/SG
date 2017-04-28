using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class VehiclesJoined
    {
        public int VehicleId { get; set; }
        public int Make { get; set; }
        public string Model { get; set; }
        public int Type { get; set; }
        public int BodyStyle { get; set; }
        public string Year { get; set; }
        public int Transmission { get; set; }
        public int Color { get; set; }
        //public int InteriorId { get; set; }
        public int Mileage { get; set; }
        public string VIN { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalePrice { get; set; }
        public string Description { get; set; }
        public string PictureFilePath { get; set; }
        public bool IsFeature { get; set; }
    }
}
