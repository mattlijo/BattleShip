using System;
namespace BattleShip
{
    public class Board : Playable
    {

        public static bool VERTICAL = true;

        public static bool HORIZONTAL = false;

        public static int SIZE = 10;

        private Grid[,] gameBoard = new Grid[SIZE,SIZE];

        public Board()
        {
            // bad 
            InitGrids();
        }

        private void InitGrids()
        {
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    gameBoard[i,j] = new Grid();
                }
            }
        }

        public bool PlaceShipAtlocation(Ship ship, int X, int Y)
        {
            // can be a util
            //  boundry conditions
            if ((X > SIZE) || (Y > SIZE))
            {
                return false;
            }
            //  check if a postion can hold a ship first then place it
            if (CanShipBePlacedHorizontalRight(
                ship.Size(), X, Y))
            {
                for (int i = Y; i < (Y + ship.Size()); i++)
                {
                    gameBoard[X,i].holder = ship;
                    gameBoard[X,i].free = false;
                }
                return true;
            }
            else if (CanShipBePlacedHorizontalLeft(ship.Size(), X, Y))
            {
                for (int i = Y;i> (Y - ship.Size()); i--)
                {
                    gameBoard[X,i].holder = ship;
                    gameBoard[X,i].free = false;
                }
                return true;
            }
            else if (CanShipBePlacedVerticalUp(ship.Size(), X, Y))
            {
                for (int i = X;i<(X + ship.Size()); i++)
                {
                    gameBoard[i,Y].free = false;
                    gameBoard[i,Y].holder = ship;
                }
                return true;
            }
            else if (CanShipBeVerticalDown(ship.Size(), X, Y))
            {
                for (int i = X; i> (X - ship.Size()); i--)
                {
                    gameBoard[i,Y].free = false;
                    gameBoard[i,Y].holder = ship;
                }
                return true;
            }
            return false;
        }

        private bool CanShipBePlacedHorizontalRight(int Length, int X, int Y)
        {
            if (Y+ Length > SIZE)
            {
                return false;
            }

            bool free = true;
            for (int i = Y; i< Y + Length; i++)
            {
                if (!this.gameBoard[X,i].free)
                {
                    free = false;
                    break;
                }
            }
            return free;
        }

        private bool CanShipBePlacedHorizontalLeft(int Length, int X, int Y)
        {
            if (((Y - Length) < 0))
            {
                return false;
            }

            bool free = true;
            for (int i = Y; (i>= (Y - Length)); i--)
            {
                if (!gameBoard[X,i].free)
                {
                    free = false;
                    break;
                }
            }
            return free;
        }

        private bool CanShipBePlacedVerticalUp(int Length, int X, int Y)
        {
            if (X + Length > SIZE)
            {
                return false;
            }

            bool free = true;
            for (int i = X; i < (X + Length); i++)
            {
                if (!gameBoard[i,Y].free)
                {
                    free = false;
                    break;
                }
            }
            return free;
        }

        private bool CanShipBeVerticalDown(int Length, int X, int Y)
        {
            if (X - Length  <= 0)
            {
                return false;
            }

            bool free = true;
            for (int i = X; (i
                        >= (X - Length)); i--)
            {
                if (!gameBoard[i,X].free)
                {
                    free = false;
                    break;
                }

            }

            return free;
        }

        public bool HitTheLocation(int X, int Y)
        {
            if ((gameBoard[X,Y].free || (gameBoard[X,Y].state == Grid.HIT)))
            {
                Console.WriteLine("Opps you missed it ");
                return false;
            }
            else
            {
                this.gameBoard[X,Y].Attak();
                return true;
            }

        }

        public void PrintTheBoard()
        {
            for (int i = 0; (i < SIZE); i++)
            {
                for (int j = 0; (j < SIZE); j++)
                {
                    Console.Write(gameBoard[i,j].ToString());
                }

                Console.WriteLine();
            }

        }
    }

}
