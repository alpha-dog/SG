using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.DAL
{
    interface IVehicleRepo
    {
        //CRUD methods go in here
        IEnumerable<Vehicle> GetVehicles();
        Vehicle GetVehicle(int vehicleId);

        // bools for inserts, deletes, and updates so we can see if they worked
        bool InsertVehicle(Vehicle vehicle);
        bool DeleteVehicle(int vehicleId);
        bool UpdateVehicle(Vehicle vehicle);


    }
}
