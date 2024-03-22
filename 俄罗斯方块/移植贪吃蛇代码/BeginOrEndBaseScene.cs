using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    abstract class BeginOrEndBaseScene : ISceneUpdate
    {
        protected string strTitle;
        protected string strOne;
        protected int nowSelIndex;

        public abstract void EnterJDoSomthing();
        public virtual void Update()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Game.w / 2 - strTitle.Length, 6);
            Console.Write(strTitle);

            Console.SetCursorPosition(Game.w / 2 - strOne.Length, 10);
            Console.ForegroundColor = nowSelIndex == 0 ? ConsoleColor.Red : ConsoleColor.White;
            Console.WriteLine(strOne);

            Console.SetCursorPosition(Game.w / 2 - 4, 12);
            Console.ForegroundColor = nowSelIndex == 1 ? ConsoleColor.Red : ConsoleColor.White;
            Console.WriteLine("结束游戏");
            
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.W:
                    --nowSelIndex;
                    if (nowSelIndex < 0)
                    {
                        nowSelIndex = 0;
                    }
                    break;
                case ConsoleKey.S:
                    ++nowSelIndex;
                    if (nowSelIndex > 1)
                    {
                        nowSelIndex = 1;
                    }
                    break;
                case ConsoleKey.J:
                    EnterJDoSomthing();
                    break;
            }
        }
    }
}
