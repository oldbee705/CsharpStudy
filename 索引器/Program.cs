namespace 索引器
{
    class IntArray
    {
        private int[] ints;

        private int this[int index]
        {
            get
            {
                return ints[index];
            }
            set
            {
                ints[index] = value;
            }
        }

        public void Add(int num)
        {

        }
        public void Delete(int num)
        {

        }
        public void Update(int lownum, int newnum)
        {
            if(Select(lownum) != 114514)
            {
                [Select(lownum)] = newnum;
            }
        }
        public int Select(int num)
        {
            for (int i = 0; i < ints.Length; i++)
            {
                if (num == ints[i])
                {
                    return i;
                }
            }
            return 114514;
        }

        public void PrintIndex(int index)
        {

            Console.WriteLine(index);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
