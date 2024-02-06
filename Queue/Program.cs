using System.Collections;

namespace Queue队列
{
    //先进先出
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue();
            for (int i = 1; i <= 10; i++)
            {
                queue.Enqueue(i);
            }
            int updateIndex = 0;
            while (true)
            {
                if(queue.Count > 0)
                {
                    if (updateIndex == 100000000)
                    {
                        Console.WriteLine(queue.Dequeue());
                        updateIndex = 0;
                    }
                }
                ++updateIndex;
            }
        }
    }
}
