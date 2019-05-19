using System;
namespace BattleShip
{
    public class Ship
    {
        private int size;
        
        private int damage = 0;
        
        private String name;

        private StateTracker tracker;
        
        public Ship(int size, String name) {
            this.size = size;
            this.name = name;
        }

        public Ship(int size, String name, StateTracker tracker) {
            this.size = size;
            this.name = name;
            this.tracker = tracker;
        }

        public void Setracker(StateTracker tracker) {
            this.tracker = tracker;
        }
        
        public String GetName() {
            return this.name;
        }
        
        public int Size() {
            return size;
        }
        
        public bool Hit() {
            this.damage++;
            if ((tracker != null)) {
                tracker.ReportDamage(this);
            }
            
            return Sunk();
        }
        
        //  we might not need this here; later
        public bool Sunk() {
            return (this.damage >= this.size);
        }
        
        public String ToString() {
            return ("Ship :" 
                        + (this.name + (" Length: " 
                        + (this.size + (" damage " + this.damage)))));
        }
        
        public bool Equals(Object obj) {
            Ship s = ((Ship)(obj));
            return s.name.Equals(this.name);
        }

    }
}
