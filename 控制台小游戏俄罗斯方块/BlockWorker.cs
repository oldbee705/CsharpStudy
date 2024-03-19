using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    class BlockWorker : IDraw
    {
        //被创建的方块
        private List<DrawObject> blocks;
        //被创建方块的信息
        private Dictionary<E_CubeType, BlockInfo> blocksInfoDic;
        //被创建的方块的当前信息
        private BlockInfo nowBlockInfo;
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

        private void RandomCreateBlocks()
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
            int index = r.Next(0, blocksInfoDic.Count);
            Position[] pos = nowBlockInfo[index];

            blocks[0].pos = new Position(24, 5);
            for (int i = 0; i < pos.Length; i++)
            {
                blocks[i + 1].pos = blocks[0].pos + pos[i];
            }
        }


    }
}
