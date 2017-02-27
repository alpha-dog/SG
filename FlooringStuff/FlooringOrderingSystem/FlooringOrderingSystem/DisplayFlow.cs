using FlooringBLL;
using FlooringModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem
{
    public class DisplayFlow
    {
        //REMEMBER: this workflow only handles displaying orders. There's separate workflows for creating, editing, and removing accounts
        public void Execute() 
        {
            // make a new orderManager object by calling up the AMFactory's create method
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Enter a date (e.g. 06/01/2013) to view the orders for that day");

            DateTime userDateInput = manager.StringToDate(Console.ReadLine());

            //I converted the the code on the line below to the StringToDate method above so that a proper DateTime would be gauranteed
            //DateTime userDateInput = DateTime.Parse(Console.ReadLine()); 

            DisplayResponse response = manager.LoadOrders(userDateInput);

            if (response.Success)
            {
                ConsoleIO.DisplayDetails(response.OrderInfoList, userDateInput);
            }
            else
            {
                Console.WriteLine("There are no orders for that date in the system");
            }
            Console.WriteLine("press any key to go back to the menu");
            Console.ReadKey();
        } 
    }
}
