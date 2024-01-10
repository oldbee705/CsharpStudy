namespace 抽象类和抽象方法
{
    abstract class Animal
    {
        public abstract void Shout();
    }
     class Person : Animal
    {
        public override void Shout()
        {
            Console.WriteLine("你好");
        }
    }
    class Dog : Animal
    {
        public override void Shout()
        {
            Console.WriteLine("汪汪");
        }
    }
    class Cat : Animal
    {
        public override void Shout()
        {
            Console.WriteLine("喵喵");
        }
    }

    abstract class Graph
    {
        public abstract float GetArea();
        public abstract float GetPerimeter();
    }
    class Rectangle : Graph
    {
        private float w;
        private float h;
        public Rectangle(float w, float h)
        {
            this.w = w;
            this.h = h;
        }
        public override float GetArea()
        {
            return w * h;
        }

        public override float GetPerimeter()
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

        public override float GetPerimeter()
        {
            return 4 * l;
        }
    }
    class Circle : Graph
    {
        private float r;
        private float PI = 3.14f;
        public Circle(float r)
        {
            this.r = r;
        }
        public override float GetArea()
        {
            return r * r * PI;
        }

        public override float GetPerimeter()
        {
            return PI * r * 2;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal p = new Person();
            Animal dog = new Dog();
            Animal cat = new Cat();
            p.Shout();
            dog.Shout();
            cat.Shout();

            Rectangle r = new Rectangle(4, 5);
            Square s = new Square(6);
            Circle c = new Circle(8);
            Console.WriteLine(c.GetArea());
            Console.WriteLine(c.GetPerimeter());
            Console.WriteLine(s.GetArea());
            Console.WriteLine(s.GetPerimeter());
            Console.WriteLine(r.GetArea());
            Console.WriteLine(r.GetPerimeter());
        }
    }
}
