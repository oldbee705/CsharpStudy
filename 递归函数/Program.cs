namespace 递归函数
{
    internal class Program
    {
        static void Fun1(int a)
        {
            Console.WriteLine(a);
            if (a < 10) 
            {
                ++a;
                Fun1(a);
            }
        }

        static int Fun2(int a)
        {
            if (a == 1)
            {
                return 1;
            }
            return a * Fun2(a - 1);
        }

        static int Fun3(int a)
        {
            if (a == 1)
            {
                return Fun2(1);
            }
            return Fun2(a) + Fun3(a - 1);
        }

        static float Fun4(float a,int b = 10)
        {
            
            if (b >= 0)
            {
                --b;
                return Fun4(a / 2, b);
            }
            return a;
        }
        //Fun3(50,9)
        //Fun3(25,8)
        //Fun3(12.5,7)

        static bool Fun5(int a = 1)
        {
            Console.WriteLine(a);
            return a == 200 || Fun5(a + 1);
        }


        static void Main(string[] args)
        {
            Fun1(0);
            Console.WriteLine( Fun2(5));
            Console.WriteLine( Fun3(10));
            Console.WriteLine( Fun4(100,10));
            Console.WriteLine( Fun5());
        }
    }
}
