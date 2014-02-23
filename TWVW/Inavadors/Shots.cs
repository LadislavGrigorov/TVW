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

        public void Clear()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(LefttopPosition[0], LefttopPosition[1]);
            for (int i = 0; i < shape.GetLength(0); i++)
            {
                for (int g = 0; g < shape.GetLength(1); g++)
                {
                    Console.SetCursorPosition(LefttopPosition[0] + g, LefttopPosition[1] + i);
                    if (shape[i, g] == 1) Console.Write(' ');
                }
            }
            //Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}