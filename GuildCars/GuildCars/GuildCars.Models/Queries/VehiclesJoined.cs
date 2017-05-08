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
        public string Make { get; set; }
        public int MakeId { get; set; }
        public string ModelName { get; set; }
        public int ModelId { get; set; }
        public int TypeId { get; set; }
        public string NewOrUsed { get; set; }
        public int BodyStyleId { get; set; }
        public string BodyStyle { get; set; }
        public string Year { get; set; }
        public int TransmissionId { get; set; }
        public string TransmissionType { get; set; }
        public int ColorId { get; set; }
        public string ExtColor { get; set; }
        public int InteriorId { get; set; }
        public string IntColor { get; set; }
        public int Mileage { get; set; }
        public string VIN { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalePrice { get; set; }
        public string Description { get; set; }
        public string PictureFilePath { get; set; }
        public bool IsFeature { get; set; }
    }
}
