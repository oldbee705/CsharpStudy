using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    class BlockInfo
    {
        /// <summary>
        /// 用于存储每个方块类型中四种不同状态的除原点外三个方块的位置信息
        /// </summary>
        private List<Position[]> posList;
        public BlockInfo(E_CubeType type)
        {
           posList = new List<Position[]>();
            switch (type)
            {
                case E_CubeType.Cube:
                    posList.Add(new Position[3] {
                    new Position(2,0),
                    new Position(0,1),
                    new Position(2,1)
                    });
                    break;
                case E_CubeType.Line:
                    posList.Add(new Position[3] {
                    new Position(0,-1),
                    new Position(0,1),
                    new Position(0,2)
                    });
                    posList.Add(new Position[3] {
                    new Position(-4,0),
                    new Position(-2,0),
                    new Position(2,0)
                    });
                    posList.Add(new Position[3] {
                    new Position(0,-2),
                    new Position(0,-1),
                    new Position(0,1)
                    });
                    posList.Add(new Position[3] {
                    new Position(-2,0),
                    new Position(2,0),
                    new Position(4,0)
                    });
                    break;
                case E_CubeType.Tank:
                    posList.Add(new Position[3] {
                    new Position(-2,0),
                    new Position(2,0),
                    new Position(0,1)
                    });
                    posList.Add(new Position[3] {
                    new Position(0,-1),
                    new Position(-2,0),
                    new Position(0,1)
                    });
                    posList.Add(new Position[3] {
                    new Position(0,-1),
                    new Position(-2,0),
                    new Position(2,0)
                    });
                    posList.Add(new Position[3] {
                    new Position(0,-1),
                    new Position(2,0),
                    new Position(0,1)
                    });
                    break;
                case E_CubeType.Left_Labber:
                    posList.Add(new Position[3] {
                    new Position(0,-1),
                    new Position(2,0),
                    new Position(2,1)
                    });
                    posList.Add(new Position[3] {
                    new Position(2,0),
                    new Position(0,1),
                    new Position(-2,1)
                    });
                    posList.Add(new Position[3] {
                    new Position(-2,-1),
                    new Position(-2,0),
                    new Position(0,1)
                    });
                    posList.Add(new Position[3] {
                    new Position(0,-1),
                    new Position(2,-1),
                    new Position(-2,0)
                    });
                    break;
                case E_CubeType.Right_Labber:
                    posList.Add(new Position[3] {
                    new Position(0,-1),
                    new Position(-2,1),
                    new Position(-2,0)
                    });
                    posList.Add(new Position[3] {
                    new Position(-2,-1),
                    new Position(0,-1),
                    new Position(2,0)
                    });
                    posList.Add(new Position[3] {
                    new Position(2,-1),
                    new Position(2,0),
                    new Position(0,1)
                    });
                    posList.Add(new Position[3] {
                    new Position(-2,0),
                    new Position(2,1),
                    new Position(0,1)
                    });
                    break;
                case E_CubeType.Long_Left_Labber:
                    posList.Add(new Position[3] {
                    new Position(-2,-1),
                    new Position(0,-1),
                    new Position(0,1)
                    });
                    posList.Add(new Position[3] {
                    new Position(2,1),
                    new Position(2,0),
                    new Position(-2,0)
                    });
                    posList.Add(new Position[3] {
                    new Position(0,-1),
                    new Position(2,1),
                    new Position(0,1)
                    });
                    posList.Add(new Position[3] {
                    new Position(-2,0),
                    new Position(2,0),
                    new Position(-2,1)
                    });
                    break;
                case E_CubeType.Long_Right_Labber:
                    posList.Add(new Position[3] {
                    new Position(0,-1),
                    new Position(2,-1),
                    new Position(0,1)
                    });
                    posList.Add(new Position[3] {
                    new Position(-2,0),
                    new Position(2,0),
                    new Position(2,1)
                    });
                    posList.Add(new Position[3] {
                    new Position(0,-1),
                    new Position(0,1),
                    new Position(-2,1)
                    });
                    posList.Add(new Position[3] {
                    new Position(-2,-1),
                    new Position(2,0),
                    new Position(-2,0)
                    });
                    break;
            }
        }
        public Position[] this[int index]
        {
            get 
            {
                if (index < 0)
                    return posList[0];
                else if (index >= posList.Count)
                    return posList[posList.Count - 1];
                else
                    return posList[index];
            }
        }
        public int Count { get => posList.Count; }
    }
}
