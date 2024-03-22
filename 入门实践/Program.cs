#region 回合制战斗
//地图大小,隐藏光标
int x = 60;
int y = 30;
Console.SetWindowSize(x, y);
Console.SetBufferSize(x, y);
Console.CursorVisible = false;
Random random = new Random();
Console.BackgroundColor = ConsoleColor.Black;

//场景编号
int nowSceneID = 0;
int selIndex = 0;

string gameOverInfo = "";

while (true)
{
    //场景分支
    Console.Clear();
    switch (nowSceneID)
    {
        //开始界面
        case 0:
            Console.SetCursorPosition(x / 2 - 4, 8);
            Console.WriteLine("2D小游戏");
            char input;

            while (true)
            {
                bool isQuitWhile = false;
                Console.ForegroundColor = selIndex == 0 ? ConsoleColor.Red : ConsoleColor.White;
                Console.SetCursorPosition(x / 2 - 4, 15);
                Console.WriteLine("开始游戏");

                Console.ForegroundColor = selIndex == 1 ? ConsoleColor.Red : ConsoleColor.White;
                Console.SetCursorPosition(x / 2 - 4, 17);
                Console.WriteLine("退出游戏");

                input = Console.ReadKey(true).KeyChar;
                switch (input)
                {
                    case 'W':
                    case 'w':
                        selIndex -= 1;
                        if (selIndex < 0)
                        {
                            selIndex = 0;
                        }
                        break;

                    case 'S':
                    case 's':
                        selIndex += 1;
                        if (selIndex > 1)
                        {
                            selIndex = 1;
                        }
                        break;

                    case 'J':
                    case 'j':

                        if (selIndex == 0)
                        {
                            nowSceneID = 1;
                            isQuitWhile = true;
                        }
                        if (selIndex == 1)
                        {
                            Environment.Exit(0);
                        }
                        break;
                }
                if (isQuitWhile)
                {
                    break;
                }
            }
            break;

        //游戏界面
        case 1:
            #region 怪物
            int monsterX, monsterY;
            int temp = random.Next(3, 57);
            monsterX = temp % 2 == 0 ? temp : temp + 1;
            monsterY = random.Next(1, 24);
            int monsterAttackMin = 8;
            int monsterAttackMax = 12;
            int monsterHealth = 100;
            #endregion

            #region 玩家
            int curX = 2;
            int curY = 1;
            int playerAttackMin = 7;
            int playerAttackMax = 13;
            int playerHealth = 50;
            char playerInput;
            #endregion

            #region 地图
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j += 2)
                {
                    if (i == 0 || i == y - 1 || j == 0 || j == x - 2 || i == y - 6)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("■");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
            }
            #endregion

            #region 战斗状态
            bool isFight = false;
            bool isOver = false;
            #endregion

            //玩家行动
            while (true)
            {
                if (monsterHealth > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(monsterX, monsterY);
                    Console.Write('★');
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(24, 5);
                    Console.Write('★');
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(curX, curY);
                Console.Write("●");
                playerInput = Console.ReadKey(true).KeyChar;
                if (isFight)
                {
                    if (playerInput == 'J' || playerInput == 'j')
                    {
                        if (playerHealth <= 0)
                        {
                            nowSceneID = 2;
                            gameOverInfo = "失败";
                            break;
                        }
                        else if (monsterHealth <= 0)
                        {
                            Console.SetCursorPosition(monsterX, monsterY);
                            Console.Write("  ");
                            isFight = false;
                        }
                        else
                        {
                            int atk = random.Next(playerAttackMin, playerAttackMax + 1);
                            monsterHealth -= atk;
                            Console.SetCursorPosition(2, 25);
                            Console.Write("开始战斗，按J继续");
                            Console.SetCursorPosition(2, 26);
                            Console.Write("                             ");
                            Console.SetCursorPosition(2, 26);
                            Console.Write("你对怪物造成了{0}点伤害", atk);
                            Console.SetCursorPosition(2, 28);
                            Console.Write("                              ");
                            Console.SetCursorPosition(2, 28);
                            Console.Write("玩家血量为:{0}  怪物血量为:{1}", playerHealth, monsterHealth);
                            if (monsterHealth > 0)
                            {
                                atk = random.Next(monsterAttackMin, monsterAttackMax + 1);
                                playerHealth -= atk;
                                Console.SetCursorPosition(2, 27);
                                Console.Write("                             ");
                                Console.SetCursorPosition(2, 27);
                                Console.Write("怪物对你造成了{0}点伤害", atk);
                                Console.SetCursorPosition(2, 28);
                                Console.Write("                              ");
                                Console.SetCursorPosition(2, 28);
                                Console.Write("玩家血量为:{0}  怪物血量为:{1}", playerHealth, monsterHealth);
                                if (playerHealth <= 0)
                                {
                                    Console.SetCursorPosition(2, 25);
                                    Console.Write("                             ");
                                    Console.SetCursorPosition(2, 26);
                                    Console.Write("                             ");
                                    Console.SetCursorPosition(2, 27);
                                    Console.Write("                             ");
                                    Console.SetCursorPosition(2, 28);
                                    Console.Write("                             ");
                                    Console.SetCursorPosition(2, 25);
                                    Console.Write("你死了");
                                }
                            }
                            else
                            {
                                Console.SetCursorPosition(2, 25);
                                Console.Write("                             ");
                                Console.SetCursorPosition(2, 26);
                                Console.Write("                             ");
                                Console.SetCursorPosition(2, 27);
                                Console.Write("                             ");
                                Console.SetCursorPosition(2, 28);
                                Console.Write("                             ");
                                Console.SetCursorPosition(2, 25);
                                Console.Write("你战胜了怪物，前去营救公主吧,按J继续");
                            }
                        }
                    }
                }
                else
                {
                    #region 移动
                    Console.SetCursorPosition(curX, curY);
                    Console.Write("  ");
                    switch (playerInput)
                    {
                        case 'W':
                        case 'w':
                            curY -= 1;
                            if (curY < 1)
                            {
                                curY = 1;
                            }
                            else if (monsterHealth > 0 && curX == monsterX && curY == monsterY)
                            {
                                ++curY;
                            }
                            else if (curX == 24 && curY == 5 && monsterHealth <= 0)
                            {
                                ++curY;
                            }
                            break;

                        case 'S':
                        case 's':
                            curY += 1;
                            if (curY > y - 7)
                            {
                                curY = y - 7;
                            }
                            else if (monsterHealth > 0 && curX == monsterX && monsterY == curY)
                            {
                                --curY;
                            }
                            else if (curX == 24 && curY == 5 && monsterHealth <= 0)
                            {
                                --curY;
                            }
                            break;

                        case 'A':
                        case 'a':
                            curX -= 2;
                            if (curX < 2)
                            {
                                curX = 2;
                            }
                            else if (monsterHealth > 0 && curY == monsterY && curX == monsterX)
                            {
                                curX += 2;
                            }
                            else if (curX == 24 && curY == 5 && monsterHealth <= 0)
                            {
                                curX += 2;
                            }
                            break;

                        case 'D':
                        case 'd':
                            curX += 2;
                            if (curX > x - 4)
                            {
                                curX = x - 4;
                            }
                            else if (monsterHealth > 0 && curY == monsterY && monsterX == curX)
                            {
                                curX -= 2;
                            }
                            else if (curX == 24 && curY == 5 && monsterHealth <= 0)
                            {
                                curX -= 2;
                            }
                            break;
                        #endregion

                        #region 战斗
                        case 'J':
                        case 'j':
                            if ((curX == monsterX && monsterY - curY == 1 ||
                                 curX == monsterX && curY - monsterY == 1 ||
                                 curY == monsterY && monsterX - curX == 2 ||
                                 curY == monsterY && curX - curX == 2) && monsterHealth > 0)
                            {
                                isFight = true;
                                Console.SetCursorPosition(2, 25);
                                Console.Write("开始战斗，按J继续");
                                Console.SetCursorPosition(2, 28);
                                Console.Write("玩家血量为:{0}  怪物血量为:{1}", playerHealth, monsterHealth);
                            }
                            else if ((curX == 24 && 5 - curY == 1 ||
                                       curX == 24 && curY - 5 == 1 ||
                                       curY == 5 && 24 - curX == 2 ||
                                       curY == 5 && curX - 24 == 2) && monsterHealth <= 0)
                            {
                                nowSceneID = 2;
                                isOver = true;
                                gameOverInfo = "胜利";
                            }
                            break;
                    }
                    #endregion
                    if (isOver)
                    {
                        break;
                    }
                }
            }
            break;

        //结束界面
        case 2:
            Console.SetCursorPosition(x / 2 - 4, 5);
            Console.Write("GameOver");

            Console.SetCursorPosition(x / 2 - 2, 7);
            Console.Write(gameOverInfo);

            int nowSelEndIndex = 0;
            while (true)
            {
                bool isQuitEndWhile = false;
                Console.SetCursorPosition(x / 2 - 5, 9);
                Console.ForegroundColor = nowSelEndIndex == 0 ? ConsoleColor.Red : ConsoleColor.White;
                Console.Write("回到主菜单");

                Console.SetCursorPosition(x / 2 - 4, 11);
                Console.ForegroundColor = nowSelEndIndex == 1 ? ConsoleColor.Red : ConsoleColor.White;
                Console.Write("退出游戏");

                input = Console.ReadKey(true).KeyChar;
                switch (input)
                {
                    case 'W':
                    case 'w':
                        --nowSelEndIndex;
                        if (nowSelEndIndex < 0)
                        {
                            nowSelEndIndex = 0;
                        }
                        break;
                    case 'S':
                    case 's':
                        ++nowSelEndIndex;
                        if (nowSelEndIndex > 1)
                        {
                            nowSelEndIndex = 1;
                        }
                        break;
                    case 'J':
                    case 'j':
                        if (nowSelEndIndex == 0)
                        {
                            nowSelEndIndex = 1;
                            nowSceneID = 0;
                            isQuitEndWhile = true;
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                        break;
                }
                if (isQuitEndWhile)
                {
                    break;
                }
            }
            break;
    }
}
#endregion