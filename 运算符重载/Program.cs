namespace 运算符重载
{
    internal class Program
    {
        class Position
        {
            public int x; 
            public int y;

            public Position(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public static bool operator ==(Position p1, Position p2)
            {
                if (p1.x == p2.x && p1.y == p2.y)
                {
                    return true;
                }
                return false;
            }

            public static bool operator !=(Position p1, Position p2)
            {
                if (p1.x == p2.x && p1.y == p2.y)
                {
                    return false;
                }
                return true;
            }
        }
        class Vector3
        {
            public float x;
            public float y;
            public float z;

            public Vector3()
            {

            }
            public Vector3(float x, float y, float z)
            {
                this.x=x;
                this.y=y;
                this.z=z;
            }

            public void showInfo()
            {
                Console.WriteLine("{0},{1},{2}", x, y, z);
            }

            public static Vector3 operator +(Vector3 v1, Vector3 v2)
            {
                Vector3 newVec3 = new Vector3();
                newVec3.x = v1.x + v2.x;
                newVec3.y = v1.y + v2.y;
                newVec3.z = v1.z + v2.z;
                return newVec3;
            }

            public static Vector3 operator -(Vector3 v1, Vector3 v2)
            {
                Vector3 newVec3 = new Vector3();
                newVec3.x = v1.x - v2.x;
                newVec3.y = v1.y - v2.y;
                newVec3.z = v1.z - v2.z;
                return newVec3;
            }
            public static Vector3 operator *(Vector3 v1, int num)
            {
                Vector3 newVec3 = new Vector3();
                newVec3.x = v1.x * num;
                newVec3.y = v1.y * num;
                newVec3.z = v1.z * num;
                return newVec3;
            }
        }
        static void Main(string[] args)
        {
            Position p = new Position(1, 2);
            Position p1 = new Position(1, 2);
            Position p2 = new Position(2, 3);
            Console.WriteLine(p == p1);
            Console.WriteLine(p != p2);

            Vector3 v = new Vector3(2, 2, 2);
            Vector3 v1 = new Vector3(2, 3, 5);
            (v + v1).showInfo();
            Vector3 v2 = new Vector3(2, 4, 1);
            (v1 - v2).showInfo();
            Vector3 v3 = new Vector3(4, 5, 4);
            v3 *= 3;
            v3.showInfo();
        }
    }
}
