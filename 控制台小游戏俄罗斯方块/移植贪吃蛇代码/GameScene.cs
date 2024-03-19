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
        }
    }
}
