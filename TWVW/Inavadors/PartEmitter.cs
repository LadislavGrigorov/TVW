using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWork
{
    public class PartEmitter
    {
        public static Player player;

        public static void Initializing()
        {
            for (int i = 0; i < 6; i++)
            {
                Engine.parts.Add(new Obstacle(new int[] { 6 + i * 20, 40 }, new int[] { 0, 0 }, 2, ConsoleColor.Yellow, 100));
            }

            for (int i = 0; i < 18; i++)
            {
                for (int g = 0; g < 5; g++)
                {
                    Engine.parts.Add(new Invador(new int[] { 6 + i * 6, 5 + g * 5 }, new int[] { -1, 0 }, 2, ConsoleColor.Red, 100));
                }
            }

            player = new Player(new int[] { 2, 45 }, new int[] { 0, 0 }, 2, ConsoleColor.Green, 100);
        }
    }
}
