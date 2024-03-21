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
        Map map;
        BlockWorker blockWorker;
        //Thread inputThread;
        //private bool isRunning;

        public GameScene()
        {
            
            map = new Map(this);
            blockWorker = new BlockWorker();
            InputThread.Instance.inputEvent += CheckInputThread;
            //isRunning = true;
            //inputThread = new Thread(CheckInputThread);
            //inputThread.IsBackground = true;
            //inputThread.Start();
        }
        public void Update()
        {
            lock(blockWorker)
            {
                map.Draw();
                blockWorker.Draw();

                if (blockWorker.CanDown(map))
                    blockWorker.AutoMove();
            }
            Thread.Sleep(100);
        }
        public void stopThread()
        {
            InputThread.Instance.inputEvent -= CheckInputThread;
        }

        private void CheckInputThread()
        {
            //检测输入
            if (Console.KeyAvailable)
            {
                lock (blockWorker)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        //变形
                        case ConsoleKey.LeftArrow:
                            if (blockWorker.CanChange(E_Change_Type.Left, map))
                                blockWorker.Change(E_Change_Type.Left);
                            break;
                        case ConsoleKey.RightArrow:
                            if (blockWorker.CanChange(E_Change_Type.Right, map))
                                blockWorker.Change(E_Change_Type.Right);
                            break;
                        //移动
                        case ConsoleKey.A:
                            if (blockWorker.CanMove(E_Change_Type.Left, map))
                                blockWorker.MoveLR(E_Change_Type.Left);
                            break;
                        case ConsoleKey.D:
                            if (blockWorker.CanMove(E_Change_Type.Right, map))
                                blockWorker.MoveLR(E_Change_Type.Right);
                            break;
                        case ConsoleKey.S:
                        case ConsoleKey.DownArrow:
                            if (blockWorker.CanDown(map))
                                blockWorker.AutoMove();
                            break;
                    }
                }
            }
        }
    }
}
