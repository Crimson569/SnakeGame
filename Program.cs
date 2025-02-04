using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Screen Game = new Screen(15, 15);

            Game.Start();

            Console.WriteLine("Вы проиграли, нажмите любую клавишу...");
            Console.ReadKey();

        }
    }
}
