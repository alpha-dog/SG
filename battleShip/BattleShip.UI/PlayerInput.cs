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
            Console.WriteLine("give me a coordinate");
            string coordInput = Console.ReadLine();
            string xCoord = coordInput.Remove(1);
            string yCoord = coordInput.Substring(1);

            int y;
            bool isNum = int.TryParse(yCoord, out y);//do input validation

            int x = xCoord[0] - 'A' + 1;

            Coordinate coordReturn = new Coordinate(x,y);
            return coordReturn;
        }
        public static ShipDirection GetUserDirection()
        {
            Console.WriteLine("what direction do you want your ship to go");
            string inputDirection = Console.ReadLine();
            ShipDirection userShipDirection = ShipDirection.Down;
            if (inputDirection == "up")
            {
                userShipDirection = ShipDirection.Up;
            }
            else if (inputDirection == "down")
            {
                userShipDirection = ShipDirection.Down;
            }
            else if (inputDirection == "left")
            {
                userShipDirection = ShipDirection.Left;
            }
            else
            {
                userShipDirection = ShipDirection.Right;
            }

            return userShipDirection ;
        }

    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                              