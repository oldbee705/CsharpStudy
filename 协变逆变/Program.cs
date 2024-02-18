namespace 协变逆变
{
    //协变：
    //和谐的变化，自然的变化
    //因为 里氏替换原则 父类可以装子类
    //所以 子类变父类  
    //比如 string 变成 object 
    //感受是和谐的

    //逆变：
    //逆常规的变化，不正常的变化
    //因为 里氏替换原则 父类可以装子类 但是子类不能装父类
    //所以 父类变子类  
    //比如 object 变成 string
    //感受是不和谐的

    //协变和逆变是用来修饰泛型的
    //协变：out 
    //逆变：in
    //用于在泛型中 修饰 泛型字母的 
    //只有泛型接口和泛型委托能使用
    delegate void TestIn<in T>(T t);
    delegate T TestOut<out T>();
    class Father
    {

    }
    class Son : Father
    {

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            TestIn<Father> iF = (value) =>
            {

            };
            TestIn<Son> iS = iF;
            iS(new Son());

            TestOut<Son> oS = () =>
            {
                return new Son();
            };
            
            TestOut<Father> oF = oS;
            Father f = oF();
        }
    }
}
