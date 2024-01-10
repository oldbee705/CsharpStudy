using System.Threading.Channels;

namespace 里氏替换原则
{
    //is判断对象是否属于某个类，返回true或false
    //as判断对象是否属于某个类，是的话为这个类，不是返回null

    class Monster
    {

    }
    class Boss : Monster
    {
        public void Skill()
        {
            Console.WriteLine("释放技能");
        }
    }
    class Goblin : Monster
    {
        public void Atk()
        {
            Console.WriteLine("进行攻击");
        }
    }
    class Player
    {
        private Weapon nowHaveWeapon;
        public Player()
        {
            nowHaveWeapon = new Dagger();
        }
        public void PickUp(Weapon weapon)
        {
            nowHaveWeapon = weapon;
            Console.WriteLine(nowHaveWeapon);
        }
    }
    class Weapon
    {

    }
    class SubmachineGun : Weapon
    {
        
    }
    class ShotGun : Weapon
    {

    }
    class Pistol : Weapon
    {

    }
    class Dagger : Weapon
    {

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            Monster[] monsters = new Monster[10];
            int chance;
            for (int i = 0; i < monsters.Length; i++)
            {
                chance = r.Next(1, 3);
                if (chance == 1)
                {
                    monsters[i] = new Boss();
                }
                else
                {
                    monsters[i] = new Goblin();
                }
            }

            for (int i = 0;i < monsters.Length;i++)
            {
                if (monsters[i] is Boss)
                {
                    (monsters[i] as Boss).Skill();
                }
                else if (monsters[i] is Goblin)
                {
                    (monsters[i] as Goblin).Atk();
                }
            }
            SubmachineGun subGun = new SubmachineGun();
            Player p = new Player();
            p.PickUp(subGun);



        }
    }
}
