﻿namespace TankWars.Tanks
{
    using System;
    using System.Collections.Generic;
    using TankWars.Common;
    using TankWars.Weapons;

    public class StealthTank : Tank, IStealth
    {
        // Stealth Tank with high speed, armour, normal energy. Cannot swim but it is fast and can be invisible for a period.
        private const int SPEED = 70;
        private const int ARMOUR = 100;
        private const int HEALTH = 700;
        private const int ENERGY = 400;
        private const int INVISIBILITY_DURATION = 5;

        public StealthTank(string name, ItemPosition position)
            : base(name, position, ARMOUR, ENERGY, HEALTH, SPEED)
        {
            this.IsInvisible = false;
            this.InvisibilityDuration = INVISIBILITY_DURATION;
            this.Energy = InitialEnergy;
            this.PrimaryGun = new Minigun();
            this.SpecialGun = new SuperShot();

        }


        public bool IsInvisible { get; set; }

        public int InvisibilityDuration { get; private set; }


    }
}
