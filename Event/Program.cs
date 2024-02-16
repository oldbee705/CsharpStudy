namespace Event
{
    class Heater
    {
        public int value;
        public event Action<int> BoilDoSomething;

        public void Heat()
        {
            int updateIndex = 0;
            int count = 2;
            while(true)
            {
                if(updateIndex % 10000000 == 0)
                {
                    ++value;
                    Console.WriteLine("当前水温为{0}", value);
                    if (value == 100 && count == 1)
                    {
                        BoilDoSomething(value);
                        count--;
                        BoilDoSomething = null;
                        break;
                    }
                    if (value >= 95)
                    {
                        if (BoilDoSomething != null && count == 2)
                        {
                            BoilDoSomething(value);
                            count--;
                        }
                    }
                    updateIndex = 0;
                }
                updateIndex++;
            }
            
        }
    }

    class Alarm
    {
        public void ShowInfo(int value)
        {
            Console.WriteLine("语音：当前水温为{0}", value);
        }
    }

    class Display
    {
        public void ShowInfo(int value)
        {
            Console.WriteLine("当前水温为{0},水开了", value);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Heater heater = new Heater();
            Display display = new Display();
            Alarm alarm = new Alarm();
            heater.BoilDoSomething += alarm.ShowInfo;
            heater.BoilDoSomething += display.ShowInfo;

            heater.Heat();
        }
    }
}
