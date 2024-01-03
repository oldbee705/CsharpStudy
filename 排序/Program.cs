using static System.Collections.Specialized.BitVector32;

namespace 排序
{
    internal class Program
    {
        //sort  true升序  false降序
        static void BubbleSort(int[] arr, bool sort)
        {
            bool isSort = false;
            if (sort)
            {
                Console.WriteLine("#### #### 冒泡升序 #### ####");

                for (int i = 0; i < arr.Length; i++)
                {
                    isSort = false;
                    for (int j = 0; j < arr.Length - 1 - i; j++)
                    {
                        if (arr[j] > arr[j + 1])
                        {
                            isSort = true;
                            int temp = arr[j + 1];
                            arr[j + 1] = arr[j];
                            arr[j] = temp;
                        }
                    }
                    if (!isSort)
                    {
                        break;
                    }
                }
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine(arr[i]);
                }
            }
            else
            {
                Console.WriteLine("#### #### 冒泡降序 #### ####");
                for (int i = 0; i < arr.Length; i++)
                {
                    isSort = false;
                    for (int j = 0; j < arr.Length - 1 - i; j++)
                    {
                        if (arr[j] < arr[j + 1])
                        {
                            isSort = true;
                            int temp = arr[j + 1];
                            arr[j + 1] = arr[j];
                            arr[j] = temp;
                        }
                    }
                    if (!isSort)
                    {
                        break;
                    }
                }
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine(arr[i]);
                }
            }
        }

        static void SelectionSort(int[] arr, bool sort)
        {
            
            if (sort)
            {
                Console.WriteLine("#### #### 选择升序 #### ####");

                for (int i = 0; i < arr.Length; i++)
                {
                    int index = 0;
                    for (int j = 1; j < arr.Length - i; j++)
                    {
                        //找出数组最大数的索引
                        if (arr[index] < arr[j])
                        {
                            index = j;
                        }
                    }
                    //如果最大的数不在对应的位置，则交换位置
                    if (arr[index] != arr[arr.Length - 1 - i])
                    {
                        int temp = arr[arr.Length - 1 - i];
                        arr[arr.Length - 1 - i] = arr[index];
                        arr[index] = temp;
                    }
                }
                //输出结果
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine(arr[i]);
                }
            }
            else
            {
                Console.WriteLine("#### #### 选择降序 #### ####");
                for (int i = 0; i < arr.Length; i++)
                {
                    int index = 0;
                    for (int j = 1; j < arr.Length - i; j++)
                    {
                        //找出数组最大数的索引
                        if (arr[index] > arr[j])
                        {
                            index = j;
                        }
                    }
                    //如果最大的数不在对应的位置，则交换位置
                    if (arr[index] != arr[arr.Length - 1 - i])
                    {
                        int temp = arr[arr.Length - 1 - i];
                        arr[arr.Length - 1 - i] = arr[index];
                        arr[index] = temp;
                    }
                }
                //输出结果
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine(arr[i]);
                }
            }
        }

        static void Main(string[] args)
        {
            int[] arr1 = new int[20];
            Random r = new Random();
            
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = r.Next(0,101);
                Console.WriteLine(arr1[i]);
            }
            BubbleSort(arr1, true);
            SelectionSort(arr1, true);

            BubbleSort(arr1, false);
            SelectionSort(arr1, false);

        }
    }
}
