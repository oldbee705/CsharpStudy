using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 核心实践贪吃蛇.Lesson3;

namespace 核心实践贪吃蛇.Lesson4
{
    internal class Food : GameObject
    {
        public Food(int x, int y) 
        {
            pos = new Position(x, y);
        }
        public override void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("¤");
        }
    }
}
