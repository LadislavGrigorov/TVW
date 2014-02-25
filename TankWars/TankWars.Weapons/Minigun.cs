using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankWars.Weapons
{
    public class Minigun : PrimaryWeapon
    {
        private const int MinigunDamage = 10;
        private const int MinigunSpeed = 3;

        public Minigun()
            : base(MinigunDamage, MinigunSpeed)
        {

        }
    }
}
