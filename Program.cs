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

            HorizontalLine line1 = new HorizontalLine(0, 80, 0, '#');
            line1.Draw();

            HorizontalLine line2 = new HorizontalLine(0, 80, 25, '#');
            line2.Draw();

            VerticalLine line3 = new VerticalLine(0, 25, 0, '#');
            line3.Draw();

            VerticalLine line4 = new VerticalLine(0, 25, 80, '#');
            line4.Draw();


            Point p = new Point(4, 5, '*');
            p.Draw();

            Console.ReadLine();
        }
    }
}
