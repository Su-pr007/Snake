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
            // Задаём размеры консоли
            Console.SetBufferSize(120, 30);
            int mapWidth;
            int mapHeight;

            char snakeSym;
            char wallSym;
            char foodSym;
            // Спрашиваем настройки игры

            // ширину карты
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите ширину карты(минимум 10, максимум 119):");
                try
                {
                    mapWidth = Convert.ToInt32(Console.ReadLine());
                    if (mapWidth >= 10 && mapWidth < 120) break;
                }
                catch
                {
                    continue;
                }
            }
            // высоту карты
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите высоту карты(минимум 10, максимум 29):");
                try
                {
                    mapHeight = Convert.ToInt32(Console.ReadLine());
                    if (mapHeight >= 10 && mapHeight < 30) break;
                }
                catch
                {
                    continue;
                }
            }
            // символ стен
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите символ стен (+):");
                try
                {
                    wallSym = Convert.ToChar(Console.ReadLine());
                    break;
                }
                catch
                {
                    continue;
                }
            }
            // символ змейки
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите символ змейки (*):");
                try
                {
                    snakeSym = Convert.ToChar(Console.ReadLine());
                    break;
                }
                catch
                {
                    continue;
                }
            }
            // символ еды
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите символ еды (@):");
                try
                {
                    foodSym = Convert.ToChar(Console.ReadLine());
                    break;
                }
                catch
                {
                    continue;
                }
            }
            while (true)
            {
                Console.Clear();

                // Отсчет
                Console.SetCursorPosition(45, 12);
                Console.WriteLine("3");
                Thread.Sleep(1000);

                Console.SetCursorPosition(45, 12);
                Console.WriteLine("2");
                Thread.Sleep(1000);

                Console.SetCursorPosition(45, 12);
                Console.WriteLine("1");
                Thread.Sleep(1000);

                Console.Clear();

                // Создаём стены
                Walls walls = new Walls(mapWidth, mapHeight, wallSym);
                walls.Draw();
                // Змейка
                Point p = new Point(4, 5, snakeSym);
                Snake snake = new Snake(p, 3, Direction.RIGHT);
                snake.Draw();

                FoodCreator foodCreator = new FoodCreator(mapWidth, mapHeight, foodSym);
                Point food = foodCreator.CreateFood();
                food.Draw();

                while (true)
                {
                    // Проверка на столкновение
                    if (walls.IsHit(snake) || snake.IsHitTail())
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        string line = "==================================";

                        Console.SetCursorPosition(40, 10);
                        Console.WriteLine(line);

                        Console.SetCursorPosition(45, 12);
                        Console.WriteLine("Игра окончена");
                        Console.SetCursorPosition(45, 13);
                        Console.WriteLine("Нажмите Enter для выхода.");


                        Console.SetCursorPosition(40, 15);
                        Console.WriteLine(line);
                        Console.ForegroundColor = ConsoleColor.White;
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
                Console.WriteLine("Напишите ESC для выхода или нажмите Enter для рестарта");
                string end = Console.ReadLine();
                if (end == "ESC" || end == "Esc" || end == "esc")
                {
                    break;
                }
            }
        }
    }
}
