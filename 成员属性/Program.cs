namespace 成员属性
{
    class Student
    {
        public string name;
        private byte age;
        private bool sex;
        private float csharpScore;
        private float unityScore;

        public Student(string name)
        {
            this.name = name;
        }
        public void Introduce()
        {
            Console.WriteLine("我叫{0}，今年{1}岁了，是{2}同学。", name, age, sex ? "男" : "女");
        }

        public void PrintScore()
        {
            Console.WriteLine("我的总分是{0}，我的平均分是{1}。", GetSumScore(), GetAvgScore());
        }

        private float GetSumScore()
        {
            float sum = csharpScore + unityScore;
            return sum;
        }

        private float GetAvgScore()
        {
            float avg = GetSumScore() / 2;
            return avg;
        }

        public byte Age
        {
            get
            {
                return age;
            }
            set
            { 
                if (value >= 0 && value <= 150)
                {
                    age = value;
                }
                else
                {
                    Console.WriteLine("请输入0-150之间的数");
                }
                
            }
        }
        public float CsharpScore
        {
            get
            {
                return csharpScore;
            }
            set
            {
                if(value >= 0 && value <= 100)
                {
                    csharpScore = value;
                }
                else
                {
                    Console.WriteLine("请输入0-100之间的数");
                }
            }
        }
        public float UnityScore
        {
            get
            {
                return unityScore;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    unityScore = value;
                }
                else
                {
                    Console.WriteLine("请输入0-100之间的数");
                }
            }
        }
        public bool Sex
        {
            get
            {
                return sex;
            }
            set
            {
                if (sex == false || sex == true)
                {
                    sex = value;
                }
                else
                {
                    Console.WriteLine("请输入true或false");
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student("张三");
            s1.Sex = true;
            s1.Age = 20;
            s1.CsharpScore = 50;
            s1.UnityScore = 70;
            s1.Introduce();
            s1.PrintScore();
            Student s2 = new Student("李四");
            s2.Sex = false;
            s2.Age = 18;
            s2.CsharpScore = 70;
            s2.UnityScore = 90;
            s2.Introduce();
            s2.PrintScore();
        }
    }
}
