using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Lesson2
{
    internal class MyNumber
    {
        public int Value;
        public MyNumber(int value)
        {
            Value = value;
        }
        public static implicit operator int(MyNumber mn)
        {
            return mn.Value;
        }
        public static explicit operator MyNumber(int n)
        {
            return new MyNumber(n);
        }
    }
    internal class TestConst {
        public const int v1 = 1;
        public int v2 = 2;
    }
    public void Test1()
    {
        // 使用 Convert 的静态方法
        string str = "123";
        int num = Convert.ToInt32(str);
        Console.WriteLine(num);
        // 使用 Parse 方法
        string str2 = "123.12";
        double d = double.Parse(str2);
        Console.WriteLine(d);
        // 使用 TryParse 方法
        string str3 = "123.12";
        double d2;
        bool if_success = double.TryParse(str3, out d2);
        if (if_success)
        {
            Console.WriteLine("success: {0}", d2);
        } else
        {
            Console.WriteLine("failed: {0}", d2);
        }
    }
    public void Test2()
    {
        MyNumber mn = new MyNumber(1);
        int n = mn;
        MyNumber nm2 = (MyNumber)(n + 1);
        Console.WriteLine(nm2);
    }
    public void Test3()
    {
        int n = 0;
        n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(n);
    }
    public void Test4()
    {
        TestConst tc = new TestConst();
        Console.WriteLine("const int v1: {0}", TestConst.v1);
        Console.WriteLine("int v2 = {0}", tc.v2);
    }
    public void Test5()
    {
        int[] arr = new int[] { 1, 2, 3, 4, 5 };
        Console.WriteLine(arr);
        foreach (var e in arr) Console.WriteLine(e);
    }
    public int Factorial(int input)
    {
        if (input == 0) return 0;
        if (input == 1) return 1;
        return input * Factorial(input - 1);
    }
    public void Test6()
    {
        int input = 6;
        Console.WriteLine(Factorial(input));
    }
    public void Func(int a, ref int b, out int c) {
        int aa = a;
        int bb = b;
        c = b;
    }
    public void Test7()
    {
        int a = 10, b = 10, c;
        Func(a, ref b, out c);
    }
    public void Test8()
    {
        int? a = null;
        int? b = 10;
        int? c = new int();
        int? d = new int?();
        Console.WriteLine("{0}, {1}, {2}, {3}", a, b, c, d);
    }
    public void Test9()
    {
        int? a = null;
        int res1 = a ?? -1;
        a = 10;
        int res2 = a ?? -1;
        Console.WriteLine("{0}, {1}", res1, res2);
    }
}