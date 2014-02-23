namespace TankWars.Common
{
    using System;
    public abstract class Machine
    {
        private string name;

        private int armour;

        private int energy;

        private int health;

        public Machine(string name, int armour, int energy, int health, ItemPosition position)
        {
            this.Name = name;
            this.Armour = armour;
            this.Energy = energy;
            this.Health = health;
            this.Postition = position;
        }

        public ItemPosition Postition { get; set; }

        public string Name { get; protected set; }

        // adds durability to the machine. Lessons the demage take by other units.
        public int Armour { get; set; }

        // determines how fast the machine can shoot or move.
        public int Energy { get; set; }

        // machine dies when health reaches 0.
        public int Health { get; set; }


    }
}
