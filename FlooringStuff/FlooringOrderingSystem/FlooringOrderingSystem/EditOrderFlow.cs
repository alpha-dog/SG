using FlooringBLL;
using FlooringModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem
{
    public class EditOrderFlow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();


            //clear console and get info from customer
            Console.Clear();

            //ask the user for date and order number
            Console.WriteLine("Enter the order date(e.g. 'dd/mm/yyyy') for the order you'd like to edit: ");
            var userDateInput = manager.StringToDate(Console.ReadLine());

            Console.WriteLine("Enter the order number of the order you'd like to edit: ");
            var userOrderInput = int.Parse(Console.ReadLine()); //todo: tryParse would be better

            OrderResponse response = manager.LookupOrder(userDateInput, userOrderInput);

            if (response.Success == true)
            {
                ConsoleIO.DisplayOrderDetails(response.Order);
                var editResponse = ConsoleIO.EditOrderMenu();
                manager.EditOrder(response.Order.OrderDate, response.Order.OrderNumber, editResponse);
            }
            else
            {
                Console.WriteLine(response.Message);
                Console.ReadKey();
            }
        }
    }
}
