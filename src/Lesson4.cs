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
}
