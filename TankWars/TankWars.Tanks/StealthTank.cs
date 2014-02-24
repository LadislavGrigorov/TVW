namespace TankWars.Tanks
{
    using System;
    using System.Collections.Generic;
    using TankWars.Common;
    using TankWars.Weapons;

    public class StealthTank : Tank, IStealth
    {
        // Heavy Tank with slow speed, a lot of armour, a lot of energy. Cannot swim and cannot have stealth mode.
        private const int SPEED = 70;
        private const int ARMOUR = 100;
        private const int HEALTH = 700;
        private const int ENERGY = 400;
        private const int INVISIBILITY_DURATION= 5;

        public StealthTank(string name, ItemPosition position)
            : base(name, position)
        {
            this.InitialArmour = ARMOUR;
            this.InitialEnergy = ENERGY;
            this.initialHealth = HEALTH;
            this.Speed = SPEED;
            this.IsInvisible = false;
            this.InvisibilityDuration = INVISIBILITY_DURATION;
            // TODO: Inicialize guns

        }

        public override int Speed { get; protected set; }

        public bool IsInvisible { get; set; }

        public int InvisibilityDuration { get; private set; }

        
    }
}
