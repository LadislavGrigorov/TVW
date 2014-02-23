using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWork
{
    class Engine
    {
        public static List<GamePart> parts = new List<GamePart>();
        public static Queue<Shot> shots = new Queue<Shot>();

        public static int GameSpeed = 50;
        public static ConsoleKey MoveLeft = ConsoleKey.LeftArrow;
        public static ConsoleKey MoveRight = ConsoleKey.RightArrow;
        public static ConsoleKey Shoot = ConsoleKey.Spacebar;
        public static ConsoleKey Pause = ConsoleKey.P;
        public static int playerTotalScore = 0;
        public static int time = 0;
        public static int maxShots = 5;
        public static int level = 0;

        static void Main()
        {
            Console.WindowHeight = 50;
            Console.WindowWidth = 120;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.CursorVisible = false;
            Console.Title = "INVADORS";


            PartEmitter.Initializing();

            while (true)
            {
                ReadConsoleKeys();

                //ProcessShots();

                //ProcessEnemies();

                //PrintShots();
                time++;
                if (time % 5 == 0)
                {
                    Console.Clear();
                    var invadors = parts.FindAll(x => (x.LefttopPosition[0] == 0 || x.LefttopPosition[0] == Console.BufferWidth - 3));
                    if (invadors.Count > 0)
                    {
                        foreach (var item in parts)
                        {
                            if (item is Invador)
                            {
                                item.MoveDirection[0] *= -1;
                                item.LefttopPosition[1] += 1;
                            }
                        }
                    }

                    foreach (var item in parts)
                    {
                        if (item is Invador)
                        {
                            if (item.LefttopPosition[1] >= 1 && item.LefttopPosition[1] <= 14) item.PartColor = ConsoleColor.Blue;
                            if (item.LefttopPosition[1] >= 15 && item.LefttopPosition[1] <= 25) item.PartColor = ConsoleColor.Yellow;
                            if (item.LefttopPosition[1] >= 26) item.PartColor = ConsoleColor.Red;
                        }
                    }

                    var printable = parts.FindAll((x) => (x.Life > 0));
                    foreach (var item in printable)
                    {
                        item.Move();
                        item.Draw();
                    }
                }
                if (time % 2 == 0)
                {
                    PartEmitter.player.Clear();
                    PartEmitter.player.Draw();
                }

                if (shots.Count > 0 && shots.Peek().LefttopPosition[1] == 0) shots.Dequeue();
                foreach (var item in shots)
                {
                    item.Move();
                    item.Draw();
                }
                System.Threading.Thread.Sleep(GameSpeed);
            }
        }

        public static void ReadConsoleKeys()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                if (pressedKey.Key == Pause)
                {
                    Console.Beep(3000, 1);
                    Console.SetCursorPosition(43, 32);
                    Console.WriteLine("Game Paused. Press 'P' to resume.");
                    while (true)
                    {
                        if (Console.KeyAvailable)
                        {
                            pressedKey = Console.ReadKey(true);
                            if (pressedKey.Key == ConsoleKey.P)
                            {
                                Console.SetCursorPosition(43, 32);
                                Console.WriteLine("                                 ");
                                Console.Beep(3000, 1);
                                return;
                            }
                        }
                    }
                }
                else if (pressedKey.Key == MoveLeft)
                {
                    if (PartEmitter.player.LefttopPosition[0] == 0)
                    {
                        return;
                    }

                    Console.Beep(300, 1);
                    PartEmitter.player.LefttopPosition[0] -= 1;
                }
                else if (pressedKey.Key == MoveRight)
                {
                    if (PartEmitter.player.LefttopPosition[0] == Console.BufferWidth - 5)
                    {
                        return;
                    }
                    Console.Beep(300, 1);
                    PartEmitter.player.LefttopPosition[0] += 1;
                }
                else if (pressedKey.Key == Shoot)
                {
                    if (shots.Count > 4)
                    {
                        return;
                    }
                    Console.Beep(300, 1);
                    Shot shot = new Shot(new int[] { PartEmitter.player.LefttopPosition[0] + 2, PartEmitter.player.LefttopPosition[1] },
                                         new int[] { 0, -1 }, 1, ConsoleColor.Cyan, 100);
                    shots.Enqueue(shot);
                }
            }
        }
    }
}
