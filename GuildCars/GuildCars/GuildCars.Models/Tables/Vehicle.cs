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
        public string Make { get; set; }
        public string Model { get; set; }
        public String Year { get; set; }

    }
}
