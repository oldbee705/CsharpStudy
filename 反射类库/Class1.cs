namespace 反射类库
{
    public struct Position
    {
        public int x;
        public int y;

        public Position() { }
    }
    public class Player
    {
        public string Name;
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
