namespace TankWars.Common
{
    using System;
    public abstract class Machine : IMovable
    {
        private string name;

        private int armour;

        private int energy;

        private int health;

        public Machine(string name, ItemPosition position)
        {
            this.Name = name;
            this.Position = position;
        }

        public ItemPosition Position { get;  protected set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name of Machine cannot be empty!");
                }

                this.name = value;
            }
        }

        // adds durability to the machine. Reduce the damage taken by other units.
        public int Armour
        {
            get
            {
                return this.armour;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Machine armour cannot be negative number!");
                }

                this.armour = value;
            }
        }

        // determines how fast the machine can shoot or move.
        public int Energy 
        {
            get
            {
                return this.energy;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Machine energy cannot be negative number!");
                }

                this.energy = value;
            }
        }

        // machine dies when health reaches 0.
        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Machine health cannot be negative number!");
                }

                this.health = value;
            }
        }

        // each machine implements it own speed
        public abstract int Speed { get; set; }

        // each machine determines how it moves
        public abstract void Move(int x, int y);

    }
}
