
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    class GameFlow
    {
        Player _player1 = null;
        Player _player2 = null;
        private bool _player1Turn;
        bool _isGameOver = false;

        public GameFlow(bool player1Turn, Player p1, Player p2)
        {  
            _player1 = p1;
            _player2 = p2;
            _player1Turn = player1Turn;
            Console.Clear();
            Console.WriteLine("lets start the game");
        }
        public void PlayTheGame()
        {
            while (!_isGameOver)
            {
                ShotStatus checkShot = ShotStatus.Invalid;
                Player targetPlayer = null;
                Player currentPlayer = null;

                if (_player1Turn)
                {
                    targetPlayer = _player2;
                    currentPlayer = _player1;
                }
                else
                {
                    targetPlayer = _player1;
                    currentPlayer = _player2; 
                }
                Console.Clear();
                Console.WriteLine($"{currentPlayer.PlayerName}, its your turn");
                ConsoleOut.BoardViewer(targetPlayer.PlayerBoard.ShotHistory);

                while (checkShot == ShotStatus.Invalid || checkShot == ShotStatus.Duplicate)
                {

                    Coordinate shotSpot = PlayerInput.GetUserCoord();
                    var fireResponse = targetPlayer.PlayerBoard.FireShot(shotSpot);
                    checkShot = fireResponse.ShotStatus;
                    switch (checkShot)
                    {
                        case ShotStatus.Duplicate:
                            Console.WriteLine("already shot there");
                            break;
                        case ShotStatus.Invalid:
                            Console.WriteLine("off the board");
                            break;
                        case ShotStatus.Hit:
                            Console.WriteLine($"nice, you hit a {fireResponse.ShipImpacted}");
                            Console.ReadKey(); //attempt to keep hit response displayed
                            break;
                        case ShotStatus.HitAndSunk:
                            Console.WriteLine($"whoa, you sunk a {fireResponse.ShipImpacted}");
                            Console.ReadKey(); // attempt to keep hit response displayed
                            break;
                        case ShotStatus.Miss:
                            Console.WriteLine("you missed");
                            Console.ReadKey(); // """"""""""""""""""
                            break;
                        case ShotStatus.Victory:
                            Console.WriteLine("WINNER");

                            _isGameOver = true;
                            break;


                    }

                }
                _player1Turn = !_player1Turn;
            }
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                             