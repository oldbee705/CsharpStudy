namespace 继承的基本规则
{
    class Human
    {
        public string name;
        public int age;

        public void Speak()
        {
            Console.WriteLine("啊啊啊啊");
        }
    }

    class Warrior : Human
    {
        public void Atk()
        {
            Console.WriteLine("攻击");
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
