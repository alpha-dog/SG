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
            string coordInput = "";
            Console.WriteLine("give me a coordinate");
            coordInput = Console.ReadLine().ToUpper();
            if (coordInput.Length < 1)
            {
                Console.WriteLine("don't enter nothing");
                GetUserCoord();
            }
            string xCoord = coordInput.Substring(0,1);
            string yCoord = coordInput.Substring(1);

            int y;
            bool isNum = int.TryParse(yCoord, out y);//do input validation
            if (!isNum)
            {
                Console.WriteLine("nope");
                GetUserCoord();
            }

            int x = (xCoord[0] - 'A' + 1);//after 'r7' and 'down' (both flagged as invalid) are entered, entering b5 returns "the coordinate you entered was wrong"


            if ((x < 1 || x > 10) || (y < 1 || y > 10))
            {
                Console.WriteLine("the coordinate you entered was wrong. try again");
                GetUserCoord();
            }
            Coordinate coordReturn = new Coordinate(x, y);
            return coordReturn;
     
        }
        public static ShipDirection GetUserDirection()
        {
            Console.WriteLine("what direction do you want your ship to go");//maybe a tooLower and a loop
            string inputDirection = Console.ReadLine();
            ShipDirection userShipDirection = new ShipDirection();
            if (inputDirection == "up" || inputDirection == "UP" || inputDirection == "Up" )
            {
                userShipDirection = ShipDirection.Up;
            }
            else if (inputDirection == "down" || inputDirection == "DOWN" || inputDirection == "Down")
            {
                userShipDirection = ShipDirection.Down;
            }
            else if (inputDirection == "left" || inputDirection == "LEFT" || inputDirection == "Left")
            {
                userShipDirection = ShipDirection.Left;
            }
            else if (inputDirection == "right" || inputDirection == "RIGHT" || inputDirection == "Right")
            {
                userShipDirection = ShipDirection.Right;
            }
            else
            {
                Console.WriteLine("you typed bad. try again");
                GetUserDirection();
            }
 
            return userShipDirection ;
        }

    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                              