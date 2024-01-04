namespace 构造函数和析构函数
{
    class Person
    {
        public int id;
        public string name;
        public int age;
        public bool sex;

        public Person() 
        {
            id = 1;
            name = "";
            age = 1;
            sex = false;
        }

        public Person(int id):this()
        {
            this.id = id;
        }

        public Person(int id, string name, int age, bool sex)
        {
            this.id = id;
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

        public Class()
        {
            id = 1;
            name = "";
            students = new Person[0];
        }

        public Class(string name) : this()
        {
            this .name = name;
        }

        public Class(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public void PrintInfo()
        {
            Console.WriteLine(id);
        }
    }
    class Ticket
    {
        public int distance;
        public int value;

        public Ticket(int distance)
        {
            if (distance < 0)
            {
                this.distance = 0;
                value = this.distance;
            }
            else if(distance <= 100)
            {
                this.distance = distance;
                value = distance;
            }
            else if (distance <= 200)
            {
                this.distance = distance;
                value = (int)(distance * 0.95);
            }
            else if(distance <= 300)
            {
                this.distance = distance;
                value = (int)(distance * 0.9);}
            else
            {
                this.distance = distance;
                value = (int)(distance * 0.8);
            }
            
        }
        public void GetPrice()
        {
            Console.Write("{0}公里{1}块钱", distance, value);
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

            Ticket t1 = new Ticket(321);
            t1.GetPrice();
        }
    }
}
