using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace List排序
{
    enum E_ItemType
    {
        weapon,
        tool,
        food,
        material
    }
    enum E_ItemQuality
    {
        premium,
        rare,
        normal
    }
    class Monster : IComparable<Monster>
    {
        public int atk;
        public int def;
        public int hp;
        public static int SortType = 1;

        public Monster(int atk, int def, int hp)
        {
            this.atk = atk;
            this.def = def;
            this.hp = hp;
        }

        public int CompareTo(Monster? other)
        {
            switch (SortType)
            {
                case 1:
                    return this.atk < other.atk ? -1 : 1;
                case 2:
                    return this.def < other.def ? -1 : 1;
                case 3:
                    return this.hp < other.hp ? -1 : 1;
            }
            return 0;
        }

        public override string ToString()
        {
            return string.Format("怪物信息-akt:{0} def:{1} hp:{2}", atk, def, hp);
        }
    }
    class Item : IComparable<Item>
    {
        public E_ItemType type;
        public string name;
        public E_ItemQuality quality;
        public Item(E_ItemType type, string name, E_ItemQuality quality)
        {
            this.type = type;
            this.quality = quality;
            this.name = name;
        }

        public int CompareTo(Item? other)
        {
            //判断类型是否相同 不相同按类型比
            if(this.type != other.type)
            {
                return this.type < other.type ? -1 : 1;
            }
            //判断品质是否相同 不相同按品质比
            else if (this.quality != other.quality)
            {
                return this.quality < other.quality ? -1 : 1;
            }
            //判断名字长度是否相同 不相同按名字长度比
            else
            {
                return this.name.Length < other.name.Length ? 1 : -1;
            }
            
            
        }

        public override string ToString()
        {
            return string.Format("类型:{0}名称:{1}品质:{2}", type, name, quality);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 练习题1
            //List<Monster> monsters = new List<Monster>();
            //Random r = new Random();
            //for (int i = 0; i < 10; i++)
            //{
            //    monsters.Add(new Monster(r.Next(1, 100), r.Next(0, 10), r.Next(20, 50)));
            //    Console.WriteLine(monsters[i]);
            //}
            //Console.WriteLine("***************");
            //Console.WriteLine("请选择排序类型");
            //Console.WriteLine("1.按照攻击力升序排序");
            //Console.WriteLine("2.按照防御力升序排序");
            //Console.WriteLine("3.按照血量升序排序");
            //Console.WriteLine("4.翻转");
            //try
            //{
            //    Monster.SortType = int.Parse(Console.ReadLine());
            //}
            //catch
            //{
            //    Console.WriteLine("请输入合法的数字");
            //}
            //if (Monster.SortType == 4)
            //{
            //    monsters.Reverse();
            //}
            //monsters.Sort();
            //for (int i = 0; i < monsters.Count; i++)
            //{
            //    Console.WriteLine(monsters[i]);
            //}
            #endregion
            #region 练习题2
            //List<Item> items = new List<Item>();
            //Random r = new Random();
            //for (int i = 0; i < 10; i++)
            //{
            //    items.Add(new Item((E_ItemType)r.Next(0,4), "Item" + r.Next(1,201), (E_ItemQuality)r.Next(0,3)));;
            //    Console.WriteLine(items[i]);
            //}
            //Console.WriteLine("***************");
            //items.Sort();
            //for(int i = 0; i < items.Count;i++)
            //{
            //    Console.WriteLine(items[i]);
            //}
            #endregion
            #region 练习题3
            List<KeyValuePair<string, int>> dictionaries = new List<KeyValuePair<string, int>>();
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("oldbee", 20000);
            dic.Add("zasda", 5325);
            dic.Add("fdsfa", 15123);
            foreach (KeyValuePair<string, int> item in dic)
            {
                dictionaries.Add(item);
                Console.WriteLine(item.Key + " " + item.Value);
            }
            dictionaries.Sort((a, b) =>
            {
                return a.Value < b.Value ? -1 : 1;
            });

            for (int i = 0; i < dictionaries.Count; i++)
            {
                Console.WriteLine(dictionaries[i]);
            }
            #endregion
        }
    }
}
