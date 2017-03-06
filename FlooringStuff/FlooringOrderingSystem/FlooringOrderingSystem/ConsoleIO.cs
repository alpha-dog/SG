using System;
using System.Collections.Generic;
using FlooringModels;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem
{
    public class ConsoleIO
    {
        public static void DisplayOrderDetails(OrderInfo order)
        {
            Console.WriteLine($"Order Number: {order.OrderNumber}");
            Console.WriteLine($"Name: {order.CustomerName}");
            Console.WriteLine($"State: {order.StateTax.StateAbbreviation}");
            Console.WriteLine($"Product: {order.OrderProduct.ProductType}");
            Console.WriteLine($"Area: {order.Area}");
            Console.WriteLine($"Material Cost: {order.MaterialCost}");
            Console.WriteLine($"Labor Cost: {order.LaborCost}");
            Console.WriteLine($"Tax: {order.Tax}");
            Console.WriteLine($"Total Cost: {order.Total}");
        }

        public static void DisplayDetails(List<OrderInfo> orderInfoList, DateTime userDateInput)
        {
            Console.Clear();
            foreach (var orderInfo in orderInfoList)
            {
                Console.Write($"Order Number: {orderInfo.OrderNumber} ");
                Console.WriteLine($"Date: {userDateInput.ToString("MM/dd/yyyy")}");
                Console.WriteLine($"Name: {orderInfo.CustomerName}");
                Console.WriteLine($"State: {orderInfo.StateTax.State}");
                Console.WriteLine($"Product: {orderInfo.OrderProduct.ProductType}");
                Console.WriteLine($"Material Cost: {orderInfo.MaterialCost}");
                Console.WriteLine($"Labor Cost: {orderInfo.LaborCost}");
                Console.WriteLine($"Taxes: {orderInfo.Tax}");
                Console.WriteLine($"Total: {orderInfo.Total}");
                Console.WriteLine("-----------------------------------------------");
            }
        }

        public static string DeleteConfirmation()
        {
            Console.ReadLine();
            Console.WriteLine("are you sure you want to delete this order?");
            Console.WriteLine("Enter '1' to DELETE, or anything else to CANCEL");
            return Console.ReadLine();
        }

        public static string EditOrderMenu()
        {
            Console.WriteLine("Enter the number associated with the info you would like to edit");
            Console.WriteLine("1. Order Name");
            Console.WriteLine("2. Order State");
            Console.WriteLine("3. Product Type");
            Console.WriteLine("4. Area");
            Console.WriteLine("enter: ");

            return Console.ReadLine();
        }
    }
}