using System.Runtime.CompilerServices;

namespace Thread多线程
{
    enum E_Direction
    {
        up,
        down, 
        left, 
        right
    }
    class Icon
    {
        //位置
        private int x;
        private int y;
        //方向
        private E_Direction dir;
        public Icon(int x, int y, E_Direction dir)
        {
            this.x = x;
            this.y = y;
            this.dir = dir;
        }

        //移动
        public void Move()
        {
            switch (dir)
            {
                case E_Direction.up:
                    y -= 1;
                    break;
                case E_Direction.down:
                    y += 1;
                    break;
                case E_Direction.left:
                    x -= 2;
                    break;
                case E_Direction.right:
                    x += 2;
                    break;
            }
        }
        //转向
        public void ChangeDic(E_Direction dic)
        {
            this.dir = dic;
        }
        //绘制
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("■");
        }
        //擦除
        public void Clear()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("  ");
        }
    }
    internal class Program
    {
        static Icon icon;
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            icon = new Icon(5, 3, E_Direction.right);
            icon.Draw();

            Thread t1 = new Thread(Input);
            t1.IsBackground = true;
            t1.Start();
            //主循环
            while (true)
            {
                Thread.Sleep(500);
                icon.Clear();
                icon.Move();
                icon.Draw();
            }
        }

        static void Input()
        {
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        icon.ChangeDic(E_Direction.up);
                        break;
                    case ConsoleKey.S:
                        icon.ChangeDic(E_Direction.down);
                        break;
                    case ConsoleKey.A:
                        icon.ChangeDic(E_Direction.left);
                        break;
                    case ConsoleKey.D:
                        icon.ChangeDic(E_Direction.right);
                        break;
                }
            }
        }
    }
}
