using System;
using System.Threading;

namespace BattleShip
{
    public class Game
    {
        private Player player;
        private Playable gameBoard;

        Game()
        {
            gameBoard = BoardFactory.GetBoard();
            player = new Player(1);
        }

        private void ArrangeShipsRandomly()
        {
            Random rand = new Random();
            //  Obtain a number between [0 - 10].
            foreach (Ship s in player.GetFleetShips())
            {
                bool placed = false;
                while (!placed)
                {
                    placed = gameBoard.PlaceShipAtlocation(s, rand.Next(10), rand.Next(10));

                }
            }
        }

        private void PrintBoard()
        {
            gameBoard.PrintTheBoard();
        }

        public void AttackNext()
        {
            Random rand = new Random();
            gameBoard.HitTheLocation(rand.Next(10), rand.Next(10));
        }

        public bool GameOver()
        {
            return player.PlayerStatus();
        }

        public static void Main(String[] args)
        {

            Game game = new Game();

            game.ArrangeShipsRandomly();
            game.PrintBoard();

            while (game.GameOver())
            {
                game.AttackNext();
                Thread.Sleep(100);
            }

            Console.WriteLine(" -------- CONSOLE ALWAYS WIN----------");          

        }

    }
}
