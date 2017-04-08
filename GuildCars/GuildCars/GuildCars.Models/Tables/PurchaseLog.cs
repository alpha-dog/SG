using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class PurchaseLog
    {
        public int PurchaseId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
    }
}
