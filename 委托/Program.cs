namespace 委托
{
    abstract class Human
    {
        abstract public void Eat();
    }

    class Mother : Human
    {
        public Action beginEat;
        public void Cook()
        {
            Console.WriteLine("妈妈做饭");

            Console.WriteLine("妈妈做好饭了");

            beginEat();
        }

        public override void Eat()
        {
            Console.WriteLine("妈妈吃饭");
        }
    }

    class Father : Human
    {
        public override void Eat()
        {
            Console.WriteLine("爸爸吃饭");
        }
    }

    class Monster
    {
        public Action<Monster> deadDoSomething;
        //怪物的价值
        public int value = 10;
        public void Dead()
        {
            if (deadDoSomething != null)
            {
                Console.WriteLine("怪物死了");
                deadDoSomething(this);
            }
            else
            {
                Console.WriteLine("怪物已经死了");
            }
            deadDoSomething = null;
        }
    }

    class Player
    {
        public int money;

        public void MonsterDeadDo(Monster m)
        {
            money += m.value;
            Console.WriteLine("增加{0}金币", m.value);
        }
    }
    class Panel
    {
        public int money;

        public void MonsterDeadDo(Monster m)
        {
            money += m.value;
            Console.WriteLine("当前有{0}金币", money);
        }
    }

    class CJ
    {
        public int killNum;

        public void MonsterDeadDo(Monster m)
        {
            killNum += 1;
            Console.WriteLine("当前击杀了{0}个怪物。", killNum);
        }
    }

    class Child : Human
    {
        public override void Eat()
        {
            Console.WriteLine("孩子吃饭");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Mother mother = new Mother();
            Father father = new Father();
            Child child = new Child();
            mother.beginEat += father.Eat;
            mother.beginEat += child.Eat;
            mother.beginEat += mother.Eat;
            mother.Cook();
            Console.WriteLine("*************");
            Player player = new Player();
            Monster monster = new Monster();
            Panel panel = new Panel();
            CJ cj = new CJ();

            monster.deadDoSomething += player.MonsterDeadDo;
            monster.deadDoSomething += panel.MonsterDeadDo;
            monster.deadDoSomething += cj.MonsterDeadDo;
            monster.Dead();
            monster.Dead();

            Monster monster2 = new Monster();
            monster2.deadDoSomething += player.MonsterDeadDo;
            monster2.deadDoSomething += panel.MonsterDeadDo;
            monster2.deadDoSomething += cj.MonsterDeadDo;
            monster2.Dead();
        }
    }
}
