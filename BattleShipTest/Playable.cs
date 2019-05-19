using System;
namespace BattleShip
{
    public interface Playable
    {
        bool PlaceShipAtlocation(Ship ship, int X, int Y);

        bool HitTheLocation(int X, int Y);

        void PrintTheBoard();

    }
}
