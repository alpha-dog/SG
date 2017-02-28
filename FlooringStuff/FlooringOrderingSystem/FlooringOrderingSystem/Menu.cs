using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem
{
    class Menu
    {
        public static void Start()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the FloorStore order program");
                Console.WriteLine("choose one of the menu options below to do stuff");

                Console.WriteLine("1.Display Orders");
                Console.WriteLine("2.Add an Order");
                Console.WriteLine("3.Edit an Order");
                Console.WriteLine("4.Remove an Order");
                Console.WriteLine("5.Quit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        DisplayFlow displayFlow = new DisplayFlow();
                        displayFlow.Execute();
                        break;
                    case "2":
                        AddOrderFlow addOrder = new AddOrderFlow();
                        addOrder.Execute();
                        break;
                    case "q": case "Q":
                        return;
                }
            }


            

            //instantiate a new workflow object based on their selection and send it to that workflow class's "execute" function
        }
    }
}
