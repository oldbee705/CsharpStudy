//ref必须要在外面赋值(里面也可以赋值)
using System.Globalization;
using System.Net.Http.Headers;

static int a(ref int a)
{
    a = 2;
    return a;
}

//out外面不需要赋值（里面必须赋值），相当于传空参
static int b(out int b)
{
    b = 1;
    return b;
}

//int a1 = 1;
//int b1;
//Console.WriteLine(a(ref a1));
//Console.WriteLine(b(out b1));


static bool CheckLogin(String name, String password, out String loginInfo)
{
    if (name == "admin")
    {
        if (password == "888888")
        {
            loginInfo = "成功登录";
            return true;
        }
        else
        {
            loginInfo = "密码错误";
            return false;
        }
    }
    else
    {
        loginInfo = "查无此人";
        return false;
    }
}
string loginInfo;
Console.WriteLine(CheckLogin("admin","888888",out loginInfo) + loginInfo);

static void calcSumAvg(params int[] arr)
{
    int sum = 0;
    int avg;
    for (int i = 0; i < arr.Length; i++)
    {
        sum += arr[i];
    }
    avg = sum/arr.Length;
    Console.WriteLine("总和是：{0} 平均数是:{1}", sum, avg);
}

static void calc(params int[] arr)
{
    int sum1 = 0;
    int sum2 = 0;
    for (int i = 0;i < arr.Length;i++)
    {
        if (arr[i] % 2 == 0)
        {
            sum1 += arr[i];
        }
        else
        {
            sum2 += arr[i];
        }
    }
    Console.WriteLine("偶数和：{0}  奇数和：{1}",sum1,sum2);
}

calcSumAvg(1,0,6,7,1,2,3,4);
calc(10,20,30,40,5,11,60,10);

