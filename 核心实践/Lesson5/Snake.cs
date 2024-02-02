using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 核心实践贪吃蛇.Lesson3;
using 核心实践贪吃蛇.Lesson4;

namespace 核心实践贪吃蛇.Lesson5
{
    enum E_MoveDir
    {
        Up,
        Down,
        Left,
        Right
    }
    internal class Snake : IDraw
    {
        public SnakeBody[] snake;
        int nowLen;
        E_MoveDir moveDir;
        public Snake(int x, int y)
        {
            snake = new SnakeBody[200];
            snake[0] = new SnakeBody(E_SnakeBody_Type.Head, x, y);

            nowLen = 1;
            moveDir = E_MoveDir.Right;
        }

        public void Draw()
        {
            for (int i = 0; i < nowLen; i++)
            {
                snake[i].Draw();
            }
        }

        public void Move()
        {
            SnakeBody lastBody = snake[nowLen - 1];
            Console.SetCursorPosition(lastBody.pos.x, lastBody.pos.y);
            Console.Write("  ");

            for (int i = nowLen - 1; i > 0; i--)
            {
                snake[i].pos = snake[i - 1].pos;
            }

            switch (moveDir)
            {
                case E_MoveDir.Left:
                    snake[0].pos.x -= 2;
                    break;
                case E_MoveDir.Right:
                    snake[0].pos.x += 2;
                    break;
                case E_MoveDir.Up:
                    snake[0].pos.y--;
                    break;
                case E_MoveDir.Down:
                    snake[0].pos.y++;
                    break;
            }
        }

        public void ChangeDir(E_MoveDir moveDir)
        {
            if (moveDir == this.moveDir ||
                nowLen > 1 &&
                (this.moveDir == E_MoveDir.Left && moveDir == E_MoveDir.Right ||
                 this.moveDir == E_MoveDir.Right && moveDir == E_MoveDir.Left ||
                 this.moveDir == E_MoveDir.Up && moveDir == E_MoveDir.Down ||
                 this.moveDir == E_MoveDir.Down && moveDir == E_MoveDir.Up)
                )
            {
                return;
            }
            this.moveDir = moveDir;
        }

        public bool CheckEnd(Map map)
        {
            for (int i = 0; i < map.walls.Length; i++)
            {
                if(snake[0].pos == map.walls[i].pos)
                {
                    return true;
                }
            }

            for(int i = 1; i < nowLen; i++)
            {
                if (snake[0].pos == snake[i].pos)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckSamePos(Position pos)
        {
            for(int i = 0;i < nowLen;i++)
            {
                if(pos == snake[i].pos)
                {
                    return true;
                }
            }
            return false;
        }

        public void CheckEatFood(Food food)
        {
            if (snake[0].pos == food.pos)
            {
                food.CreateFood(this);
                AddBody();
            }
        }

        private void AddBody()
        {

            snake[nowLen] = new SnakeBody(E_SnakeBody_Type.Body, snake[nowLen - 1].pos.x, snake[nowLen - 1].pos.y);
            nowLen++;
        }
    }
}
