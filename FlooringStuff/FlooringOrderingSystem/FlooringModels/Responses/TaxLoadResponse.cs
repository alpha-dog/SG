using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringModels.Responses
{
    public class TaxLoadResponse : Response
    {
        public List<Taxes> TaxList { get; set; }
    }
}
