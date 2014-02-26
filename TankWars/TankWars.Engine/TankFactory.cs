using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankWars.Tanks;
using TankWars.Common;

namespace TankWars.Engine
{
    public class TankFactory
    {
        public SwinTank CreateSwimTank(string name, int x, int y)
        {
            return new SwinTank(name, new ItemPosition(x, y));
        }

        public HeavyDutyTank CreateHeavyDutyTank(string name, int x, int y)
        {
            return new HeavyDutyTank(name, new ItemPosition(x, y));
        }

        public StealthTank CreateStealthTank(string name, int x, int y)
        {
            return new StealthTank(name, new ItemPosition(x, y));
        }
    }
}
