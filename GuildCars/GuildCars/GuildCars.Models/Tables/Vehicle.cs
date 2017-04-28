using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    //i need to create classes in this folder that match the tables in my database
    public class Vehicle 
    {
        //make props that match my table columns in here

        //When building models based on your database objects be sure to pay attention to what 
        //can and cannot be null or you will inevitably run into the dreaded NullReferenceException.
        public int VehicleId { get; set; }
        public int MakeId { get; set; }
        public string Model { get; set; }
        public int TypeId { get; set; }
        public int BodyStyleId { get; set; }    
        public string Year { get; set; }
        public int TransmissionId { get; set; }
        public int ColorId { get; set; }
        public int InteriorId { get; set; }
        public int Mileage { get; set; }
        public string VIN { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalePrice { get; set; }
        public string Description { get; set; }
        public string PictureFilePath { get; set; }
        public bool IsFeature { get; set; }
    }
}
