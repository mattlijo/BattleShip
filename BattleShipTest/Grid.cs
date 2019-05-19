using System;
namespace BattleShip
{

    public class Grid
    {

        public static bool HIT = true;

        public static bool SAFE = false;

        public bool state = SAFE;

        public Ship holder;

        public bool free = true;

        public void Attak()
        {
            if ((this.state == SAFE))
            {
                holder.Hit();
                this.state = HIT;
            }

        }

        public String ToString()
        {
            if (holder == null)
            {
                return "[O]";
            }

            return ("[" + (holder.GetName().ToCharArray()[0] + "]"));
        }

    }
}
