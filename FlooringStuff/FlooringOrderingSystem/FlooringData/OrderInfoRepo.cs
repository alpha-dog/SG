using FlooringModels;
using FlooringModels.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringData
{
    public class OrderInfoRepo : IOrderRepo //I think this may be a dumb spot for this if I'm going to make a seperate OrderRepo
    {
        string _dirPath; //this constructor forces any call to Repo to include a directoryPath argument
        public OrderInfoRepo(string dirPath)//directotryPath
        {
            _dirPath = dirPath;
        }
        // this checks to see if a file exists. If it does it returns a list of OrderInfos
        public List<OrderInfo> LoadOrders (DateTime userInputDate)
        {
           
            string fileNameDate = String.Format(userInputDate.ToString("MMddyyyy"));
            string dirPathFile = ($"{_dirPath}\\Orders_{fileNameDate}.txt");
            
            DisplayResponse response = new DisplayResponse()
            {
                Success = false,
                Message = "something went wrong in the orderInfoRepo",
                OrderInfoList = null
            };

            if (File.Exists(dirPathFile))
            {
                List<OrderInfo> orders = new List<OrderInfo>();
                using (StreamReader sr = new StreamReader(dirPathFile))
                {
                    sr.ReadLine();
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        OrderInfo newOrderInfo = new OrderInfo();

                        string[] columns = line.Split(',');

                        newOrderInfo.OrderNumber = int.Parse(columns[0]);
                        newOrderInfo.CustomerName = columns[1];
                        newOrderInfo.State = columns[2];
                        newOrderInfo.TaxRate = decimal.Parse(columns[3]);
                        newOrderInfo.ProductType = columns[4];
                        newOrderInfo.Area = decimal.Parse(columns[5]);
                        newOrderInfo.CostPerSquareFoot = decimal.Parse(columns[6]);
                        newOrderInfo.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
                        newOrderInfo.MaterialCost = decimal.Parse(columns[8]);
                        newOrderInfo.LaborCost = decimal.Parse(columns[9]);
                        newOrderInfo.Tax = decimal.Parse(columns[10]);
                        newOrderInfo.Total = decimal.Parse(columns[11]);

                        orders.Add(newOrderInfo);
                    }
                }
                //these responses and the return are out of sync with the orderManager                                                                            
                response.Success = true;
                response.OrderInfoList = orders;
                response.Message = "it worked";

                return response.OrderInfoList;
                //return response with order, success, message saying it worked

            }
            else
            {
                response.Success = false;
                response.OrderInfoList = null;
                response.Message = "nothing for that date";

                return response.OrderInfoList;
            }





        }

        public void SaveOrder(OrderInfo order)//We don't need to save the file if we're just displaying it.
        {
            throw new NotImplementedException();
        }


    }
}
