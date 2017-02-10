using BattleShip.BLL.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class GameFlow
    {
        Player _player1 = null;
        Player _player2 = null;
        

        bool _isPlayerOneTurn;

        public GameFlow(bool isPlayerOne, Player p1, Player p2)
        {
            _isPlayerOneTurn = isPlayerOne;
            _player1 = p1;
            _player2 = p2;
        }
        public void PlayTheGame()
        {

        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                             