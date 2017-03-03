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
        public string State { get; set; }                      //todo maybe

        public decimal TaxRate { get; set; }                 //todo maybe
        public string ProductType { get; set; }             //todo maybe
        public decimal Area { get; set; }                   //todo maybe

        public decimal CostPerSquareFoot { get; set; }        //todo maybe
               
        public decimal LaborCostPerSquareFoot { get; set; }   //todo maybe

        private decimal materialCost;
        public decimal MaterialCost
        {
            get { return Area * CostPerSquareFoot; }
            set { materialCost = value; }
        }
        private decimal laborCost;
        public decimal LaborCost
        {
            get {return Area * LaborCostPerSquareFoot; }
            set { laborCost = value; }

        }
        private decimal tax;
        public decimal Tax
        {
            get { return ((MaterialCost + LaborCost) * (TaxRate / 100)); }
            set { tax = value; }
        }
        private decimal total;
        public decimal Total
        {
            get { return MaterialCost + LaborCost + Tax; }
            set { total = value; }
        }





    }
}
