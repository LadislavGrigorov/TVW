using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWork
{
    public class Player : GamePart
    {
        public Player(int[] lefTop, int[] moveDir, int speed, ConsoleColor col, int life)
            : base(lefTop, moveDir, speed, col, life)
        {
            char c = '\u2593';
            base.Shape = new char[,] { { ' ', '/', (char)15, '\\', ' ' }, 
                                       { c, c, c, c, c} };
        }
    }
}