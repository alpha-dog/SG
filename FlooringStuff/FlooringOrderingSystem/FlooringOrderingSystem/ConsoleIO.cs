using System;
using System.Collections.Generic;
using FlooringModels;

namespace FlooringOrderingSystem
{
    internal class ConsoleIO
    {
        internal static void DisplayOrderDetails(OrderInfo order)
        {
            Console.Write($"Order Number: {order.OrderNumber}");
            Console.WriteLine($"ORDER DATE PLACEHOLDER");
            Console.WriteLine($"{order.CustomerName}");
            Console.WriteLine($"{order.State}");
            Console.WriteLine($"Product: {order.ProductType}");
            Console.WriteLine($"MATERIAL COST PLACEHOLDER");
            Console.WriteLine($"LABOR COST PLACEHOLDER");
            Console.WriteLine($"TAX PLACEHOLDER");
            Console.WriteLine($"TOTAL COST PLACEHOLDER");
        }

        internal static void DisplayDetails(List<OrderInfo> orderInfoList, DateTime userDateInput)
        {
            foreach (var orderInfo in orderInfoList)
            {
                Console.Clear();
                Console.Write($"Order Number: {orderInfo.OrderNumber} ");
                Console.WriteLine($"Date: {userDateInput.ToString("MM/dd/yyyy")}");
                Console.WriteLine($"Name: {orderInfo.CustomerName}");
                Console.WriteLine($"State: {orderInfo.State}");
                Console.WriteLine($"Product: {orderInfo.ProductType}");
                Console.WriteLine($"Material Cost: {orderInfo.MaterialCost}");
                Console.WriteLine($"Labor Cost: {orderInfo.LaborCost}");
                Console.WriteLine($"Taxes: {orderInfo.Tax}");
                Console.WriteLine($"Total: {orderInfo.Total}");
                Console.WriteLine("--------------------------");
            }
        }
    }
}