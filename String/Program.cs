using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace String
{
    //1.
    //截取substring
    //替换replace

    //3.
    //没有区别
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            string str2 = "112312";
            Console.WriteLine(str2);
            str2 = str2.Substring(2,3);
            Console.WriteLine(str2);

            str2 = "112312";
            str2 = str2.Replace("1", "8");
            Console.WriteLine(str2);

            //2
            string str = "1|2|3|4|5|6|7";
            string[] str1 = str.Split("|");
            str = "";
            for (int i = 0; i < str1.Length; i++)
            {
                str += int.Parse(str1[i]) + 1 ;
                if (i < str1.Length - 1)
                {
                    str += "|";
                }
            }
            Console.WriteLine(str);

            //4.
            string str3 = null;
            str3 = "123";
            string str4 = str;
            str4 = "321";
            str4 += "123";
            Console.WriteLine(str3);
            Console.WriteLine(str4);

            //5.
            string read = Console.ReadLine();
            char[] chars = read.ToCharArray();
            void Reflect(string str)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    chars[i] = str[str.Length - i - 1];
                }
            }
            Reflect(read);
            read = new string(chars);
            Console.WriteLine(read);
        }
    }
}
