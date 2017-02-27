using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringModels.Responses
{
    public class DisplayResponse : Response 
    {
        public List<OrderInfo> OrderInfoList { get; set; }
    }
}
