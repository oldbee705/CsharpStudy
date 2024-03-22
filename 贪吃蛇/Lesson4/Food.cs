using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 核心实践贪吃蛇.Lesson1;
using 核心实践贪吃蛇.Lesson3;
using 核心实践贪吃蛇.Lesson5;

namespace 核心实践贪吃蛇.Lesson4
{
    internal class Food : GameObject
    {
        public Food(Snake snake) 
        {
            CreateFood(snake);
        }
        public override void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("¤");
        }
        public void CreateFood(Snake snake)
        {
            Random r = new Random();
            int x = r.Next(1, (Game.w / 2 - 1)) * 2;
            int y = r.Next(1, Game.h - 2);
            pos = new Position(x, y);
            if (snake.CheckSamePos(pos))
            {
                CreateFood(snake);
            }
        }
    }
}
 