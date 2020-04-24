using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Walls
    {
        readonly List<Figure> wallList;
        public Walls(int mapWidth, int mapHeight, char wallSym)
        {
            wallList = new List<Figure>();

            HorizontalLine topLine = new HorizontalLine(0, mapWidth, 0, wallSym);
            HorizontalLine bottomLine = new HorizontalLine(0, mapWidth, mapHeight-1, wallSym);
            VerticalLine leftLine = new VerticalLine(0, mapHeight-1, 0, wallSym);
            VerticalLine rightLine = new VerticalLine(0, mapHeight-1, mapWidth, wallSym);

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
