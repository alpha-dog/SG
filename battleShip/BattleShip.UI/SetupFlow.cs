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
            ConsoleOut.SplashPage();

            string player1 = PlayerInput.GetPlayer1Name();
            string player2 = PlayerInput.GetPlayer2Name();

            bool player1First = RandomPlayerAssign();
            GameFlow game = new GameFlow(player1First);
            game.
        }

        private bool RandomPlayerAssign()
        {
            throw new NotImplementedException();
        }

    }
}
