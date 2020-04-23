using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {

            Point p1 = new Point(1, 3, '*');
            p1.Draw();

            Point p2 = new Point(4, 5, '#');
            p2.Draw();

            HorizontalLine line1 = new HorizontalLine(0, 50, 0, '#');
            line1.Draw();

            HorizontalLine line2 = new HorizontalLine(0, 50, 25, '#');
            line2.Draw();

            VerticalLine line3 = new VerticalLine(0, 25, 0, '#');
            line3.Draw();

            VerticalLine line4 = new VerticalLine(0, 25, 50, '#');
            line4.Draw();

            Console.ReadLine();
        }
    }
}
