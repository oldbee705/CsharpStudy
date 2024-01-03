static int max(int a, int b)
{
    if (a > b)
    {
        return a;
    }else
    {
        return b;
    }
}
 
static float[] areacir(float r)
{
    float area = 3.14f * r * r;
    float cir = 3.14f * 2 * r;
    return [area, cir]; //等同于 return new float[] {area, cir}
}

static int[] arrOperation(int[] arr)
{
    int sum = 0;
    int max = 0;
    int min = 0;
    int avg = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        sum += arr[i];
    }

    for (int i = 0; i < arr.Length; i++)
    {
        if(max == 0 || arr[i] > max)
        {
            max = arr[i];
        }
        if(min == 0 || arr[i] < min)
        {
            min = arr[i];
        }
    }

    avg = sum/arr.Length;

    return [sum,max,min,avg];
}

static bool isPrimeNumber(int num)
{
    for (int i = 2; i < num; i++) 
    {
        if (num % i == 0)
        {
            return false;
        }
    }
    return true;
}

static bool isLeapYear(int year)
{
    if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
    {
        return true;
    }
    return false;

}
Console.WriteLine(max(3, 4));
Console.WriteLine(areacir(3)[0] + " " + areacir(3)[1]);
int[] arr1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
Console.WriteLine("总和：{0}  最大数：{1}  最小数：{2}  平均数:{3}", arrOperation(arr1)[0], arrOperation(arr1)[1], arrOperation(arr1)[2], arrOperation(arr1)[3]);
Console.WriteLine("{0}{1}质数",47,isPrimeNumber(47) ? "是" : "不是");
Console.WriteLine("{0}年{1}闰年", 2000,isLeapYear(2000) ? "是" : "不是");
