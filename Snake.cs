using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace Snake
{
    class Snake : Figure
    {
        Direction direction;
        public Snake(Point tail, int length, Direction _direction)
        {
            direction = _direction;
            pList = new List<Point>();
            for(int i = 0; i<length; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pList.Add(p);
            }
        }
        internal void Move()
        {
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);

            tail.Clear();
            head.Draw();
        }
        public Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }
        internal bool IsHitTail()
        {
            var head = pList.Last();
            for(int i = 0;i<pList.Count - 2; i++)
            {
                if (head.IsHit(pList[i])) return true;
            }
            return false;
        }
        public void HandleKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    if (direction == Direction.RIGHT) break;
                    direction = Direction.LEFT;
                    break;
                case ConsoleKey.RightArrow:
                    if (direction == Direction.LEFT) break;
                    direction = Direction.RIGHT;
                    break;
                case ConsoleKey.UpArrow:
                    if (direction == Direction.DOWN) break;
                    direction = Direction.UP;
                    break;
                case ConsoleKey.DownArrow:
                    if (direction == Direction.UP) break;
                    direction = Direction.DOWN;
                    break;
                case ConsoleKey.Escape:
                    Process.GetCurrentProcess().Kill();
                    break;
            }
        }
        internal bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.sym = head.sym;
                pList.Add(food);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
