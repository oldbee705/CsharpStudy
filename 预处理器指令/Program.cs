#define Unity5
#define Unity2017
#define Unity2020
namespace 预处理器指令
{
    //#region #endregion
    //#define #undef 
    //#if #elif #else #endif
    //#error #warning
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        static int Calc(int a, int b)
        {
#if Unity5
            return a + b;
#elif Unity2017
            return a * b;
#elif Unity2020
            return a - b;
#else
            return 0;
#endif
        }
    }
}
