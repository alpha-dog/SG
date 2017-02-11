using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    class ConsoleOut
    {
        internal static void SplashPage()
        {
            Console.WriteLine("start menu / splash screen");
            Console.ReadLine();
        }

        internal static void ShipPromptPlacement(ShipType ship)
        {
            Console.WriteLine($"you are now setting the {ship}");
            Console.ReadLine();
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
                                                                                                                                                                                                                                                                                                                                                                      