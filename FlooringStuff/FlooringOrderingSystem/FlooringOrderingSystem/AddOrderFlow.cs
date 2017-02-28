using FlooringBLL;
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
            string newOrderDateInput = Console.ReadLine();

            manager.StringToDate(newOrderDateInput);//left off with changing the user input string with a date
        }
    }
}
