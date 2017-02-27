using FlooringData;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringBLL
{
    public class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["mode"].ToString();

            //we'll have a "test" mode and a "prod" mode 
            switch (mode)
            {
                case "prod":
                    return new OrderManager(new OrderInfoRepo(@"C:\Users\Tom\Documents\SoftwareGuild\Repositories\david-evans-individual-work\FlooringStuff"));

                default:
                    throw new Exception("the mode value in App.Config isn't set to any of your cases");
            }
        }    
    }
}
