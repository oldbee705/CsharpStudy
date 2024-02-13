namespace Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("请输入不超过三位的整数");

                Console.WriteLine(GetInfo(int.Parse(Console.ReadLine())));
            }
            catch
            {
                Console.WriteLine("请输入合法的数字");
            }
            string str = "Welcome to Unity World!";
            GetCount(str);
        }

        static string GetInfo(int num)
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(0, "零");
            dic.Add(1, "壹");
            dic.Add(2, "贰");
            dic.Add(3, "叁");
            dic.Add(4, "肆");
            dic.Add(5, "伍");
            dic.Add(6, "陆");
            dic.Add(7, "柒");
            dic.Add(8, "捌");
            dic.Add(9, "玖");
            dic.Add(10, "拾");
            string str = "";
            int b = num / 100;
            int s = num % 100 / 10;
            int g = num % 10;
            if (b != 0)
            {
                str += dic[b];
            }
            if( s != 0 || str != "")
            {
                str += dic[s];
            }
            
            str += dic[g];
            return str;
        }

        static void GetCount(string str)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            str = str.ToLower(); 
            for (int i = 0; i < str.Length; i++)
            {
                if (dic.ContainsKey(str[i]))
                {
                    dic[str[i]] += 1;
                }
                else
                {
                    dic.Add(str[i], 1);
                }
            }

            foreach(char item in dic.Keys)
            {
                Console.WriteLine("{0}出现了{1}次",item, dic[item]);
            }
        }
    }
}
