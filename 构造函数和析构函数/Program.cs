namespace 构造函数和析构函数
{
    class Person
    {
        public int id;
        public string name;
        public int age;
        public bool sex;

        public Person(int id)
        {
            this.id = id;
        }

        public Person(int id, string name, int age, bool sex):this(id)
        {
            this.name = name;
            this.age = age;
            this.sex = sex;
        }

        public void PrintInfo()
        {
            System.Console.WriteLine(id);
        }
    }
    class Class
    {
        public int id;
        public string name;
        public Person[] students;

        public Class(string name)
        {
            this .name = name;
        }

        public Class(int id, string name):this(name)
        {
            this.id = id;
        }

        public void PrintInfo()
        {
            Console.WriteLine(id);
        }
    }
    class Ticket
    {
        public uint distance;
        public float price;

        public Ticket(uint distance)
        {
            this.distance = distance;
            price = GetPrice();
        }
        private float GetPrice()
        {
            if (distance <= 100)
            {
                price = distance;
            }
            else if (distance <= 200)
            {
                price = distance * 0.95f;
            }
            else if (distance <= 300)
            {
                price = distance * 0.9f;
            }
            else
            {
                price = distance * 0.8f;
            }
            return price  / 10000 * 10000;
        }

        public void PrintInfo()
        {
            Console.Write("{0}公里{1}块钱", distance, price);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person(1,"张三",18,true);
            p.PrintInfo();
            Person p1 = new Person(2);
            p1.PrintInfo();

            Class class1 = new Class("计算机");
            class1.PrintInfo();
            Class class2 = new Class(1101,"自然");
            class2.PrintInfo();

            Ticket t1 = new Ticket(300);
            t1.PrintInfo();
        }
    }
}
