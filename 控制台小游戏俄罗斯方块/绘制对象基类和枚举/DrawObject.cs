using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    /// <summary>
    /// 方块类型
    /// </summary>
    enum E_CubeType
    {
        Wall,
        Cube,
        Line,
        Tank,
        Left_Labber,
        Right_Labber,
        Long_Left_Labber,
        Long_Right_Labber
    }
    class DrawObject : IDraw
    {
        public Position pos;
        private E_CubeType cubeType;

        public DrawObject(E_CubeType type)
        {
            this.cubeType = type;
        }

        public DrawObject(int x, int y)
        {
            pos.x = x;
            pos.y = y;
        }

        public DrawObject(int x, int y, E_CubeType cubeType) : this(x, y)
        {
            this.cubeType = cubeType;
        }
        public void Draw()
        {
            if(pos.y < 0)
                return;
            Console.SetCursorPosition(pos.x, pos.y);
            switch (cubeType)
            {
                case E_CubeType.Wall:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case E_CubeType.Cube:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case E_CubeType.Line:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case E_CubeType.Tank:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case E_CubeType.Left_Labber:
                case E_CubeType.Right_Labber:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case E_CubeType.Long_Left_Labber:
                case E_CubeType.Long_Right_Labber:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }
            Console.Write("■");
        }

        public void Clear()
        {
            if (pos.y < 0)
                return;
            Console.SetCursorPosition(pos.x, pos.y);
            Console.Write("  ");
        }

        public void ChangeType(E_CubeType type)
        {
            cubeType = type;
        }
    }
}
