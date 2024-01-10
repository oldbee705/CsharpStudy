using System;

namespace 密封类
{
    class Vehicle
    {
        private float speed;
        public float maxSpeed;
        public int capacity;

        private Person driver;
        public int numOfPerson;
        public Person[] passengers;

        public float Speed
        {
            get { return speed; }
            set 
            {
                if (speed > maxSpeed)
                {
                    speed = maxSpeed;
                }
                else
                {
                    speed = value;
                }
            }
        }

        public Person Driver
        {
            get
            {
                return driver;
            }
            set
            {
                if (driver == null)
                {
                    driver = value;
                }
                else
                {
                    Console.WriteLine("原来的{0}司机被替换成{1}司机了。", driver, value);
                    driver = value;
                }
            }
        }

        /// <summary>
        /// 载具构造函数
        /// </summary>
        /// <param name="maxSpeed">最大速度</param>
        /// <param name="capacity">可乘坐数量</param>
        public Vehicle(float maxSpeed, int capacity)
        {
            this.maxSpeed = maxSpeed;
            this.capacity = capacity;
            passengers = new Person[capacity];
            numOfPerson = 0;
        }

        public void Geton(Person passenger)
        {
            if (capacity > numOfPerson)
            {
                passengers[numOfPerson] = passenger;
                numOfPerson++;
            }
            else
            {
                Console.WriteLine("满人了");
            }
        }

        public void Getoff(Person passenger)
        {
            for (int i = 0; i < passengers.Length; i++)
            {
                if(passenger == passengers[i])
                {
                    passengers[i] = null;
                    numOfPerson--;
                }
            }
            Console.WriteLine("没有这个人");
        }

        public void Travel()
        {
            Console.WriteLine("正在以{0}公里/小时行驶。", speed);
        }

        public void Accident()
        {
            Console.WriteLine("发生车祸");
        }

        public void PrintInfo()
        {
            Console.WriteLine("当前速度为：{0}，最大速度为：{1}，可乘人数为：{2}，司机为：{3}，当前乘客人数为：{4}",
                                              speed, maxSpeed, capacity, driver, numOfPerson);
        }

        public void PrintPerson()
        {
            for(int i = 0;i < passengers.Length; i++)
            {
                if (passengers[i] != null)
                {
                    Console.WriteLine(passengers[i].name);
                }
                
            }
        }
    }

    class Person
    {
        public string name;

        public Person(string name)
        {
            this.name = name;
        }
    }

    class Driver : Person
    {
        public Driver()  :base("司机")
        {

        }
    }

    class Passenger : Person
    {
        public Passenger() : base("乘客")
        {

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle bus = new Vehicle(90, 50);
            bus.Speed = 30;
            Person p1 = new Passenger();
            Person p2 = new Passenger();
            Person p3 = new Passenger();
            Person p4 = new Passenger();
            Person p5 = new Passenger();
            bus.Driver = p1;
            bus.Driver = p2;
            bus.Geton(p2);
            bus.PrintInfo();
            bus.Geton(p3);
            bus.Geton(p4);
            bus.Geton(p5);
            bus.PrintInfo();
            bus.Getoff(p5);
            bus.Getoff(p2);
            bus.PrintInfo();
            bus.Travel();
            bus.Accident();
            bus.PrintInfo();
            bus.Getoff(p3);
            bus.PrintInfo();
            bus.PrintPerson();
        }
    }
}
