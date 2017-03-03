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

            Console.Clear();
            Console.Write("Enter a future order date (e.g. 'dd/mm/yyyy') to create a new order: ");
            DateTime newOrderDate = manager.StringToDate(Console.ReadLine());

            //put this in the consoleIO
            OrderInfo newOrder = new OrderInfo();
            Console.Write("Enter a name for the order: ");
            newOrder.CustomerName = Console.ReadLine();
            Console.Write("Enter which state the order is in: ");
            newOrder.State = Console.ReadLine();
            Console.WriteLine("Enter a product type for the order :");
            newOrder.ProductType = Console.ReadLine();
            Console.WriteLine("Enter the square footage (must be over 100)");
            newOrder.Area = decimal.Parse(Console.ReadLine());

            


            //Check to see if order file for that date already exists
            DisplayResponse response = manager.LoadOrders(newOrderDate);

                //if it does, open it and append
                //if it doesn't, create new and add order





        }
    }
}
