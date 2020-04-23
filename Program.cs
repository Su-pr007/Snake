using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main()
        {
            // Рамка
            HorizontalLine topLine = new HorizontalLine(0, 80, 0, '#');
            HorizontalLine bottomLine = new HorizontalLine(0, 80, 25, '#');
            VerticalLine leftLine = new VerticalLine(0, 25, 0, '#');
            VerticalLine rightLine = new VerticalLine(0, 25, 80, '#');

            topLine.Draw();
            bottomLine.Draw();
            leftLine.Draw();
            rightLine.Draw();

            // Змейка
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
                Thread.Sleep(300);
                snake.Move();

            }

            Console.ReadLine();
        }
    }
}
