using FlooringData;
using FlooringModels;
using FlooringModels.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringBLL
{
    public class OrderManager
    {
        string dirPath = (@"C:\Users\Tom\Documents\SoftwareGuild\Repositories\david-evans-individual-work\FlooringStuff\");

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

        public void RemoveOrder(DateTime orderDate, int orderNumber, string deleteResponse)
        {
            var orderFromLookup = LookupOrder(orderDate, orderNumber);
            var orderToRemove = orderFromLookup.Order;

            if (deleteResponse == "1")
            {
                string fileName = $"Orders_{orderDate.ToString("MMddyyyy")}.txt";
                string file = dirPath + fileName;
                int orderNumberToRemove = orderToRemove.OrderNumber;


                string[] oldFile = File.ReadAllLines(file);
                //overwrite
                using (StreamWriter sw = new StreamWriter(file))
                {
                    for (int line = 0; line < oldFile.Length; line++)
                    {
                        if (line == orderNumberToRemove)
                        {
                            //sw.WriteLine(lineToEdit);
                            //sw.WriteLine($"{orderToRemove.OrderNumber},deleted,OH,0,Wood,0,0,0,0,0,0,0,0");

                        }
                        else
                        {
                            sw.WriteLine(oldFile[line]);
                        }
                    }
                }   
            }
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
        public void AddOrder(DateTime userDate, string userName, string userAbbreviation, string userProdType, string userArea)
        {
            ProductsRepo pRepo = new ProductsRepo();
            TaxesRepo tRepo = new TaxesRepo();
            OrderInfo ord = new OrderInfo();
            ord.StateTax = new Taxes();
            ord.OrderProduct = pRepo.GetProduct(userProdType);
            ord.StateTax = tRepo.GetStateTax(userAbbreviation);


            ord.OrderDate = userDate;
            ord.CustomerName = userName;
            ord.StateTax.StateAbbreviation = userAbbreviation;//todo validate
            ord.OrderProduct.ProductType = userProdType;
            ord.Area = decimal.Parse(userArea);



            string fileName = $"Orders_{ord.OrderDate.ToString("MMddyyyy")}.txt";
            string file = dirPath + fileName;

            if (!File.Exists(file))
            {
                ord.OrderNumber = 1;
                using (StreamWriter sw = File.CreateText(file))
                {
                    sw.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                    //add headers
                }
            }
            else
            {
                var list = _orderRepo.LoadOrders(userDate);
                ord.OrderNumber = list.Max(l => l.OrderNumber) + 1;
                //using (StreamReader sr = new StreamReader(file))
                //{
                //    //sr.ReadLine();
                //    string line;
                //    int counter = 0;

                //    while ((line = sr.ReadLine()) != null)
                //    {
                //        counter++;
                //    }
                //    ord.OrderNumber = counter;
                //}

            }
            using (StreamWriter sw = File.AppendText(file))
            {
                sw.WriteLine($"{ord.OrderNumber},{ord.CustomerName},{ord.StateTax.StateAbbreviation},{ord.StateTax.TaxRate},{ord.OrderProduct.ProductType},{ord.Area},{ord.OrderProduct.CostPerSquareFoot},{ord.OrderProduct.CostPerSquareFoot},{ord.OrderProduct.LaborCostPerSquareFoot},{ord.MaterialCost},{ord.LaborCost},{ord.Tax},{ord.Total}");
            }
        }
        public OrderResponse LookupOrder(DateTime orderDate, int orderNumber)
        {
            string fileName = $"Orders_{orderDate.ToString("MMddyyyy")}.txt";
            string file = dirPath + fileName;

            while (!File.Exists(file))
            {
                Console.WriteLine("There aren't any orders in our system for that date. Enter a different date");
                Console.ReadKey();
                break;
            }
            List<OrderInfo> list = new List<OrderInfo>();
            list = _orderRepo.LoadOrders(orderDate);

            OrderResponse response = new OrderResponse();
            response.Order = list.SingleOrDefault(o => o.OrderNumber == orderNumber);

            if (response.Order == null)
            {
                response.Success = false;
                response.Message = "That order number didn't match any orders in the system";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }
        public void EditOrder (DateTime orderDate, int orderNumber, string itemToEdit)
        {
            var orderFromLookup = LookupOrder(orderDate, orderNumber);
            var orderToEdit = orderFromLookup.Order;

            switch (itemToEdit)
            {
                case "1":
                    Console.WriteLine("enter the new order name: ");
                    string newName = Console.ReadLine();
                    if (newName != "")
                    {
                        orderToEdit.CustomerName = newName;
                    }
                    break;
                case "2":
                    Console.WriteLine("enter the new order state: ");
                    string newState = Console.ReadLine();
                    if (newState == "OH" || newState == "MI" || newState == "PA" || newState == "IN")
                    {
                        orderToEdit.StateTax.StateAbbreviation = newState;
                    }
                    break;
                case "3":
                    Console.WriteLine("enter the material you'd like to switch to");
                    string newProduct = Console.ReadLine();
                    if (newProduct == "Wood" || newProduct == "Tile" || newProduct == "Carpet" || newProduct == "Laminate")
                    {
                        orderToEdit.OrderProduct.ProductType = newProduct;
                    }
                    break;
                case "4":
                    Console.WriteLine("enter the new value for area");
                    decimal newArea = decimal.Parse(Console.ReadLine());
                    if (newArea >= 100)
                    {
                        orderToEdit.Area = newArea;
                    }
                    break;
                default:
                    Console.WriteLine("something went wrong");
                    break;
            }
            OverwriteFile(orderToEdit);
        }

        private void OverwriteFile(OrderInfo editedOrder)
        {
            var orderDate = editedOrder.OrderDate;

            var orderList = _orderRepo.LoadOrders(orderDate);

            string fileName = $"Orders_{orderDate.ToString("MMddyyyy")}.txt";
            string file = dirPath + fileName;
            int orderNumberToEdit = editedOrder.OrderNumber;

       
            string[] oldFile = File.ReadAllLines(file);
            //overwrite
            using (StreamWriter sw = new StreamWriter(file))
            {
                sw.WriteLine(oldFile[0]);
                foreach (var order in orderList)
                {
                    var orderToWrite = order;
                    if (order.OrderNumber == editedOrder.OrderNumber)
                    {
                        orderToWrite = editedOrder;
                    }
                    sw.WriteLine($"{orderToWrite.OrderNumber},{orderToWrite.CustomerName},{orderToWrite.StateTax.StateAbbreviation},{orderToWrite.StateTax.TaxRate},{orderToWrite.OrderProduct.ProductType},{orderToWrite.Area},{orderToWrite.OrderProduct.CostPerSquareFoot},{orderToWrite.OrderProduct.CostPerSquareFoot},{orderToWrite.OrderProduct.LaborCostPerSquareFoot},{orderToWrite.MaterialCost},{orderToWrite.LaborCost},{orderToWrite.Tax},{orderToWrite.Total}");
                    //orderToWrite
                }

                //for (int line = 0; line < oldFile.Length; line++)
                //{
                //    if (line == orderNumberToEdit)
                //    {
                //        //sw.WriteLine(lineToEdit);
                //        sw.WriteLine($"{editedOrder.OrderNumber},{editedOrder.CustomerName},{editedOrder.StateTax.StateAbbreviation},{editedOrder.StateTax.TaxRate},{editedOrder.OrderProduct.ProductType},{editedOrder.Area},{editedOrder.OrderProduct.CostPerSquareFoot},{editedOrder.OrderProduct.CostPerSquareFoot},{editedOrder.OrderProduct.LaborCostPerSquareFoot},{editedOrder.MaterialCost},{editedOrder.LaborCost},{editedOrder.Tax},{editedOrder.Total}");

                //    }
                //    else
                //    {
                //        sw.WriteLine(oldFile[line]);
                //    }
                //}
            }
        }
        
    }
}
