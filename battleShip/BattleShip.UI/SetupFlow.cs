using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class SetupFlow
    {
        public void SetUp()
        {
            Player p1 = new Player();
            Player p2 = new Player();

            ConsoleOut.SplashPage();
            PlayerInput.Player1Name(); //PlayerInput or Player
            PlayerInput.Player2Name();

            Player.RandomPlayerPicker();


        }


    }
}
