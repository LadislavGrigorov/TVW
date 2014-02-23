namespace TankWars.Weapons
{
    using System;
    public abstract class PrimaryWeapon : Weapon
    {
        int shootSpeed;
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

        public void Shoot()
        {
            //create bullets with the weapon damage, speed and coords of the tank/machine
            throw new NotImplementedException("Shoot not implemented!");
        }
    }
}
