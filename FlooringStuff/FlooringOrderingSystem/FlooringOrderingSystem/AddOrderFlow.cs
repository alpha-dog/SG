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
            

            //clear console and get info from customer
            Console.Clear();

            //adding user inputed info for order
            Console.WriteLine("Enter a future order date (e.g. 'dd/mm/yyyy') to create a new order: ");
            var userDate = manager.StringToDate(Console.ReadLine());
            //newOrder.OrderDate = manager.StringToDate(Console.ReadLine()); 
             
            Console.WriteLine("Enter a name for the order: ");
            var userName = Console.ReadLine();
            //newOrder.CustomerName = Console.ReadLine();

            Console.WriteLine("Enter the State abreviation for the order: ");
            var userAbbreviation = Console.ReadLine();
            //newOrder.StateTax.StateAbbreviation = Console.ReadLine();

            Console.WriteLine("Enter a product type for the order :");
            var userProdType = Console.ReadLine();
            //newOrder.OrderProduct.ProductType = Console.ReadLine();

            Console.WriteLine("Enter the square footage (must be over 100)");
            var userArea = Console.ReadLine();
            //newOrder.Area = decimal.Parse(Console.ReadLine());

            //sending to factory manager to get calculated info
            manager.AddOrder(userDate, userName, userAbbreviation, userProdType, userArea);








        }
    }
}
