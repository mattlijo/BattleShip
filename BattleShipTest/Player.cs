using System;
using System.Collections;

namespace BattleShip
{
    class Player : StateTracker
    {

        private ArrayList ships = new ArrayList();

        private int playerID;

        public Player(int id)
        {
            this.playerID = id;
        }

        public ArrayList GetFleetShips()
        {
            //hardcoding for now
            Random rand = new Random();
            //Obtain a number between [0 - 10].
            int n = rand.Next(10);
            ships.Add(new Ship(rand.Next(1,10), "alpha", this));
            ships.Add(new Ship(rand.Next(1,10), "beta", this));
            ships.Add(new Ship(rand.Next(1,10), "gama", this));
            ships.Add(new Ship(rand.Next(1,10), "delta", this));
            ships.Add(new Ship(rand.Next(1,10), "zulu", this));
            return ships;
        }

        public void ReportDamage(Ship ship)
        {
            Console.WriteLine((ship.ToString() + " got hit"));
            if (ship.Sunk())
            {
                Console.WriteLine((ship.ToString() + " sank :("));
            }
        }

        public bool PlayerStatus()
        {
            foreach (Ship s in ships)
            {
                if (!s.Sunk())
                {
                    return true;
                }
            }
            Console.WriteLine((" player"+playerID+" lost "));

            return false;
        }
    }
}
