using System.Runtime.CompilerServices;

namespace 拓展方法
{
    static class Test
    {
        public static int GetSquare(this int num)
        {
            return num * num;
        }

        public static void Kill(this Player p)
        {
            Console.WriteLine("{0}自杀了。", p.name);
        }
    }

    class Player
    {
        public string name;
        public int health;
        public int attack;
        public int defense;

        public Player(string name)
        {
            this.name = name;
        }
        public void Attack()
        {
            Console.WriteLine("{0}进行了攻击。", name);
        }

        public void Move()
        {
            Console.WriteLine("{0}进行了移动。", name);
        }

        public void hurted()
        {
            Console.WriteLine("{0}受到了攻击。", name);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 20;
            Console.WriteLine(a.GetSquare());
            Player p = new Player("陈卓豪");
            p.Kill();
        }
    }
}
