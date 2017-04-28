using GuildCars.Models.Queries; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.DAL.Interfaces
{
    interface IVehiclesJoinedRepo
    {
        IEnumerable<VehiclesJoined> GetAllVehiclesJoined();
        IEnumerable<VehiclesJoined> GetVehiclesJoined(string searchVal);
        //not sure what I'm doing here. I'm thinking the vehicles can only be edited, etc in their original table format 
        //void AddVehicle(VehiclesJoined vehicle);
        //void EditVehicle(VehiclesJoined vehicle);
        //void DeleteVehicle(int vehicleId);
    }
}
