using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 核心实践贪吃蛇.Lesson1;

namespace 核心实践贪吃蛇.Lesson2
{
    class GameScene : ISceneUpdate
    {
        public void Update()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("游戏场景");
        }
    }
}
