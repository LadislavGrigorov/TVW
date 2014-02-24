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
        public static List<Shot> shots = new List<Shot>();

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
            
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("starwars.wav");
            player.PlayLooping();
            System.Threading.Thread.Sleep(5000);

            PartEmitter.Initializing();

            while (true)
            {
                ReadConsoleKeys();
                time++;

                if (time % 6 == 0) InvadorsMove();
                if (time % 2 == 0) PlayerMove();
                ShotsMove();
                CollisionExecution();
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

                    PartEmitter.player.LefttopPosition[0] -= 1;
                }
                else if (pressedKey.Key == MoveRight)
                {
                    if (PartEmitter.player.LefttopPosition[0] == Console.BufferWidth - 5)
                    {
                        return;
                    }
                    PartEmitter.player.LefttopPosition[0] += 1;
                }
                else if (pressedKey.Key == Shoot)
                {
                    if (shots.Count > 10)
                    {
                        return;
                    }
                    Shot shot = new Shot(new int[] { PartEmitter.player.LefttopPosition[0] + 2, PartEmitter.player.LefttopPosition[1] },
                                         new int[] { 0, -1 }, 1, ConsoleColor.Cyan, 100);
                    System.Media.SoundPlayer playerShoot = new System.Media.SoundPlayer("blaster.wav");
                    playerShoot.Play();
                    shots.Add(shot);
                }
            }
        }
        public static void InvadorsMove()
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
        public static void PlayerMove()
        {
            PartEmitter.player.Clear();
            PartEmitter.player.Move();
            PartEmitter.player.Draw();
        }
        public static void ShotsMove()
        {
            for (int i = 0; i < shots.Count; i++)
			{
                if (shots[i].LefttopPosition[1] == 0) shots.RemoveAt(i);
			}

            foreach (var item in shots)
            {
                if (item.Life > 0) item.Clear();
                item.Move();
                if(item.Life > 0 )item.Draw();
            }
        }
        public static void CollisionExecution()
        {
            for (int i = 0; i < shots.Count; i++)
            {
                for (int g = 0; g < parts.Count; g++)
                {
                    for (int k = 0; k < parts[g].Shape.GetLength(1); k++)
                    {
                        if ((parts[g] is Invador) && (shots[i].Life >0 && parts[g].Life>0) && (shots[i].LefttopPosition[0] == parts[g].LefttopPosition[0]+k) && (shots[i].LefttopPosition[1] == parts[g].LefttopPosition[1]))
                        {
                            parts[g].Life -= 100;
                            shots[i].Life -= 100;
                            System.Media.SoundPlayer playerHit = new System.Media.SoundPlayer("burst.wav");
                            playerHit.Play();

                        }
                    }
                }
            }

            for (int i = 0; i < shots.Count; i++)
            {
                for (int g = 0; g < parts.Count; g++)
                {
                    if(parts[g] is Obstacle && shots[i].Life > 0)
                    {
                        for (int k = 0; k < parts[g].Shape.GetLength(0); k++)
                        {
                            for (int l = 0; l < parts[g].Shape.GetLength(1); l++)
                            {
                                if (shots[i].LefttopPosition[0] == parts[g].LefttopPosition[0] + l &&
                                    shots[i].LefttopPosition[1] == parts[g].LefttopPosition[1] - k &&
                                    parts[g].Shape[0+k, 0+l] != ' ')
                                {
                                    shots[i].Life -= 100;
                                    parts[g].Shape[0 + k, 0 + l] = ' ';
                                    System.Media.SoundPlayer playerHit = new System.Media.SoundPlayer("stun.wav");
                                    playerHit.Play();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
