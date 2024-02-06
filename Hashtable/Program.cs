using System.Collections;
namespace Hashtable散列表 
{
    class Monster
    {
        public int id;

        public Monster(int id)
        {
            this.id = id;
        }
    }

    class MonsterMgr
    {
        private static MonsterMgr instance = new MonsterMgr();
        private Hashtable monsters = new Hashtable();
        private MonsterMgr()
        {

        }
        public static MonsterMgr Instance
        {
            get
            {
                return instance;
            }
        }

        private int monsterId = 0;

        public void CreateMonster()
        {
            Monster monster = new Monster(monsterId);
            ++monsterId;

            monsters.Add(monster.id, monster);
        }

        public void DeleteMonster(int monsterId)
        {
            if (monsters.ContainsKey(monsterId))
            {
                monsters.Remove(monsterId);
            }
        }

        public void showMonsters()
        {
            foreach (DictionaryEntry item in monsters)
            {
                Console.WriteLine((item.Value as Monster).id);
            }
        }
    }
    //一个key绑定一个value，通过key来控制value的存储
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable hashtable = new Hashtable();

            hashtable.Add(1,2);
            hashtable.Add(2,3);
            hashtable.Add(3,4);

            foreach (DictionaryEntry item in hashtable)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("**********************");

            MonsterMgr.Instance.CreateMonster();
            MonsterMgr.Instance.CreateMonster();
            MonsterMgr.Instance.CreateMonster();
            MonsterMgr.Instance.CreateMonster();
            MonsterMgr.Instance.CreateMonster();

            MonsterMgr.Instance.DeleteMonster(0);
            MonsterMgr.Instance.DeleteMonster(3);

            MonsterMgr.Instance.showMonsters();
        }
    }
}
