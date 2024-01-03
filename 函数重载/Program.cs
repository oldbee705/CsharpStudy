namespace 函数重载
{
    internal class Program
    {
        static int GetMax(int num1, int num2)
        {
            return num1 > num2 ? num1 : num2;
        }

        static float GetMax(float num1, float num2)
        {
            return num1 > num2 ? num1 : num2;
        }

        static double GetMax(double num1, double num2)
        {
            return num1 > num2 ? num1 : num2;
        }

        static int GetMax(params int[] arr)
        {
            int max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                } 
            }
            return max;
        }

        static float GetMax(params float[] arr)
        {
            float max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                }
            }
            return max;
        }

        static double GetMax(params double[] arr)
        {
            double max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                } 
            }
            return max;
        }
        static void Main(string[] args)
        {

            Console.WriteLine("{0}大", GetMax(1,2));
            Console.WriteLine("{0}大", GetMax(1.1, 2.2));
            Console.WriteLine("{0}大", GetMax(1.1f, 3.3f));
            Console.WriteLine("{0}最大", GetMax(1, 2, 3, 4, 5));
            Console.WriteLine("{0}最大", GetMax(1.23, 2.112, 3.542, 4.523, 5.5122));
            Console.WriteLine("{0}最大", GetMax(512.12f, 123.1f, 3.123f, 123.1f, 125.1f));
        }
    }
}
