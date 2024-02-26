using System.Collections;

namespace 迭代器
{
    class Custom1 : IEnumerable,IEnumerator
    {
        private int[] ints;
        private int index = -1;
        public object Current
        {
            get
            {
                return ints[index];
            }
        }

        public Custom1(params int[] ints)
        {
            this.ints = ints;
        }
        public IEnumerator GetEnumerator()
        {
            Reset();
            return this;
        }

        public bool MoveNext()
        {
           ++index;
            return index < ints.Length;
        }

        public void Reset()
        {
            index = -1;
        }
    }

    class Custom2 : IEnumerable
    {
        private int[] list;

        public Custom2(params int[] list)
        {
            this.list = list;
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < list.Length; i++)
            {
                yield return list[i];
            }
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Custom1 custom1 = new Custom1(321 , 333, 111, 12333);
            Custom2 custom2 = new Custom2(1, 33, 556, 77);
            foreach (int item in custom1)
            {
                Console.WriteLine(item);
            }

            foreach (int item in custom2)
            {
                Console.WriteLine(item);
            }
        }
    }
}
