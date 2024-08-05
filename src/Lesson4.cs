using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Lesson4
{
    internal struct MyDate
    {
        public int year;
        public int month;
        public int day;
        public MyDate(int y, int m, int d) { year = y; month = m; day = d; }
        public void ShowDate() { Console.WriteLine($"{year}:{month}:{day}"); }
    }
    public void Test1()
    {
        MyDate d1 = new MyDate(12, 2, 3);
        d1.ShowDate();
    }
    class MyClass
    {
        public const int a = 10;
        public static int b = 20;
    }
    public void Test2()
    {
        Console.WriteLine(MyClass.a); // 10
        Console.WriteLine(MyClass.b++); // 20
        Console.WriteLine(MyClass.b); // 21
    }
    public class BaseShape { public virtual void Print() { Console.WriteLine("Base Shape"); } }
    public class Circle : BaseShape { public override void Print() { Console.WriteLine("Circle"); } }
    public class Rect : BaseShape { public override void Print() { Console.WriteLine("Rect"); } }
    public void PrintShapeType(BaseShape bs) { bs.Print(); }
    public void Test3()
    {
        BaseShape bs = new BaseShape();
        Circle c = new Circle();
        Rect r = new Rect();
        // 这里就会调用不同的重写函数
        PrintShapeType(bs);
        PrintShapeType(c);
        PrintShapeType(r);
    }
    public class Pair
    {
        public int x;
        public int y;
        public Pair(int a, int b) { x = a; y = b; }
        public static Pair operator+(Pair p1, Pair p2)
        {
            return new Pair(p2.x + p1.x, p2.y + p1.y);
        }
        // 重写 ToString 方法 才能支持 Console.WriteLine() 的输出
        public override string ToString()
        {
            return $"Pair(x: {x}, y: {y})";
        }
    }
    public void Test4()
    {
        Pair p1 = new Pair(1, 2);
        Pair p2 = new Pair(2, 3);
        Console.WriteLine(p1);
        Console.WriteLine(p1 + p2);
    }
}
