using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringModels
{
    public class OrderInfo
    {
        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }

        public Taxes StateTax { get; set; }
        public Products OrderProduct { get; set; }
        //public string State { get; set; }                      //todo maybe

        //public decimal TaxRate { get; set; }                 //todo maybe
        /*public string ProductType { get; set; } */            //todo maybe
        public decimal Area { get; set; }                   //todo maybe

        //public decimal CostPerSquareFoot { get; set; }        //todo maybe

        //public decimal LaborCostPerSquareFoot { get; set; }   //todo maybe

        public decimal MaterialCost { get { return Area * OrderProduct.CostPerSquareFoot; } }

        public decimal LaborCost { get { return Area * OrderProduct.LaborCostPerSquareFoot; } }
        public decimal Tax { get { return ((MaterialCost + LaborCost) * (StateTax.TaxRate / 100)); } }
        public decimal Total { get { return MaterialCost + LaborCost + Tax; } }





    }
}
