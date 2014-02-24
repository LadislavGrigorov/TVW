using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWork
{
    abstract public class GamePart : IDrawable
    {
        private int[] lefttopPosition;
        private int[] moveDirection;
        private int speed;
        private ConsoleColor partColor;
        private int life;
        public char[,] shape;

        public char[,] Shape
        {
            get
            {
                return this.shape;
            }
            set
            {
                this.shape = value;
            }
        }

        public int Life
        {
            get
            {
                return this.life;
            }
            set
            {
                this.life = value;
            }
        }

        public ConsoleColor PartColor
        {
            get
            {
                return this.partColor;
            }
            set
            {
                this.partColor = value;
            }
        }

        public int Speed
        {
            get
            {
                return this.speed;
            }
            set
            {
                this.speed = value;
            }
        }

        public int[] MoveDirection
        {
            get
            {
                return this.moveDirection;
            }
            set
            {
                this.moveDirection = value;
            }
        }

        public int[] LefttopPosition
        {
            get
            {
                return this.lefttopPosition;
            }
            set
            {
                this.lefttopPosition = value;
            }
        }

        public GamePart(int[] lefTop, int[] moveDir, int speed, ConsoleColor col, int life)
        {
            LefttopPosition = lefTop;
            MoveDirection = moveDir;
            Speed = speed;
            PartColor = col;
            Life = life;
        }

        public void Draw()
        {
            Console.ForegroundColor = PartColor;
            Console.SetCursorPosition(LefttopPosition[0], LefttopPosition[1]);
            for (int i = 0; i < shape.GetLength(0); i++)
            {
                for (int g = 0; g < shape.GetLength(1); g++)
                {
                    Console.SetCursorPosition(lefttopPosition[0] + g, lefttopPosition[1] + i);
                    if (shape[i, g] != ' ') Console.Write(shape[i, g]);
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public virtual void Move()
        {
            LefttopPosition[0] += MoveDirection[0];
            LefttopPosition[1] += MoveDirection[1];
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
                    if (shape[i, g] != ' ') Console.Write(shape[i, g]);
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
