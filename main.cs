// See https://aka.ms/new-console-template for more information

#if false
Console.WriteLine("top level statement");
int a = 10;
var b = 20;
Console.WriteLine("a: {0}, b:{1}, a+b:{2}", a, b, a + b);
SayHello.Say(); // static方法用类名调用
class SayHello
{
    public static void Say() { Console.WriteLine("hello"); }
}
#endif

// program entry

namespace rookie_csharp
{
    class Run
    {
        static void Main(string[] args)
        {
            Lesson2 t = new Lesson2();
            t.Test7();
        }
    }
}