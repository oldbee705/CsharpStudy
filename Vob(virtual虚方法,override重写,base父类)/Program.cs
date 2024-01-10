namespace Vob_virtual虚方法_override重写_base父类_
{
    class Duck
    {
        public virtual void Shout()
        {
            Console.WriteLine("嘎嘎");
        }
    }
    class WookDuck : Duck
    {
        public override void Shout()
        {
            Console.WriteLine("吱吱");
        }
    }
    class RubberDuck : Duck
    {
        public override void Shout()
        {
            Console.WriteLine("唧唧");
        }
    }
    class Staff
    {
        public int time;
        public Staff(int time = 9)
        {
            this.time = time;
        }
        public virtual void ClockIn()
        {
            Console.WriteLine("{0}点打卡", time);
        }
    }
    class Manager : Staff
    {
        public Manager() : base(11)
        {

        }
        public override void ClockIn()
        {
            base.ClockIn();
        }
    }
    class Programmer : Staff
    {
        public override void ClockIn()
        {
            Console.WriteLine("不打卡");
        }
    }
    class Graph 
    {
        public virtual float GetArea()
        {
            return 0;
        }

        public virtual float GetLength()
        {
            return 0;
        }
    }
    class Rect : Graph
    {
        private float w;
        private float h;
        public Rect(float w, float h)
        {
            this.w = w;
            this.h = h;
        }
        public override float GetArea()
        {
            return w * h;
        }
        public override float GetLength()
        {
            return 2 * (w + h);
        }
    }
    class Square : Graph
    {
        private float l;
        public Square(float l)
        {
            this.l = l;
        }

        public override float GetArea()
        {
            return l * l;
        }
        public override float GetLength()
        {
            return l * 4;
        }
    }
    class Circular : Graph
    {
        private float r;
        private const float PI = 3.14f;
        public Circular(float r)
        {
            this.r = r;
        }

        public override float GetArea()
        {
            return PI * r * r;
        }
        public override float GetLength()
        {
            return PI * r * 2;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Duck d1 = new Duck();
            Duck d2 = new WookDuck();
            Duck d3 = new RubberDuck();
            d1.Shout();
            d2.Shout();
            d3.Shout();

            Staff w2 = new Manager();
            Staff w1 = new Staff();
            Staff w3 = new Programmer();
            w1.ClockIn();
            w2.ClockIn();
            w3.ClockIn();

            Graph g = new Rect(2,4);
            Graph g2 = new Square(3);
            Graph g3 = new Circular(3);
            Console.WriteLine(g.GetArea());
            Console.WriteLine(g.GetLength());
            Console.WriteLine(g2.GetArea());
            Console.WriteLine(g2.GetLength());
            Console.WriteLine(g3.GetArea());
            Console.WriteLine(g3.GetLength());
        }
    }
}
