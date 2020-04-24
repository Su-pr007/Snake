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

            Walls walls = new Walls(119, 29);
            walls.Draw();
            // Змейка
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(48, 25, '@');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if(walls.IsHit(snake) || snake.IsHitTail())
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.SetCursorPosition(40, 10);
                    Console.WriteLine("==================================");

                    Console.SetCursorPosition(45, 12);
                    Console.WriteLine("Игра окончена");
                    Console.SetCursorPosition(45, 13);
                    Console.WriteLine("Нажмите Enter для выхода.");


                    Console.SetCursorPosition(40, 15);
                    Console.WriteLine("==================================");
                    break;
                }
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
            Console.ReadLine();
        }
    }
}
