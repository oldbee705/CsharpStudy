using System.Reflection.Metadata;

namespace 结构体
{
    internal class Program
    {
        struct Student
        {
            public string name;
            public bool sex;
            public int age;
            public int clas;
            public string major;

            public Student(string name, bool sex, int age, int clas, string major)
            {
                this.name = name;
                this.sex = sex;
                this.age = age;
                this.clas = clas;
                this.major = major;
            }

            public void printInfo()
            {
                Console.WriteLine("姓名：{0} 性别：{1} 年龄：{2} 班级：{3} 会:{4}",
                    name,sex ? "男" : "女",age,clas,major);
            }
        }

        struct Rectangle
        {
            public int x;
            public int y;

            public Rectangle(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public void printInfo()
            {
                Console.WriteLine("长：{0} 宽：{1} 面积：{2} 周长：{3}",x,y,x*y,(x+y)*2);
            }
        }

        struct Player
        {
            public string name;
            public E_Occupation occupation; 

            public Player(string name, E_Occupation occupation)
            {
                this.name = name;
                this.occupation = occupation;
            }
            
            public void useSill()
            {
                switch (occupation)
                {
                    case E_Occupation.维修工:
                        Console.WriteLine("维修工{0}会修地堡",name);
                        break;
                    case E_Occupation.外卖小哥:
                        Console.WriteLine("外卖小哥{0}会嘲讽",name); 
                        break;
                    case E_Occupation.狗:
                        Console.WriteLine("狗{0}会吃屎",name);
                        break;

                }
            }
        }

        struct Monster
        {
            public string name;
            public int atk;

            public Monster(string name)
            {
                this.name=name;
                Random r = new Random();
                atk = r.Next(1,15);
            }

            public void Atk()
            {
                Console.WriteLine(name + "  " + atk);
            }
        }

        struct OutMan
        {
            public int atk;
            public int hp;
            public int def;

            public OutMan(int atk, int hp, int def)
            {
                this.atk = atk; 
                this.hp = hp;
                this.def = def;
            }

            public void Atk(ref Boss monster)
            {
                monster.hp -= atk - monster.def;
                Console.WriteLine("奥特曼对小怪兽造成了{0}点伤害,小怪兽还剩{1}血", atk - monster.def, monster.hp);

            }
        }

        struct Boss
        {
            public int atk;
            public int hp;
            public int def;

            public Boss(int atk, int hp, int def)
            {
                this .atk = atk;
                this .hp = hp;
                this .def = def;
            }

            public void Atk(ref OutMan outMan)
            {
                outMan.hp -= atk - outMan.def;
                Console.WriteLine("小怪兽对奥特曼造成了{0}点伤害,奥特曼还剩{1}血",atk - outMan.def,outMan.hp);
            }
        }

        enum E_Occupation
        {
            维修工,
            外卖小哥,
            狗
        }

        static void Main(string[] args)
        {
            //Student student1 = new Student("张三", false, 18, 1101, "飞");
            //student1.printInfo();
            //Student student2 = new Student("李四", true, 20, 2033, "跑");
            //student2.printInfo();

            //Rectangle rectangle1 = new Rectangle(4, 5);
            //rectangle1.printInfo();

            //Player player1 = new Player("俞浩", E_Occupation.狗);
            //player1.useSill();
            //Player player2 = new Player("导", E_Occupation.外卖小哥);
            //player2.useSill();
            //Player player3 = new Player("08", E_Occupation.维修工);
            //player3.useSill();

            //Monster[] monsters = new Monster[10];
            //for (int i = 0; i < monsters.Length; i++)
            //{
            //    monsters[i] = new Monster("俞浩" + i);
            //    monsters[i].Atk();
            //}

            OutMan outMan1 = new OutMan(20, 20, 5);
            Boss monster1 = new Boss(7, 30, 15);
            while (true)
            {
                if(monster1.hp > 0)
                {
                    outMan1.Atk(ref monster1);
                    if(monster1.hp <= 0)
                    {
                        Console.WriteLine("奥特曼赢");
                        break;
                    }
                    monster1.Atk(ref outMan1);
                    if (outMan1.hp <= 0)
                    {
                        Console.WriteLine("小怪兽赢");
                        break;
                    }
                    Console.ReadKey(true);
                }
            }
        }
    }
}
