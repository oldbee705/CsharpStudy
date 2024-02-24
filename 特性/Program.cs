using System.Diagnostics;
using System;
using System.Reflection;
using Microsoft.VisualBasic.FileIO;

namespace 特性
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
            Type playerType = assembly.GetType("反射类库.Player");
            object player = Activator.CreateInstance(playerType);
            Console.WriteLine(player);

            FieldInfo[] fields = playerType.GetFields();
            for (int i = 0; i < fields.Length; i++)
            {
                Console.WriteLine(fields[i]);
            }
            //得到特性
            Type attribute = assembly.GetType("反射类库.MyCustomAttribute");
            //赋值名字
            FieldInfo playerName = playerType.GetField("name");
            //判断是否有特性
            if (playerName.GetCustomAttribute(attribute) != null)
            {
                Console.WriteLine("非法操作，随意修改name成员");
            }
            else
            {
                playerName.SetValue(player, "123123");
            }
            
            Console.WriteLine(playerName);
        }
    }
}
