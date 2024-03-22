using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 核心实践贪吃蛇.Lesson1;

namespace 核心实践贪吃蛇.Lesson2
{
    internal class BeginScene : BeginOrEndBaseScene
    {
        public BeginScene() 
        {
            strTitle = "贪吃蛇";
            strOne = "开始游戏";
        }
        public override void EnterJDoSomthing()
        {
            //按下J键做什么
            if (nowSelIndex == 0)
            {
                Game.ChangeScene(E_SceneType.Game);
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
