using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    enum E_Change_Type
    {
        Left,
        Right
    }
    class BlockWorker : IDraw
    {
        
        //被创建的方块
        private List<DrawObject> blocks;
        //被创建方块的信息
        private Dictionary<E_CubeType, BlockInfo> blocksInfoDic;
        //被创建的方块的当前信息
        private BlockInfo nowBlockInfo;
        //当前形态的索引
        private int nowInfoIndex;
        public BlockWorker()
        {
            blocksInfoDic = new Dictionary<E_CubeType, BlockInfo>()
            {
                {E_CubeType.Cube, new BlockInfo(E_CubeType.Cube)},
                {E_CubeType.Line, new BlockInfo(E_CubeType.Line)},
                {E_CubeType.Tank, new BlockInfo(E_CubeType.Tank)},
                {E_CubeType.Left_Labber, new BlockInfo(E_CubeType.Left_Labber)},
                {E_CubeType.Right_Labber, new BlockInfo(E_CubeType.Right_Labber)},
                {E_CubeType.Long_Left_Labber, new BlockInfo(E_CubeType.Long_Left_Labber)},
                {E_CubeType.Long_Right_Labber, new BlockInfo(E_CubeType.Long_Right_Labber)},
            };

            RandomCreateBlocks();
        }
        public void Draw()
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                blocks[i].Draw();
            }
        }
        public void Clear()
        {
            for(int i = 0;i < blocks.Count; i++)
            {
                blocks[i].Clear();
            }
        }
        //随机创建方块们
        public void RandomCreateBlocks()
        {
            Random r = new Random();
            //随机一种类型
            E_CubeType type = (E_CubeType)r.Next(1,8);

            //创建被绘制的方块们
            blocks = new List<DrawObject>
            {
                new DrawObject(type),
                new DrawObject(type),
                new DrawObject(type),
                new DrawObject(type),
            };
            nowBlockInfo = blocksInfoDic[type];

            //随机一种形态
            nowInfoIndex = r.Next(0, blocksInfoDic.Count);

            //设置方块们的位置
            Position[] pos = nowBlockInfo[nowInfoIndex];
            blocks[0].pos = new Position(24, 5);
            for (int i = 0; i < pos.Length; i++)
            {
                blocks[i + 1].pos = blocks[0].pos + pos[i];
            }
        }
        //改变形态
        public void Change(E_Change_Type type)
        {
            Clear();
            switch (type)
            {
                case E_Change_Type.Left:
                    --nowInfoIndex;
                    if(nowInfoIndex < 0)
                    {
                        nowInfoIndex = nowBlockInfo.Count - 1;
                    }
                    break;
                case E_Change_Type.Right:
                    ++nowInfoIndex;
                    if(nowInfoIndex >= nowBlockInfo.Count)
                    {
                        nowInfoIndex = 0;
                    }
                    break;
            }
            Position[] pos = nowBlockInfo[nowInfoIndex];
            for (int i = 0; i < pos.Length; i++)
            {
                blocks[i+1].pos = blocks[0].pos + pos[i];
            }
            Draw();
        }
        //能否改变形态
        public bool CanChange(E_Change_Type type, Map map)
        {
            int nowIndex = nowInfoIndex;
            switch (type)
            {
                case E_Change_Type.Left:
                    --nowIndex;
                    if (nowIndex < 0)
                    {
                        nowIndex = nowBlockInfo.Count - 1;
                    }
                    break;
                case E_Change_Type.Right:
                    ++nowIndex;
                    if (nowIndex >= nowBlockInfo.Count)
                    {
                        nowIndex = 0;
                    }
                    break;
            }
            Position[] nowPos = nowBlockInfo[nowIndex];
            Position tempPos;
            //判断是否超出地图边缘
            for (int i = 0; i < nowPos.Length; i++)
            {
                tempPos = blocks[0].pos + nowPos[i];
                if (tempPos.x < 2 ||
                    tempPos.x >= Game.w - 2 ||
                    tempPos.y >= Game.h - 5)
                {
                    return false;
                }
            }
            //判断是否和动态地图重叠
            for(int i = 0; i < nowPos.Length; i++)
            {
                tempPos = blocks[0].pos + nowPos[i];
                for (int j = 0; j < map.dynamicWalls.Count; j++)
                {
                    if (tempPos == map.dynamicWalls[j].pos)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        //左右移动
        public void MoveLR(E_Change_Type type)
        {
            Clear();
            //原位置+偏移
            Position movePos = new Position((type == E_Change_Type.Left ? -2 : 2), 0);
            for (int i = 0; i < blocks.Count; i++)
            {
                blocks[i].pos += movePos;
            }
            Draw();
        }
        //能否移动
        public bool CanMove(E_Change_Type type, Map map)
        {
            //判断是否超出边界
            Position movePos = new Position((type == E_Change_Type.Left ? -2 : 2), 0);
            Position tempPos;
            for (int i = 0; i < blocks.Count; i++)
            {
                tempPos = blocks[i].pos + movePos;
                if(tempPos.x < 2|| 
                   tempPos.x >= Game.w - 2)
                {
                    return false;
                }
            }
            //判断是否和动态墙壁重叠
            for (int i = 0; i < blocks.Count; i++)
            {
                tempPos = blocks[i].pos + movePos;
                for (int j = 0; j < map.dynamicWalls.Count; j++)
                {
                    if( tempPos == map.dynamicWalls[j].pos)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
