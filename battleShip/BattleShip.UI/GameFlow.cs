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
        public Board b1 { get; } = new Board();
        public Board b2 { get; } = new Board();
        bool _isPlayerOneTurn;

        public GameFlow(bool isPlayerOne)
        {
            _isPlayerOneTurn = isPlayerOne;
        }
        public void PlayTheGame()
        {

        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                             