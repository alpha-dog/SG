using BattleShip.BLL.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BattleShip.UI
{
    static class PlayerInput
    {
        public static string GetPlayer1Name()
        {
            Console.WriteLine("enter player one name: ");
            string p1 = Console.ReadLine();
            return p1; 
        }
        public static string GetPlayer2Name()
        {
            Console.WriteLine("enter player two name: ");
            string p2 = Console.ReadLine();
            return p2;
        }
        public static Coordinate GetUserCoord()//input validation
        {
            int x = -1,
                y = -1;
            bool notValidCoord = true;
            while (notValidCoord)
            {
                Console.WriteLine("give me a coordinate");
                string coordInput = Console.ReadLine().ToUpper();
                if (coordInput.Length < 1)
                {
                    Console.WriteLine("don't enter nothing");
                    
                    continue;
                    
                }
                string xCoord = coordInput.Substring(0, 1);
                string yCoord = coordInput.Substring(1);

                                bool isNum = int.TryParse(yCoord, out y);
                if (!isNum)
                {
                    Console.WriteLine("not the right format");
                    
                    continue;
                    
                }

                x = (xCoord[0] - 'A' + 1);//after 'r7' and 'down' (both flagged as invalid) are entered, entering b5 returns "the coordinate you entered was wrong"


                if ((x < 1 || x > 10) || (y < 1 || y > 10))
                {
                    Console.WriteLine("try again");
                  
                    continue;
                   
                }
                
                notValidCoord = false;
                
            }
            return new Coordinate(x, y);
        }
        public static ShipDirection GetUserDirection()
        {
            bool badDirection = true;
            ShipDirection userShipDirection = new ShipDirection();
            while (badDirection)
            {
                Console.WriteLine("what direction do you want your ship to go");//maybe a tooLower and a loop
                string inputDirection = Console.ReadLine().ToUpper();
                
                if (inputDirection == "UP")
                {
                    userShipDirection = ShipDirection.Up;
                    badDirection = false;
                }
                else if (inputDirection == "DOWN")
                {
                    userShipDirection = ShipDirection.Down;
                    badDirection = false;
                }
                else if (inputDirection == "LEFT")
                {
                    userShipDirection = ShipDirection.Left;
                    badDirection = false;
                }
                else if (inputDirection == "RIGHT")
                {
                    userShipDirection = ShipDirection.Right;
                    badDirection = false;
                }
                else
                {
                    Console.WriteLine("you typed bad. try again");
                    GetUserDirection();
                }
            }
            return userShipDirection ;
        }

    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                              