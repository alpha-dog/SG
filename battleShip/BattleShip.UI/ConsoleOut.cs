using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using BattleShip.BLL.Requests;

namespace BattleShip.UI
{
    static class ConsoleOut
    {
        internal static void SplashPage()
        {
            Console.WriteLine("You are about to play battleship start menu / splash screen");
            Console.ReadLine();
        }

        internal static void ShipPromptPlacement(ShipType ship)
        {
            Console.WriteLine($"set your {ship}");
            
        }


        //gotta display the board

        //Array[,] shotDisplay = new Array[10,10];
        public static void BoardViewer(Dictionary<Coordinate, ShotHistory> shotHist)
        {

            for (int x = 1; x <= 10; x++)
            {
                for (int y = 1; y <= 10; y++)
                {
                    Coordinate coord = new Coordinate(x,y);
                    ShotHistory shotHistResult;
                    if (shotHist.ContainsKey(coord))
                    {
                        shotHist.TryGetValue(coord, out shotHistResult);
                        if (shotHistResult == ShotHistory.Hit)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" H ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (shotHistResult == ShotHistory.Miss)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(" M ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }


                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(" * ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                Console.WriteLine();   
            }
        }

        internal static void IsShipPlaceValid(ShipPlacement shipSpot)
        { 
            if (shipSpot == ShipPlacement.Ok)
            {
                Console.WriteLine($"{shipSpot}");
            }
            else if (shipSpot == ShipPlacement.NotEnoughSpace)
            {
                Console.WriteLine("there's not enough space");
            }
            else
            {
                Console.WriteLine("that spot overlaps with another ship");
            }


        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                      