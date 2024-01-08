namespace 静态成员
{
    class Test
    {
        private static Test t = new Test();
        public int testInt = 10;
        public static Test T
        {
            get 
            { 
                return t; 
            }
        }
        private Test()
        {

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.Write(Test.T.testInt);
        }
    }
}
