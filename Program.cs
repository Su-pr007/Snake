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
            Console.SetBufferSize(120, 30);
            // Рамка
            HorizontalLine topLine = new HorizontalLine(0, 119, 0, '#');
            HorizontalLine bottomLine = new HorizontalLine(0, 119, 29, '#');
            VerticalLine leftLine = new VerticalLine(0, 29, 0, '#');
            VerticalLine rightLine = new VerticalLine(0, 29, 119, '#');

            topLine.Draw();
            bottomLine.Draw();
            leftLine.Draw();
            rightLine.Draw();

            // Змейка
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '@');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(100);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }

            }

        }
    }
}
