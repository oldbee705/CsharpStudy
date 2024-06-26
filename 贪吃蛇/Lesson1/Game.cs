﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using 核心实践贪吃蛇.Lesson2;

namespace 核心实践贪吃蛇.Lesson1
{
    //场景类型枚举
    enum E_SceneType
    {
        Begin,
        Game,
        End,
    }
    class Game
    {
        //游戏窗口宽高
        public const int w = 80;
        public const int h = 20;
        //当前选中的场景
        public static ISceneUpdate nowScene;

        public Game()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(w, h);
            Console.SetBufferSize(w + 1, h + 1);

            ChangeScene(E_SceneType.Begin);
            
        }

        //游戏开始
        public void Start()
        {
            //游戏主循环 负责游戏场景逻辑的更新
            while (true)
            {
                //判断当前游戏场景不为空 就更新
                if (nowScene != null)
                {
                    nowScene.Update();
                }
            }
        }

        public static void ChangeScene(E_SceneType type)
        {
            Console.Clear();
            switch (type)
            {
                case E_SceneType.Begin:
                    nowScene = new BeginScene();
                    break;
                case E_SceneType.Game:
                    nowScene = new GameScene();
                    break;
                case E_SceneType.End:
                    nowScene = new EndScene();
                    break;
            }
        }
    }

}
