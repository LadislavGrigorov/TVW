using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWork
{
    public class Shot : GamePart
    {
        public Shot(int[] lefTop, int[] moveDir, int speed, ConsoleColor col, int life)
            : base(lefTop, moveDir, speed, col, life)
        {
            base.Shape = new char[,] { { (char)15 } };
        }
    }
}