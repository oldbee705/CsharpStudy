using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 核心实践贪吃蛇.Lesson1;
using 核心实践贪吃蛇.Lesson4;
using 核心实践贪吃蛇.Lesson5;

namespace 核心实践贪吃蛇.Lesson2
{
    class GameScene : ISceneUpdate
    {
        Map map;
        Snake snake;
        Food food;
        int clockIndex;

        public GameScene()
        {
            map = new Map();
            snake = new Snake(40, 10);
            food = new Food(snake);
        }
        public void Update()
        {
            if (clockIndex % 10000 == 0)
            {
                map.Draw();
                food.Draw();

                snake.Move();
                snake.Draw();
                if (snake.CheckEnd(map))
                {
                    Game.ChangeScene(E_SceneType.End);
                }

                snake.CheckEatFood(food);

                clockIndex = 0;
            }
            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        snake.ChangeDir(E_MoveDir.Up);
                        break;
                    case ConsoleKey.A:
                        snake.ChangeDir(E_MoveDir.Left);
                        break;
                    case ConsoleKey.S:
                        snake.ChangeDir(E_MoveDir.Down);
                        break;
                    case ConsoleKey.D:
                        snake.ChangeDir(E_MoveDir.Right);
                        break;
                }
            }

            clockIndex++;
        }
    }
}
