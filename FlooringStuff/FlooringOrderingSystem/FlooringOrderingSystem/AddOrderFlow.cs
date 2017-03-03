using FlooringBLL;
using FlooringModels;
using FlooringModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem
{
    public class AddOrderFlow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            OrderInfo newOrder = new OrderInfo();

            //clear console and get info from customer
            Console.Clear();
            Console.WriteLine("Enter a future order date (e.g. 'dd/mm/yyyy') to create a new order: ");
            newOrder.OrderDate = manager.StringToDate(Console.ReadLine()); 
             
            Console.WriteLine("Enter a name for the order: ");
            newOrder.CustomerName = Console.ReadLine();

            Console.WriteLine("Enter which state the order is in: ");
            newOrder.State = Console.ReadLine();

            Console.WriteLine("Enter a product type for the order :");
            newOrder.ProductType = Console.ReadLine();

            Console.WriteLine("Enter the square footage (must be over 100)");
            newOrder.Area = decimal.Parse(Console.ReadLine());






        }
    }
}
