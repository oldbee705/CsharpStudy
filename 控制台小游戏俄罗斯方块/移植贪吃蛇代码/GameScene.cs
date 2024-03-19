using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;


namespace 俄罗斯方块
{
    class GameScene : ISceneUpdate
    {
        Map map = new Map();
        BlockWorker blockWorker = new BlockWorker();
        
        public void Update()
        {
            map.Draw();
            blockWorker.Draw();
            switch(Console.ReadKey(true).Key)
            {
                case ConsoleKey.LeftArrow:
                    if(blockWorker.CanChange(E_Change_Type.Left, map))
                    {
                        blockWorker.Change(E_Change_Type.Left);
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (blockWorker.CanChange(E_Change_Type.Right, map))
                    {
                        blockWorker.Change(E_Change_Type.Right);
                    }
                    break;
            }
        }
    }
}
