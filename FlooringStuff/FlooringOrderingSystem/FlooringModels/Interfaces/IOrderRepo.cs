using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringModels
{
    public  interface IOrderRepo //i don't like interfaces
    {
        
        List<OrderInfo> LoadOrders(DateTime userDateInput);//

        void SaveOrder(OrderInfo order);
    }
}
