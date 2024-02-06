using System.Collections;
using System.Collections.Immutable;

namespace ArrayList动态数组
{
    class Bag
    {
        public float money;
        public ArrayList items;

        public Bag()
        {
            items = new ArrayList();
            this.money = 100;
        }

        public void Buy(Item item)
        {
            if (money >= item.value)
            {
                items.Add(item);
                money -= item.value;
                Console.WriteLine("消费了{0}元,还剩{1}元", item.value, money);
            }
            else
            {
                Console.WriteLine("余额不足");
            }
        }
        public void Sell(Item item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
                money += item.value;
                Console.WriteLine("卖出了{0},余额为{1}", item.name, money);
            }
            else
            {
                Console.WriteLine("背包中不存在这件物品");
            }
        }
        public void Sell(string name)
        {
            for(int i = 0; i < items.Count; i++)
            {
                if((items[i] as Item).name == name)
                {
                    Sell((items[i] as Item));
                }
            }
        }
        public void ShowItem(Item item)
        {
            if (items.Contains(item))
            {
                Console.WriteLine("物品名称为:{0},物品价格为:{1}", item.name, item.value);
            }
            else
            {
                Console.WriteLine("背包中不存在这件物品");
            }
        }

        public void ShowAllItem()
        {
            for (int i = 0; i < items.Count; i++)
            {
                ShowItem(items[i] as Item);
            }
            
        }
    }

    class Item
    {
        public float value;
        public string name;

        public Item(float value, string name)
        {
            this.value = value;
            this.name = name;
        }
    }
    //ArrayList封装了部分方法，如增删改查，而且可以存储任何类型的数据
    internal class Program
    {
        static void Main(string[] args)
        {
            Bag bag = new Bag();
            Item item1 = new Item(20, "猪肉");
            Item item2 = new Item(10, "石头");
            Item item3 = new Item(50, "黄金");
            bag.Buy(item1);
            bag.Buy(item2);
            bag.Buy(item3);
            bag.Sell(item1);
            bag.Sell("石头");
            bag.Buy(item3);

            bag.ShowAllItem();
        }
    }
}
