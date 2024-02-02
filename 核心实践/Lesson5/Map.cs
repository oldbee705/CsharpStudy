using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 核心实践贪吃蛇.Lesson3;
using 核心实践贪吃蛇.Lesson4;
using 核心实践贪吃蛇.Lesson1;


namespace 核心实践贪吃蛇.Lesson5
{
    internal class Map : IDraw
    {
        public Wall[] walls;
        private int index;

        public Map()
        {
            
            walls = new Wall[Game.w + (Game.h - 2) * 2];
            for (int i = 0; i < Game.w; i += 2)
            {
                walls[index] = new Wall(i, 0);
                ++index;
            }

            for (int i = 0; i < Game.w; i += 2)
            {
                walls[index] = new Wall(i, 19);
                ++index;
            }

            for (int i = 1; i < Game.h - 1; i++)
            {
                walls[index] = new Wall(0, i);
                ++index;
            }

            for (int i = 1; i < Game.h - 1; i++)
            {
                walls[index] = new Wall(78, i);
                ++index;
            }
        }

        public void Draw()
        {
            for (int i = 0;i < walls.Length ;i++)
            {
                walls[i].Draw();
            }
        }
    }
}
