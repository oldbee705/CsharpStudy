namespace 泛型约束
{
    class SingleBase<T> where T : new()
    {
        private static T instance = new T();
        
        public static T Instance
        {
            get
            {
                return instance;
            }
        }
    }

    class ArraryList<T>
    {
        private T[] array;
        private int count;

        public ArraryList()
        {
            count = 0;
            array = new T[16];
        }
        public void Add(T item)
        {
            //判断是否需要扩容
            if (Count >= Capacity)
            {
                T[] temp = new T[Capacity * 2];
                for (int i = 0; i < Capacity; i++)
                {
                    temp[i] = array[i];
                }
                array = temp;
            }
            //不需要扩容
            array[count] = item;
            ++count;
        }

        public void Remove(T item)
        {
            int index = -1;
            for (int i = 0; i < Count; i++)
            {
                if (array[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }

            if(index != -1)
            {
                RemoveAt(index);
            }
        }

        public void RemoveAt(int index)
        {
            if(index < 0 || index >= Count)
            {
                Console.WriteLine("索引不合法");
                return;
            }

            for (; index < Count - 1; index++)
            {
                array[index] = array[index + 1];
            }
            array[count - 1] = default(T);
            --count;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    Console.WriteLine("索引不合法");
                    return default(T);
                }
                return array[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    Console.WriteLine("索引不合法");
                    return;
                }
                array[index] = value;
            }
        }

        /// <summary>
        /// 获取容量
        /// </summary>
        public int Capacity
        {
            get
            {
                return array.Length;
            }
        }

        /// <summary>
        /// 获取当前数量
        /// </summary>
        public int Count
        {
            get
            {
                return count;
            }
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            ArraryList<int> array = new ArraryList<int>();
            Console.WriteLine(array.Count);
            Console.WriteLine(array.Capacity);
            array.Add(1);
            array.Add(2);
            array.Add(3);
            Console.WriteLine(array.Count);
            Console.WriteLine(array.Capacity);

            array.Remove(1);
            array.RemoveAt(0);
            Console.WriteLine(array[0]);
            Console.WriteLine(array.Count);
            array[0] = 20;
            Console.WriteLine(array[0]);
        }
    }
}
