namespace 基础实践
{
    //场景
    enum E_Scene
    {
        BeginScene,
        GameScene,
        EndScene
    }

    //格子类型
    enum E_GridType
    {
        normal,
        pause,
        boom,
        tunnel
    }

    //玩家类型
    enum E_PlayerType
    {
        player1,
        player2
    }

    internal class Program
    {
        //主逻辑
        static void Main(string[] args)
        {
            Vector2 startPos = new Vector2(14, 3);
            int x = 50;
            int y = 30;
            GameInit(x, y);
            E_Scene nowScene = E_Scene.BeginScene;
            int nowSel = 0;
            bool isQuitBegin = false;
            bool isGameOver;
            bool whoRound = true;
            while (true)
            {
                Console.Clear();
                switch (nowScene)
                {
                    case E_Scene.BeginScene:
                        #region 开始画面
                        Console.SetCursorPosition(x / 2 - 3, 8);
                        Console.Write("飞行棋");

                        while (true)
                        {
                            Console.ForegroundColor = nowSel == 0 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.SetCursorPosition(x / 2 - 4, 14);
                            Console.Write("开始游戏");

                            Console.ForegroundColor = nowSel == 1 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.SetCursorPosition(x / 2 - 4, 16);
                            Console.Write("退出游戏");
                            switch (Console.ReadKey(true).Key)
                            {
                                case ConsoleKey.W:
                                    --nowSel;
                                    if (nowSel < 0)
                                    {
                                        nowSel = 0;
                                    }
                                    break;
                                case ConsoleKey.S:
                                    ++nowSel;
                                    if (nowSel > 1)
                                    {
                                        nowSel = 1;
                                    }
                                    break;
                                case ConsoleKey.J:
                                    //开始游戏、退出游戏
                                    if (nowSel == 0)
                                    {
                                        nowScene = E_Scene.GameScene;
                                        isQuitBegin = true;
                                    }
                                    else
                                    {
                                        Environment.Exit(0);
                                    }
                                    break;
                            }
                            if (isQuitBegin)
                            {
                                break;
                            }
                        }
                        #endregion
                        break;
                    case E_Scene.GameScene:
                        #region 游戏画面
                        //画围墙
                        MapInit(x, y);
                        //画地图
                        Map map = new Map(startPos, 84);
                        map.DrawMap();
                        Player player1 = new Player(0, E_PlayerType.player1);
                        Player player2 = new Player(0, E_PlayerType.player2);
                        DrawPlayer(player1, player2, map);
                        while (true)
                        {
                            //按下按键
                            Console.ReadKey(true);
                            isGameOver = whoRound ? RandomMove(x, y, map, ref player1, ref player2) : RandomMove(x, y, map, ref player2, ref player1);
                            map.DrawMap();
                            DrawPlayer(player1, player2, map);
                            //结束游戏
                            if(isGameOver)
                            {
                                Console.ReadKey(true);
                                nowScene = E_Scene.EndScene;
                                break;
                            }
                            whoRound = !whoRound;
                        }
                        #endregion
                        break;
                    case E_Scene.EndScene:
                        #region 结束画面
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(x / 2 - 4, 8);
                        Console.Write("结束画面");

                        while (true)
                        {
                            Console.ForegroundColor = nowSel == 0 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.SetCursorPosition(x / 2 - 6, 14);
                            Console.Write("返回开始界面");

                            Console.ForegroundColor = nowSel == 1 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.SetCursorPosition(x / 2 - 4, 16);
                            Console.Write("退出游戏");
                            switch (Console.ReadKey(true).Key)
                            {
                                case ConsoleKey.W:
                                    --nowSel;
                                    if (nowSel < 0)
                                    {
                                        nowSel = 0;
                                    }
                                    break;
                                case ConsoleKey.S:
                                    ++nowSel;
                                    if (nowSel > 1)
                                    {
                                        nowSel = 1;
                                    }
                                    break;
                                case ConsoleKey.J:
                                    //开始游戏、退出游戏
                                    if (nowSel == 0)
                                    {
                                        nowScene = E_Scene.BeginScene;
                                        isQuitBegin = true;
                                    }
                                    else
                                    {
                                        Environment.Exit(0);
                                    }
                                    break;
                            }
                            if (isQuitBegin)
                            {
                                break;
                            }
                        }
                        #endregion
                        break;
                }
            }
        }

        //初始化窗口
        static void GameInit(int x, int y)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetWindowSize(x, y);
            Console.SetBufferSize(x, y);
        }

        //初始化地图
        static void MapInit(int x, int y)
        {
            //横向围墙
            for (int i = 0; i < x; i += 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(i, 0);
                Console.Write("■");

                Console.SetCursorPosition(i, y - 11);
                Console.Write("■");

                Console.SetCursorPosition(i, y - 6);
                Console.Write("■");

                Console.SetCursorPosition(i, y - 1);
                Console.Write("■");
            }
            //纵向围墙
            for (int i = 0; i < y; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(0, i);
                Console.Write("■");

                Console.SetCursorPosition(x - 2, i);
                Console.Write("■");
            }
            //文字信息
            Console.SetCursorPosition(2, y - 10);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("□:普通格子");

            Console.SetCursorPosition(2, y - 9);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("‖:暂停，一回合不动");

            Console.SetCursorPosition(x / 2, y - 9);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("●:炸弹，倒退5格");

            Console.SetCursorPosition(2, y - 8);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("¤:时空隧道，随机倒退，暂停，换位置");

            Console.SetCursorPosition(2, y - 7);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("★:玩家1");

            Console.SetCursorPosition(14, y - 7);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("▲:玩家2");

            Console.SetCursorPosition(26, y - 7);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("◎:玩家重合");

            Console.SetCursorPosition(2, y - 5);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("按下任意键继续");
        }

        /// <summary>
        /// 掷色子
        /// </summary>
        /// <param name="x">文本信息x轴位置</param>
        /// <param name="y">文本信息y轴位置</param>
        /// <param name="map">地图信息</param>
        /// <param name="p">玩家</param>
        /// <param name="otherP">其他玩家</param>
        /// <returns></returns>
        static bool RandomMove(int x, int y, Map map, ref Player p, ref Player otherP)
        {
            //擦除控制台信息
            Console.SetCursorPosition(2, y - 5);
            Console.Write("                                         ");
            Console.SetCursorPosition(2, y - 4);
            Console.Write("                                         ");
            Console.SetCursorPosition(2, y - 3);
            Console.Write("                                         ");
            Console.SetCursorPosition(2, y - 2);
            Console.Write("                                         ");

            if (p.isPause)
            {
                p.isPause = false;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.SetCursorPosition(2, y - 5);
                Console.Write("{0}处于暂停，下回合才能行动", p.playerType);
                return false;
            }
            Random r = new Random();
            //掷骰子1-6
            int distance = r.Next(1, 7);
            p.nowIndex += distance;
            //判断是否结束，结束返回true
            if (p.nowIndex >= map.grids.Length - 1)
            {
                p.nowIndex = map.grids.Length - 1;
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(2, y - 5);
                Console.Write("{0}到达了终点", p.playerType);
                Console.SetCursorPosition(2, y - 4);
                Console.Write("按下任意键进入结束画面");
                return true;
            }
            //没结束判断踩到的是什么格子
            switch (map.grids[p.nowIndex].gridType)
            {
                
                case E_GridType.normal:
                    Console.ForegroundColor = p.playerType == E_PlayerType.player1 ? ConsoleColor.Cyan : ConsoleColor.Magenta;
                    Console.SetCursorPosition(2, y - 5);
                    Console.Write("{0}扔出的点数为：{1}", p.playerType, distance);
                    Console.SetCursorPosition(2, y - 4);
                    Console.Write("{0}到达了一个安全位置", p.playerType);
                    Console.SetCursorPosition(2, y - 3);
                    Console.Write("请按下任意键，让{0}开始扔色子", otherP.playerType);
                    break;
                //触发 后退5格
                case E_GridType.boom:
                    p.nowIndex -= 5;
                    if(p.nowIndex < 0)
                    {
                        p.nowIndex = 0;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(2, y - 5);
                    Console.Write("{0}扔出的点数为：{1}", p.playerType, distance);
                    Console.SetCursorPosition(2, y - 4);
                    Console.Write("{0}踩到了炸弹，后退5格", p.playerType);
                    Console.SetCursorPosition(2, y - 3);
                    Console.Write("请按下任意键，让{0}开始扔色子", otherP.playerType);
                    break;
                //触发 暂停一回合
                case E_GridType.pause:
                    p.isPause = true;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.SetCursorPosition(2, y - 5);
                    Console.Write("{0}扔出的点数为：{1}", p.playerType, distance);
                    Console.SetCursorPosition(2, y - 4);
                    Console.Write("{0}被暂停一回合", p.playerType);
                    Console.SetCursorPosition(2, y - 3);
                    Console.Write("请按下任意键，让{0}开始扔色子", otherP.playerType);
                    break;
                //各三分之一概率触发 暂停 后退5格 交换位置
                case E_GridType.tunnel:
                    int index = r.Next(1,91);
                    if(index <= 30)
                    {
                        //暂停
                        p.isPause = true;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(2, y - 5);
                        Console.Write("{0}扔出的点数为：{1}", p.playerType, distance);
                        Console.SetCursorPosition(2, y - 4);
                        Console.Write("{0}进入时空隧道，被暂停一回合", p.playerType);
                        Console.SetCursorPosition(2, y - 3);
                        Console.Write("请按下任意键，让{0}开始扔色子", otherP.playerType);
                        break;
                    }
                    else if (index <= 60)
                    {
                        //后退5格
                        p.nowIndex -= 5;
                        if (p.nowIndex < 0)
                        {
                            p.nowIndex = 0;
                        }
                        p.isPause = true;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(2, y - 5);
                        Console.Write("{0}扔出的点数为：{1}", p.playerType, distance);
                        Console.SetCursorPosition(2, y - 4);
                        Console.Write("{0}进入时空隧道，后退5格", p.playerType);
                        Console.SetCursorPosition(2, y - 3);
                        Console.Write("请按下任意键，让{0}开始扔色子", otherP.playerType);
                        break;
                    }
                    else
                    {
                        //交换位置
                        int temp = p.nowIndex;
                        p.nowIndex = otherP.nowIndex;
                        otherP.nowIndex = temp;
                        p.isPause = true;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(2, y - 5);
                        Console.Write("{0}扔出的点数为：{1}", p.playerType, distance);
                        Console.SetCursorPosition(2, y - 4);
                        Console.Write("{0}进入时空隧道，和{1}交换位置", p.playerType, otherP.playerType);
                        Console.SetCursorPosition(2, y - 3);
                        Console.Write("请按下任意键，让{0}开始扔色子", otherP.playerType);
                    }
                    break;

            }
            //Console.SetCursorPosition(2, y - 5);
            //Console.ForegroundColor = ConsoleColor.White;
            //Console.Write("按下任意键继续");
            return false;
        }
        //画玩家
        static void DrawPlayer(Player player1, Player player2, Map map)
        {
            if (player1.nowIndex == player2.nowIndex)
            {
                Console.SetCursorPosition(map.grids[player1.nowIndex].pos.x, map.grids[player1.nowIndex].pos.y);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("◎");
            }
            else
            {
                player1.DrawPlayer(map);
                player2.DrawPlayer(map);
            }
            
        }

        //二维坐标
        struct Vector2
        {
            public int x;
            public int y;

            public Vector2(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        //格子结构体,有画格子方法
        struct Grid
        {
            public Vector2 pos;
            public E_GridType gridType;

            public Grid(Vector2 pos, E_GridType gridType)
            {
                this.pos = pos;
                this.gridType = gridType;
            }

            public void DrawGrid()
            {
                Console.SetCursorPosition(pos.x, pos.y);
                switch (gridType)
                {
                    case E_GridType.normal:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("□");
                        break;
                    case E_GridType.pause:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("‖");
                        break;
                    case E_GridType.boom:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("●");
                        break;
                    case E_GridType.tunnel:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("¤");
                        break;
                }
            }
        }

        //地图结构体,绘制地图
        struct Map
        {
            public Grid[] grids;

            public Map(Vector2 pos, int num)
            {
                int indexX = 0;
                int indexY = 0;
                int stepX = 2;
                Random r = new Random();
                grids = new Grid[num];
                for (int i = 0; i < num; i++)
                {
                    grids[i] = new Grid();
                    //初始化类型
                    int index = r.Next(0, 100);
                    if (index < 85 || i == 0 || i == num - 1)
                    {
                        grids[i].gridType = E_GridType.normal;
                    }
                    else if (index >= 85 && index < 90)
                    {
                        grids[i].gridType = E_GridType.pause;
                    }
                    else if (index >= 90 && index < 95)
                    {
                        grids[i].gridType = E_GridType.boom;
                    }
                    else if (index >= 95 && index < 100)
                    {
                        grids[i].gridType = E_GridType.tunnel;
                    }
                    grids[i].pos = pos;
                    //初始化位置
                    if (indexX == 10)
                    {
                        pos.y++;
                        indexY++;
                        if (indexY == 2)
                        {
                            indexX = 0;
                            indexY = 0;
                            stepX = -stepX;
                        }
                    }
                    else
                    {
                        pos.x += stepX;
                        indexX++;
                    }
                }
            }

            public void DrawMap()
            {
                for (int i = 0; i < grids.Length; i++)
                {
                    grids[i].DrawGrid();
                }
            }
        }

        //玩家结构体，能够改变自己的位置
        struct Player
        {
            public bool isPause;
            public int nowIndex;
            public E_PlayerType playerType;

            public Player(int nowIndex, E_PlayerType playerType)
            {
                this.nowIndex = nowIndex;
                this.playerType = playerType;
                isPause = false;
            }

            public void DrawPlayer(Map map)
            {
                Console.SetCursorPosition(map.grids[nowIndex].pos.x, map.grids[nowIndex].pos.y);
                switch (playerType)
                {
                    case E_PlayerType.player1:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("★");
                        break;
                    case E_PlayerType.player2:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("▲");
                        break;
                }
            }
        }
    }
}

