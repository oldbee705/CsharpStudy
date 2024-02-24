using System.Diagnostics;
using System.Reflection;

namespace 反射
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFrom(@"F:\Csharp\Git\oldbee705\CsharpStudy\反射类库\bin\Debug\net8.0\反射类库");
            Type[] types = assembly.GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine(types[i]);
            }
            Type player = assembly.GetType("反射类库.Player");
            object obj = Activator.CreateInstance(player);
            Console.WriteLine(obj);
        }
    }
}
