namespace LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> linkedList = new LinkedList<int>(); 

            Random r= new Random();
            for (int i = 0; i < 10; i++)
            {
                linkedList.AddLast(r.Next(0, 100));
            }
            
            LinkedListNode<int> node = linkedList.First;
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
            Console.WriteLine("**************");
            node = linkedList.Last;
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Previous;
            }
        }
    }
    
}
 