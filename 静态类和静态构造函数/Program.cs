namespace 静态类和静态构造函数
{
    static class Math
    {
        public const float PI = 3.14f;
        public static float CirSquare(float radius)
        {
            float square = radius * radius * PI;
            return square;
        }
        public static float CirPerimeter(float radius)
        {
            float perimeter = radius * 2 * PI;
            return perimeter;
        }
        public static float RectangleSquare(float w, float h)
        {
            float square = w * h;
            return square;
        }
        public static float RectanglePerimeter(float w, float h)
        {
            float perimeter = 2 * (w + h);
            return perimeter;
        }
        public static float Absolute(float value)
        {
            if (value < 0)
            {
                return -value;
            }
            else
            {
                return value;
            }
        }

        static Math()
        {
            Console.WriteLine("调用静态构造函数");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            float r = 6f;
            int x = 4;
            int y = 9;
            int test = -222;
            Console.WriteLine(Math.CirSquare(r));
            Console.WriteLine(Math.CirPerimeter(r));
            Console.WriteLine(Math.RectangleSquare(x, y));
            Console.WriteLine(Math.RectanglePerimeter(x, y));
            Console.WriteLine(Math.Absolute(test));

        }
    }
}
