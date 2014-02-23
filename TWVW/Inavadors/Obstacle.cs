using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWork
{
    class Obstacle : GamePart
    {
        private static int dirChange;

        public Obstacle(int[] lefTop, int[] moveDir, int speed, ConsoleColor col, int life)
            : base(lefTop, moveDir, speed, col, life)
        {
            char c = '\u2593';
            base.Shape = new char[,] { { ' ', c, c, c, c, c, c, ' ' }, 
                                       { c, c, c, c, c, c, c, c }, 
                                       { c, c, c, ' ', ' ', c, c, c }, 
                                       { c, c, c, ' ', ' ', c, c, c } };
            dirChange = 1;
        }
    }
}