namespace 泛型
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine(Fun<int>());
            Console.WriteLine(Fun<char>());
            Console.WriteLine(Fun<float>());
            Console.WriteLine(Fun<string>());
            Console.WriteLine(Fun<double>());
        }

        static string Fun<T>()
        {
            if(typeof(T) == typeof(int))
            {
                return string.Format("{0}:{1}字节", "整形", sizeof(int));
            }
            else if (typeof(T) == typeof(char))
            {
                return string.Format("{0}:{1}字节", "字符", sizeof(char));
            }
            else if (typeof(T) == typeof(float))
            {
                return string.Format("{0}:{1}字节", "单精度浮点数", sizeof(float));
            }
            else if (typeof(T) == typeof(string))
            {
                return string.Format("{0}:{1}字节", "字符串", "?");
            }
            return "其他类型";
        }
    }
}
