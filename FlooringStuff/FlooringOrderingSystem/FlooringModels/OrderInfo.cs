using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringModels
{
    public class OrderInfo
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string State { get; set; }
        public decimal TaxRate { get; set; }
        public string ProductType { get; set; }
        public decimal Area { get; set; }
        //gotta do the math on the rest of them
        public decimal CostPerSquareFoot = -1;          
        public decimal LaborCostPerSquareFoot = -1;
        public decimal MaterialCost = -1;
        public decimal LaborCost = - 1;
        public decimal Tax = -1;
        public decimal Total = -1;




    }
}
