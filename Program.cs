﻿using System;
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
            int mapWidth = 0;
            int mapHeight = 0;

            char snakeSym = '*';
            char wallSym = '*';
            char foodSym = '*';
            // Спрашиваем настройки игры

            // ширину карты
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите ширину карты(минимум 10):");
                try
                {
                    mapWidth = Convert.ToInt32(Console.ReadLine());
                    break;
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
                Console.WriteLine("Введите высоту карты(минимум 10):");
                try
                {
                    mapHeight = Convert.ToInt32(Console.ReadLine());
                    break;
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
                Console.WriteLine("Введите символ стен:");
                try
                {
                    snakeSym = Console.ReadLine();
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
                Console.WriteLine("Введите ширину карты(минимум 10):");
                try
                {
                    mapWidth = Convert.ToInt32(Console.ReadLine());
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
                Console.WriteLine("Введите ширину карты(минимум 10):");
                try
                {
                    mapWidth = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    continue;
                }
            }

            Console.Clear();
            // Создаём стены
            Walls walls = new Walls(mapWidth, mapHeight);
            walls.Draw();
            // Змейка
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 3, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(mapWidth, mapHeight, '@');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                // Проверка на столкновение
                if(walls.IsHit(snake) || snake.IsHitTail())
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
            Console.ReadLine();
        }
    }
}
