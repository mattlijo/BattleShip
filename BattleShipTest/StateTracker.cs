using System;
namespace BattleShip
{
    public interface StateTracker
    {
        void ReportDamage(Ship ship);
    }
}
