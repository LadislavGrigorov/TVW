namespace TankWars.Weapons
{
    using System;
    using System.Collections.Generic;

    public class SecondaryWeapon : Weapon
    {
        int charges;
        private static readonly SecondaryWeapon supergun = new SecondaryWeapon(25, 5);
        private static readonly SecondaryWeapon megagun = new SecondaryWeapon(40, 5);
        public SecondaryWeapon(int damage, int charges)
            : base(damage)
        {
            this.Charges = charges;
        }

        public int Charges
        {
            get
            {
                return this.charges;
            }
            set
            {
                this.charges = value;
            }
        }

        public SecondaryWeapon Supergun
        {
            get
            {
                return Supergun;
            }
        }

        public SecondaryWeapon Megagun
        {
            get
            {
                return Supergun;
            }
        }
        public IEnumerable<Bullet> Shoot()
        {
            //if charges > 0 shoot else do nothing
            //create bullets with the weapon damage, speed and coords of the tank/machine
            throw new NotImplementedException();
        }

    }
}
