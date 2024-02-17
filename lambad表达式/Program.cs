using System;

namespace lambad表达式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestAction()();
        }

        static Action TestAction()
        {
            Action action = null;
            for (int i = 1; i < 11; i++)
            {
                int index = i;
                action += () =>
                {
                    Console.WriteLine(index);
                };
            }
            return action;
        }
    }
}
