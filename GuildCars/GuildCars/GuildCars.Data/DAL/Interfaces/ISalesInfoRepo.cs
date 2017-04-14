using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.DAL.Interfaces
{
    interface ISalesInfoRepo
    {
        IEnumerable<SalesInfo> GetSalesInfos();
        SalesInfo GetSalesInfo(int SalesInfoId);

        // bools for inserts, deletes, and updates so we can see if they worked
        void InsertSalesInfo(SalesInfo SalesInfo);
        void DeleteSalesInfo(int SalesInfoId);
        void UpdateSalesInfo(SalesInfo SalesInfo);
    }
}
