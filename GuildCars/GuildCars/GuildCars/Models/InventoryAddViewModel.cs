using GuildCars.Data.DAL.Repos;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
//added two classes below because shackup has them
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Models
{
    public class InventoryAddViewModel
    {
        public SelectList Makes { get; set; }
        public int SelectedMakeId { get; set; }
        public SelectList Models { get; set; }
        public int SelectedModelId { get; set; }
        public IEnumerable<SelectListItem> Model { get; set; }
        public IEnumerable<SelectListItem> Type { get; set; }
        public IEnumerable<SelectListItem> BodyStyle { get; set; }
        public IEnumerable<SelectListItem> Transmission { get; set; }
        public IEnumerable<SelectListItem> Color { get; set; }
        public IEnumerable<SelectListItem> Interior { get; set; }
        public IEnumerable<SelectListItem> JoinedVehicle { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}