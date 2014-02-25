namespace TankWars.Weapons
{
    using System;
    using System.Collections.Generic;
    public class PrimaryWeapon : Weapon
    {
        int shootSpeed;
        private static readonly PrimaryWeapon machineGun = new PrimaryWeapon(10, 2);
        private static readonly PrimaryWeapon miniGun = new PrimaryWeapon(12, 3);
        public PrimaryWeapon(int damage, int shootSpeed)
            : base(damage)
        {
            this.ShootSpeed = shootSpeed;
        }

        public int ShootSpeed
        {
            get
            {
                return this.shootSpeed;
            }
            protected set
            {
                this.shootSpeed = value;
            }
        }

        public PrimaryWeapon Machinegun
        {
            get
            {
                return  machineGun;
            }
        }

        public PrimaryWeapon Minigun
        {
            get
            {
                return  miniGun;
            }
        }

        public IEnumerable<Bullet> Shoot()
        {
            //create bullets with the weapon damage, speed and coords of the tank/machine
            throw new NotImplementedException("Shoot not implemented!");
        }
    }
}
