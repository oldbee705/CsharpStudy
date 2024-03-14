using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    class Map : IDraw
    {
        private List<DrawObject> walls;
        private List<DrawObject> dynamicWalls;
        public Map()
        {
            walls = new List<DrawObject>();
            for (int i = 0; i < Game.h - 5 ; i++)
            {
                walls.Add(new DrawObject(0, i,E_CubeType.Wall));
                walls.Add(new DrawObject(48, i, E_CubeType.Wall));
            }
            for (int i = 0; i < Game.w ; i+=2)
            {
                walls.Add(new DrawObject(i, Game.h - 5, E_CubeType.Wall));
            }
        }
        public void Draw()
        {
            for (int i = 0; i < walls.Count; i++)
            {
                walls[i].Draw();
            }
            for (int i = 0; i < dynamicWalls.Count; i++)
            {
                dynamicWalls[i].Draw();
            }
        }
        public void AddDynamicWalls(List<DrawObject> walls)
        {
            for(int i = 0;i < walls.Count;i++)
            {
                walls[i].ChangeType(E_CubeType.Wall);
                dynamicWalls.Add(walls[i]);
            }
        }
    }
}
