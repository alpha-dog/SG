using FlooringModels;
using FlooringModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringBLL
{
    public class OrderManager
    {
        private IOrderRepo _orderRepo;
        public OrderManager(IOrderRepo orderNumber)// this is where interfaces make themselves useful. they're like a universal port
        {
            _orderRepo = orderNumber;
        }

        public DateTime StringToDate(string userInput)
        {
            
            DateTime orderDate = DateTime.Parse("01/01/01");
            bool notValidDateInput = true;
            while (notValidDateInput)
            {
                if (DateTime.TryParse(userInput, out orderDate))
                {
                    notValidDateInput = false;
                }
                else
                {
                    Console.WriteLine("The date you entered wasn't formatted correctly. Try again.");
                    userInput = Console.ReadLine();
                }

            }
            return orderDate;
        }


        //LoadOrders checks to see if the order exists in repository and loads it if it does
        public DisplayResponse LoadOrders(DateTime date) 
        {
            DisplayResponse response = new DisplayResponse();

            response.OrderInfoList = _orderRepo.LoadOrders(date);

            if (response.OrderInfoList == null)
            {
                response.Success = false;
                response.Message = $"an order for {date} could not be found.";//another message prints if no orders are found. Maybe this only prints in the case 
            }
            else
            {
                response.Success = true;
            }
            return response;
        }
        public void AddOrder(OrderInfo newOrder)
        {

        }
    }
}
