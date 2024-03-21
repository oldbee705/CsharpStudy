using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace 俄罗斯方块
{
    internal class EndScene : BeginOrEndBaseScene
    {
        public EndScene()
        {
            strTitle = "游戏结束";
            strOne = "返回开始界面";
        }
        public override void EnterJDoSomthing()
        {
            //按下J键做什么
            if (nowSelIndex == 0)
            {
                Game.ChangeScene(E_SceneType.Begin);
            }
            else
            {
                Environment.Exit(0);
            }
        }
        public override void Update()
        {
            Console.SetCursorPosition(Game.w / 2 - 6, 20);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("你的得分为:{0}", Game.score);

            base.Update();
        }
    }
}
