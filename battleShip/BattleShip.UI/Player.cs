using BattleShip.BLL.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class Player

    {
        public Board PlayerBoard { get; } = new Board();
        
        public string PlayerName {get; }
        public Player (string playerName)
        {
            PlayerName = playerName;
        }  
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                            