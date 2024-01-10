using System.Numerics;

namespace 接口
{
    interface IInput
    {
        void Input();
    }
    interface IOutput
    {
        void Output(string content);
    }
    interface IUSB : IInput, IOutput
    {

    }
    class Device
    {
        public Computer linkComputer;
        public string content;
    }
    class OutputDevice : Device
    {
        public void Play()
        {
            Console.WriteLine("播放{0}", content);
        }
    }
    class StorageDevice : Device
    {
        public void ReadData()
        {
            Console.WriteLine(content);
        }
    }
    class Computer : IUSB
    {
        public Device linkDevice;
        public string content;
        public void Link(Device d)
        {
            d.linkComputer = this;
            linkDevice = d;
        }
        public void Input()
        {
            content = linkDevice.content;
        }

        public void Output(string content)
        {
            linkDevice.content = content;
        }

        public void PrintContent()
        {
            Console.WriteLine(content);
        }
    }
    interface IFly
    {
        void Fly();
    }
    interface IWalk
    {
        void Walk();
    }
    interface ISwim
    {
        void Swim();
    }
    interface IRegister
    {
        void Register();
    }
    class Person : IRegister
    {
        public void Register()
        {
            Console.WriteLine("派出所登记");
        }
    }
    class House : IRegister
    {
        public void Register()
        {
            Console.WriteLine("房管局登记");
        }
    }
    class Car : IRegister
    {
        public void Register()
        {
            Console.WriteLine("车管所登记");
        }
    }
    abstract class Bird : IWalk
    {
        public abstract void Walk();
    }
    class WalkBird() : Bird
    {
        public override void Walk()
        {
            Console.WriteLine("走路");
        }
    }
    class FlyBird : Bird, IFly
    {
        public void Fly()
        {
            Console.WriteLine("飞");
        }

        public override void Walk()
        {
            Console.WriteLine("走路");
        }
    }
    class SwimBird : Bird, ISwim
    {
        public void Swim()
        {
            Console.WriteLine("游泳");
        }

        public override void Walk()
        {
            Console.WriteLine("走路");
        }
    }
    class FlySwimBird : Bird, IFly, ISwim
    {
        public void Fly()
        {
            Console.WriteLine("飞");
        }

        public void Swim()
        {
            Console.WriteLine("游泳");
        }

        public override void Walk()
        {
            Console.WriteLine("走路");
        }
    }
    class Plane : IFly
    {
        public void Fly()
        {
            Console.WriteLine("飞");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IRegister[] arr = { new Person(), new Car(), new House() };
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].Register();
            }

            FlyBird 麻雀 = new FlyBird();
            麻雀.Walk();
            麻雀.Fly();

            Bird 鸵鸟 = new WalkBird();
            鸵鸟.Walk();

            SwimBird 企鹅 = new SwimBird();
            企鹅.Walk();
            企鹅.Swim();

            FlyBird 鹦鹉 = new FlyBird();
            鹦鹉.Walk();
            鹦鹉.Fly();

            Plane 直升机 = new Plane();
            直升机.Fly();

            FlySwimBird 天鹅 = new FlySwimBird();
            天鹅.Walk();
            天鹅.Fly();
            天鹅.Swim();

            Computer 电脑 = new Computer();
            StorageDevice 移动硬盘 = new StorageDevice();
            StorageDevice U盘 = new StorageDevice();
            OutputDevice MP3 = new OutputDevice();
            移动硬盘.content = "123123";
            电脑.Link(移动硬盘);
            电脑.Input();
            电脑.PrintContent();
            电脑.Output("8567");
            电脑.Input();
            电脑.PrintContent();

            U盘.content = "bbbbb";
            电脑.Link(U盘);
            电脑.Input();
            电脑.PrintContent();
            电脑.Output("asdasd");
            电脑.Input();
            电脑.PrintContent();

            MP3.content = "牛";
            MP3.Play();
            电脑.Link(MP3);
            电脑.Input();
            电脑.PrintContent();
            电脑.Output("马");
            MP3.Play();
            电脑.Input();
            电脑.PrintContent();
        }
    }

}
