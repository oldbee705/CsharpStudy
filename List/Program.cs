namespace List
{
    abstract class Monster
    {
        public static List<Monster> monsters = new List<Monster>();
        public Monster()
        {
            monsters.Add(this);
        }

        public abstract void Atk();
    }

    class Boss : Monster
    {
        public override void Atk()
        {
            Console.WriteLine("Boss攻击");
        }
    }

    class Gablin : Monster
    {
        public override void Atk()
        {
            Console.WriteLine("哥布林攻击");
        }
    }
    //List可以自定义存储类型，ArrayList以Object类型存储，会使用装箱拆箱从而导致占用更多内存
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            List<string> list2 = new List<string>();
            List<bool> list3 = new List<bool>();


            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Remove(1);
            list.RemoveAt(1);
            list[0] = 20;
            Console.WriteLine(list[0]);
            Console.WriteLine("************************");

            List<int> ints = new List<int>();
            for (int i = 10; i > 0; i--)
            {
                ints.Add(i);
            }
            ints.RemoveAt(4);
            for (int i = 0; i < ints.Count; i++)
            {
                Console.WriteLine(ints[i]);
            }
            Console.WriteLine("************************");

            Boss b1 = new Boss();
            Boss b2 = new Boss();
            Gablin g1 = new Gablin();
            Gablin g2 = new Gablin();

            for(int i = 0; i < Monster.monsters.Count; i++)
            {
                Monster.monsters[i].Atk();
            }
            
            foreach(Monster monster in Monster.monsters) 
            { 
                monster.Atk(); 
            }

        }
    }
}
