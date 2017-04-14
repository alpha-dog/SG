using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.DAL.Interfaces
{
    interface ISalesPersonRepo
    {
        IEnumerable<SalesPerson> GetSalesPeople();
        SalesInfo GetSalesPerson(int SalesPersonId);

        // bools for inserts, deletes, and updates so we can see if they worked
        bool InsertSalesPerson(SalesPerson salesPerson);
        bool DeleteSalesPerson(int salesPersonId);
        bool UpdateSalesPerson(SalesPerson salesPerson);
    }
}
