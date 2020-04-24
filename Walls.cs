using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Walls
    {
        List<Figure> wallList;
        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();

            HorizontalLine topLine = new HorizontalLine(0, mapWidth, 1, '█');
            HorizontalLine bottomLine = new HorizontalLine(0, mapWidth, mapHeight, '█');
            VerticalLine leftLine = new VerticalLine(0, mapHeight-1, 0, '█');
            VerticalLine rightLine = new VerticalLine(0, mapHeight-1, mapWidth, '█');

            wallList.Add(topLine);
            wallList.Add(bottomLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);
        }
        internal bool IsHit(Figure figure)
        {
            foreach(var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }
        public void Draw()
        {
            foreach(var wall in wallList)
            {
                wall.Draw();
            }
        }
    }
}
