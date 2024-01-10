namespace 万物之父和装箱拆箱
{
    //用万物之父object来存储对象，即装箱
    //将对象转换成对应的类型，即拆箱
    //值类型用强转、引用类型用里氏替换原则
    internal class Program
    {
        static void Main(string[] args)
        {
            object a = 100;
            int a1 = (int)a;
            Console.WriteLine(a1);

            object b = "HelloWorld!";
            string b1 = b.ToString();
            Console.WriteLine(b1);
        }
    }
}
