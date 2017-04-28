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
        IEnumerable<Vehicle> GetVehicle(int vehicleId);

        // bools for inserts, deletes, and updates so we can see if they worked
        void AddVehicle(Vehicle vehicle);
        void EditVehicle(Vehicle vehicle);
        void DeleteVehicle(int vehicleId);
        


    }
}
