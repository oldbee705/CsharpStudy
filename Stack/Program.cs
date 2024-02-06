using System.Collections;
using System.Runtime.InteropServices;

namespace Stack栈
{
    //先进后出
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            int a = 22;
            Calculate(a);
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
            void Calculate(int value)
            {
                while (true)
                {
                    stack.Push(value % 2);
                    value /= 2;
                    if (value == 1)
                    {
                        stack.Push(value);
                        break;
                    }
                }
            }
        }
    }
}
