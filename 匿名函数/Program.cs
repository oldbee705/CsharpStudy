namespace 匿名函数
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TestFun(5)(5));
        }

        static Func<int, int> TestFun(int i)
        {
            return delegate (int j)
            {
                return i * j;
            };
        }
    }
}
