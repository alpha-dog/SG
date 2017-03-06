using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringModels.Responses
{
    public class OrderResponse : Response
    {
       public OrderInfo Order { set; get; }
    }
}
