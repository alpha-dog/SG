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
        public SelectList Types { get; set; }
        public int SelectedTypeId { get; set; }
        public SelectList BodyStyles { get; set; }
        public int SelectedBodyStyleId { get; set; }
        public SelectList Transmissions { get; set; }
        public int SelectedTransmissionId { get; set; }
        public SelectList Colors { get; set; }
        public int SelectedColorId { get; set; }
        public SelectList Interiors { get; set; }
        public int SelectedInteriorId { get; set; }
        public SelectList JoinedVehicle { get; set; }
        public bool IsFeature { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}