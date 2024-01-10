using System.Reflection.Metadata;

namespace 继承中的构造函数
{
    class Worker
    {
        public string type;
        public string content;

        public Worker(string type, string content)
        {
            this.type = type;
            this.content = content;
        }
        public void Work()
        {
            Console.Write(type);
            Console.WriteLine(content);
        }
    }

    class Programmer : Worker
    {
        public Programmer() : base("程序员", "打代码")
        { 

        }
    }
    class Plan : Worker
    {
        public Plan() : base("策划", "设计游戏")
        {

        }
    }
    class Art : Worker
    {
        public Art() : base("美术", "画画")
        {

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Programmer programmer = new Programmer();
            programmer.Work();

            Plan plan = new Plan();
            plan.Work();

            Art art = new Art();
            art.Work();
        }
    }
}
