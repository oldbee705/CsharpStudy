
//using可以引用别的命名空间
namespace 命名空间
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UI.Image UIImage = new UI.Image();
            Graph.Image GraphImage = new Graph.Image();
        }
    }
}
namespace UI
{
    class Image
    {

    }
}

namespace Graph
{
    class Image
    {

    }
}
