
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
        ConsoleOut test = new ConsoleOut();

        public GameFlow(bool player1Turn, Player p1, Player p2)
        {  
            _player1 = p1;
            _player2 = p2;
            bool _player1Turn = player1Turn;
            Console.Clear();
            Console.WriteLine("lets start the game");
            
        }
        public void PlayTheGame()
        {
            while (!_isGameOver)
            {
                ShotStatus checkShot = ShotStatus.Invalid;
                Player targetPlayer = null;

                if (_player1Turn)
                {
                    Console.Clear();
                    Console.WriteLine($"{_player1.PlayerName}, its your turn");
                    test.BoardViewer(_player2.PlayerBoard.ShotHistory);
                    targetPlayer = _player2;

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{_player2.PlayerName}, your turn");
                    test.BoardViewer(_player1.PlayerBoard.ShotHistory);
                    targetPlayer = _player1;
                }

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
                            break;
                        case ShotStatus.HitAndSunk:
                            Console.WriteLine($"whoa, you sunk a {fireResponse.ShipImpacted}");
                            break;
                        case ShotStatus.Miss:
                            Console.WriteLine("you missed");
                            break;
                        case ShotStatus.Victory:
                            Console.WriteLine("WINNER");
                            _isGameOver = true;
                            break;


                    }

                }
                _player1Turn = !_player1Turn;
            }
            //get shot coordinate






            //send shot to other players board
            //check to see if valid shot spot
            //check to see what shot does (endGame etc.)
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                             