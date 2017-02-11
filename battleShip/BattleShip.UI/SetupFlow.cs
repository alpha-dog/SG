using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class SetupFlow
    {
        
        public GameFlow SetUp()
        {
            ConsoleOut.SplashPage();

            string player1Name = PlayerInput.GetPlayer1Name();
            string player2Name = PlayerInput.GetPlayer2Name();//names aren't used yet

            Player playerOne = new Player(player1Name);
            Player playerTwo = new Player(player2Name);

            bool player1Turn = RandomPlayerAssign();

            Console.WriteLine($"hi {player1Name}, it's time to place your ships");
            SetupBoard(playerOne.PlayerBoard);

            Console.WriteLine("it's now time for the other guy to set up their board");
            Console.ReadLine();

            Console.WriteLine($"hi {player2Name}, it's your turn to place ships");
            SetupBoard(playerTwo.PlayerBoard);

            GameFlow game = new GameFlow(player1Turn, playerOne, playerTwo); //this probably doesn't work                  

            return game;
        }

        public Board SetupBoard (Board someBoard)
        {
            for (ShipType ship = ShipType.Destroyer ; ship < ShipType.Carrier; ship++)
            {
                PlaceShip(someBoard, ship); 
            }
           

            return someBoard;
        }


        public void PlaceShip (Board board1or2 , ShipType ship)
        {
            ConsoleOut.ShipPromptPlacement(ship);
            ShipPlacement shipSpot = ShipPlacement.NotEnoughSpace;
            while (shipSpot != ShipPlacement.Ok)
            {
                PlaceShipRequest request = new PlaceShipRequest()
                {
                    Coordinate = PlayerInput.GetUserCoord(),
                    Direction = PlayerInput.GetUserDirection(),
                    ShipType = ship                 
                };
                shipSpot = board1or2.PlaceShip(request);//input validation
                ConsoleOut.IsShipPlaceValid(shipSpot);
            }
        }

        private bool RandomPlayerAssign()
        {
            Random rng = new Random();

            return rng.NextDouble() > 0.5;
            
        }

    }
}

