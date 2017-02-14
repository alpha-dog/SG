using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        { 
            SetupFlow setUp = new SetupFlow();
            //setUp.SetUp();

            GameFlow playGame = setUp.SetUp();
            playGame.PlayTheGame();
            Console.ReadKey();
        }
    }
}//I HAVE MADE CHANGES TO BATTLESHIP
