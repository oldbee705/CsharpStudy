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
        public List<DrawObject> dynamicWalls;
        private List<DrawObject> delWalls;
        //地图中x轴上的容量
        private int w;
        //地图中y轴上的容量
        private int h;
        //记录每一行有多少个方块
        private int[] recordInfo;
        public Map()
        {
            w = 0;
            h = Game.h - 6;
            recordInfo = new int[h];
            walls = new List<DrawObject>();
            dynamicWalls = new List<DrawObject>();
            delWalls = new List<DrawObject>();
            for (int i = 0; i < Game.h - 5 ; i++)
            {
                walls.Add(new DrawObject(0, i,E_CubeType.Wall));
                walls.Add(new DrawObject(48, i, E_CubeType.Wall));
            }
            for (int i = 0; i < Game.w ; i+=2)
            {
                walls.Add(new DrawObject(i, Game.h - 5, E_CubeType.Wall));
                ++w;
            }
            w -= 2;
            
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
                //当方块转变时将其记录
                recordInfo[h - walls[i].pos.y] += 1;
            }
            
            CheckClear();
            Draw();
        }
        private void Clear()
        {
            for(int i = 0; i < dynamicWalls.Count; i++)
            {
                dynamicWalls[i].Clear();
            }
        }
        private void CheckClear()
        {
            //当某一行中的格子数量等于容量时
            for(int i = 0; i < recordInfo.Length; i++)
            {
                if( w == recordInfo[i])
                {
                    Clear();
                    //清空当前行
                    for (int j = 0; j < dynamicWalls.Count;  j++)
                    {
                        if (i == h - dynamicWalls[j].pos.y)
                        {
                            //记录要清除的方块
                            delWalls.Add(dynamicWalls[j]);
                        }
                        //上方所有动态墙壁下移一行
                        else if (i < h - dynamicWalls[j].pos.y)
                        {
                            ++dynamicWalls[j].pos.y;
                        }
                    }
                    //清除
                    for(int j = 0; j < delWalls.Count; j++)
                    {
                        dynamicWalls.Remove(delWalls[j]);
                    }
                    //记录方块数量的容器从上到下迁移
                    for(int j = 0; j < recordInfo.Length - 1; j++)
                    {
                        recordInfo[j] = recordInfo[j + 1];
                    }
                    //最上面一行置空
                    recordInfo[recordInfo.Length - 1] = 0;
                    //消过一次之后在进行判断是否需要继续删除
                    CheckClear();
                    break;
                }
            }
              
            
        }
    }
}
