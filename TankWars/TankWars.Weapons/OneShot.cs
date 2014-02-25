using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankWars.Weapons
{
    public class OneShot : SecondaryWeapon
    {
        private const int OneShotDamage = 100;
        private const int OneshotCharges = 1;
        private const int OneShotSpeed = 1;
        public OneShot() : base(OneShotDamage, OneShotSpeed, OneShotCharges)
        {

        }
    }
}
