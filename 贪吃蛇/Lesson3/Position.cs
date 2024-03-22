using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 核心实践贪吃蛇.Lesson3
{
    struct Position
    {
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static bool operator ==(Position left, Position right)
        {
            if(left.x == right.x && left.y == right.y)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Position left, Position right)
        {
            if (left.x == right.x && right.y == left.y)
            {
                return false;
            }
            return true;
        }
    }
}
