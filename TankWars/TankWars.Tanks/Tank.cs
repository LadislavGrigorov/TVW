namespace TankWars.Tanks
{
    using System;
    using TankWars.Common;
    public abstract class Tank : Machine
    {

        public Tank (string name, int armour, int energy, int health, ItemPosition position)
            : base(name, armour, energy, health, position)
        {

        }

    }
}
