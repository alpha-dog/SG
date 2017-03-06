using FlooringBLL;
using FlooringModels.Responses;
using System;

namespace FlooringOrderingSystem
{
    public class RemoveOrderFlow
    {
        internal void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            //clear console and get info from customer
            Console.Clear();

            //ask the user for date and order number to delete
            Console.WriteLine("Enter the order date(e.g. 'dd/mm/yyyy') for the order you'd like to delete: ");
            var userDateInput = manager.StringToDate(Console.ReadLine());

            Console.WriteLine("Enter the order number of the order you'd like to delete: ");
            var userOrderInput = int.Parse(Console.ReadLine()); //todo: tryParse would be better

            OrderResponse response = manager.LookupOrder(userDateInput, userOrderInput);

            if (response.Success == true)
            {
                ConsoleIO.DisplayOrderDetails(response.Order);
                var deleteResponse = ConsoleIO.DeleteConfirmation();
                manager.RemoveOrder(response.Order.OrderDate, response.Order.OrderNumber, deleteResponse);
            }
            else
            {
                Console.WriteLine(response.Message);
                Console.ReadKey();
            }
        }
    }
}