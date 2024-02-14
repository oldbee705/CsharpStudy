namespace 顺序存储和链式存储
{
    //链表、堆、栈、数组、散列表、队列、图、树
    //顺序存储在内存上是一段连续的存储单元、链式存储不连续
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            LinkedNode<int> node = list.Head;
            while(node != null)
            {
                Console.WriteLine(node.value);
                node = node.next;
            }
            node = list.Last;
            while(node != null)
            {
                Console.WriteLine(node.value);
                node = node.front;
            }

            Console.WriteLine("***************");

            list.RemoveAt(0);
            list.RemoveAt(3);
            node = list.Head;
            while (node != null)
            {
                Console.WriteLine(node.value);
                node = node.next;
            }
            node = list.Last;
            while (node != null)
            {
                Console.WriteLine(node.value);
                node = node.front;
            }

            Console.WriteLine("***************");

            list.RemoveAt(3);
            node = list.Head;
            while (node != null)
            {
                Console.WriteLine(node.value);
                node = node.next;
            }
            node = list.Last;
            while (node != null)
            {
                Console.WriteLine(node.value);
                node = node.front;
            }
            list.RemoveAt(3);
        }
    }

    class LinkedNode<T>
    {
        public T value;
        public LinkedNode<T> front;
        public LinkedNode<T> next;

        public LinkedNode(T value)
        {
            this.value = value;
        }
    }
    class LinkedList<T>
    {
        private int nodeCount = 0;
        private LinkedNode<T> head;
        private LinkedNode<T> last;

        //增加到链表的最后一个节点
        public void Add(T value)
        {
            LinkedNode<T> node = new LinkedNode<T>(value);
            if (head == null)
            {
                head = node;
                last = node;
            }
            else
            {
                last.next = node;
                node.front = last;
                last = node;
            }
            ++nodeCount;
        }

        //删除指定位置节点
        public void RemoveAt(int index)
        {
            if(index >= nodeCount || index < 0)
            {
                Console.WriteLine("只有{0}个节点,请输入合法位置", nodeCount);
                return;
            }
            int tempCount = 0;
            LinkedNode<T> tempNode = head;
            while(true)
            {
                //找到需要删除的节点
                if (tempCount == index)
                {
                    //当前节点的上一个节点指向自己的下一个节点，下一个节点指向自己的上一个节点
                    if (tempNode.front != null)
                    {
                        tempNode.front.next = tempNode.next;
                    }
                    if (tempNode.next != null)
                    {
                        tempNode.next.front = tempNode.front;
                    }
                    //为头结点时
                    if (index == 0)
                    {
                        head = head.next;
                    }
                    else if (index == nodeCount - 1)
                    {
                        last = last.front;
                    }
                    --nodeCount;
                    break;
                }
                ++tempCount;
                tempNode = tempNode.next;
            }
        }

        public int NodeCount
        {
            get { return nodeCount; }
        }
        public LinkedNode<T> Head
        {
            get { return head; }
        }
        public LinkedNode<T> Last
        {
            get { return last; }
        }
    }
}
