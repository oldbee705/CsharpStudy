namespace 万物之父
{
    class Player
    {
        public String name;
        public float hp;
        public float atk;
        public float def;
        public int miss;

        public Player(string name, float hp, float atk, float def)
        {
            this.name = name;
            this.hp = hp;
            this.atk = atk;
            this.def = def;
            miss = 5;
        }
        
        public override String ToString()
        {
            return string.Format("玩家{0},血量{1},攻击力{2},防御力{3}", name, hp, atk, def);
        }
    }
    class Monster
    {
        public float atk;
        public float def;
        public float hp;
        public int skillID;
        public Player player;
        public Monster(float atk,  float def, float hp, Player p)
        {
            this.atk = atk;
            this.def = def;
            this.hp = hp;
            this.player = p;
        }

        public override String ToString() 
        {
            return string.Format("攻击力{0},防御力{1},血量{2},玩家{3}", atk, def, hp, player);
        }
        public Monster Clone()
        {
            return MemberwiseClone() as Monster;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player("张三", 20, 10, 5);
            Player p2 = new Player("李四", 10, 22, 22);
            Console.WriteLine(p1);
            Console.WriteLine(p2);

            Monster A = new Monster(20, 10, 5, p1);
            Console.WriteLine(A);
            Monster B = A.Clone();
            B.player = p2;
            Console.WriteLine(B);
            
        }
    }
}
