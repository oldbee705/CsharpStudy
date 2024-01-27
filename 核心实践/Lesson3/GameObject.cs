using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 核心实践贪吃蛇.Lesson3
{
    abstract internal class GameObject : IDraw
    {
        public Position pos;
        public abstract void Draw();
    }
}
