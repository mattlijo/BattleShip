using System;
namespace BattleShip
{
    public class BoardFactory
    {
        public static Playable GetBoard()
        {
            return new Board();
        }
    }

}
