namespace 反射类库
{
    //学习反射时使用
    class MyCustomAttribute : Attribute
    {

    }
    public struct Position
    {
        public int x;
        public int y;

        public Position() { }
    }
    public class Player
    {
        [MyCustom()]
        public string name;
        public int hp;
        public int atk;
        public int def;
        public Position pos;

        public override string ToString()
        {
            return string.Format("hp:{0} atk:{1} def:{2}", hp, atk, def);
        }
    }
}
