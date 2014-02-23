using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankWars.Weapons
{
    public abstract class SecondaryWeapon : Weapon
    {
        int charges;
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
        public void Shoot()
        {
            //if charges > 0 shoot else do nothing
            //create bullets with the weapon damage, speed and coords of the tank/machine
        }

    }
}
