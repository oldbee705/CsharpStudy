using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 核心实践贪吃蛇.Lesson3;

namespace 核心实践贪吃蛇.Lesson4
{
    enum E_SnakeBody_Type
    {
        Head,
        Body,
    }
    internal class SnakeBody : GameObject
    {
        public E_SnakeBody_Type type;

        public SnakeBody(E_SnakeBody_Type type, int x, int y)
        {
            this.type = type;
            this.pos = new Position(x, y);
        }
        public override void Draw()
        {
            Console.SetCursorPosition(pos.x ,pos.y);
            Console.ForegroundColor = type == E_SnakeBody_Type.Head ? ConsoleColor.DarkGreen : ConsoleColor.Green;
            Console.WriteLine(type == E_SnakeBody_Type.Head ? "●" : "○");
        }
    }
}
