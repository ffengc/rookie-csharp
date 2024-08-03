using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Lesson1
{
    internal class Circle {
        public int __r;
        public int __x;
        public int __y;
        public Circle() { }
        public Circle(int r, int x, int y)
        {
            this.__r = r;
            __x = x;
            __y = y;
        }
        public Circle(Circle c) {
            __r = c.__r;
            __x = c.__x;
            __y = c.__y;
        }
        public double Area() { return 3.14 * __r * __r; }
        public void ShowFields() {
            Console.WriteLine("r: {0}, x: {1}, y: {2}", __r, __x, __y);
        }
    }
    internal class DataType {
        public bool bool_data;
        public byte byte_data;
        public char char_data;
        public decimal decimal_data;
        public double double_data;
        public float float_data;
        public int int_data;
        public long long_data;
        public sbyte sbyte_data;
        public short short_data;
        public uint uint_data;
        public ulong ulong_data;
        public ushort ushort_data;
    }
    internal void Test1()
    {
        // print an hello world
        Console.WriteLine("hello world");
        Console.ReadKey();
    }
    internal void Test2() {
        Circle cir = new Circle();
        cir.ShowFields();
        Circle cir2 = new Circle(1, 2, 3);
        cir2.ShowFields();
        Console.WriteLine("Area: {0}", cir2.Area());
    }
    internal void Test3()
    {
        // 数据类型
        DataType dt = new DataType();
        Console.WriteLine("bool type, default: {0}, type size: {1}", dt.bool_data, sizeof(bool));
        Console.WriteLine("byte type, default: {0}, type size: {1}", dt.byte_data, sizeof(byte));
        Console.WriteLine("char type, default: {0}, type size: {1}", dt.char_data, sizeof(char));
        Console.WriteLine("decimal type, default: {0}, type size: {1}", dt.decimal_data, sizeof(decimal));
        Console.WriteLine("double type, default: {0}, type size: {1}", dt.double_data, sizeof(double));
        Console.WriteLine("float type, default: {0}, type size: {1}", dt.float_data, sizeof(float));
        Console.WriteLine("int type, default: {0}, type size: {1}", dt.int_data, sizeof(int));
        Console.WriteLine("long type, default: {0}, type size: {1}", dt.long_data, sizeof(long));
        Console.WriteLine("sbyte type, default: {0}, type size: {1}", dt.sbyte_data, sizeof(sbyte));
        Console.WriteLine("short type, default: {0}, type size: {1}", dt.short_data, sizeof(short));
        Console.WriteLine("uint type, default: {0}, type size: {1}", dt.uint_data, sizeof(uint));
        Console.WriteLine("ulong type, default: {0}, type size: {1}", dt.ulong_data, sizeof(ulong));
        Console.WriteLine("ushort type, default: {0}, type size: {1}", dt.ushort_data, sizeof(ushort));
    }
    internal void Test4()
    {
        int a = 10;
        int b = a;
        Console.WriteLine("a: {0}, b:{1}", a, b);
        b = 20;
        Console.WriteLine("a: {0}, b:{1}", a, b);
        Circle c1 = new Circle(1, 1, 1);
        // Circle c2 = c1; // 就算有拷贝构造，这个也是浅拷贝，不同于C++
        Circle c2 = new Circle(c1); // deepcopy
        c1.ShowFields();
        c2.ShowFields();
        c2.__x = 20;
        c1.ShowFields();
        c2.ShowFields();
    }
    internal void Test5()
    {
        String str = "abcdefg";
        String str2 = str;
        // Console.WriteLine("str addr: {0}, {1}", &str, &str2); // error
        /**
         C#是高级的安全语言，不能访问地址，如果要判断是不是同一个引用，可以用 Object.ReferenceEquals
         */
        Console.WriteLine(Object.ReferenceEquals(str, str2));
        //str2[0] = 'a'; // only read
        StringBuilder mutable_str = new StringBuilder("abcdefgh");
        StringBuilder mutable_str2 = new StringBuilder(mutable_str.ToString()); // deepcopy
        // StringBuilder mutable_str2 = mutable_str; // reference
        mutable_str2[0] = '*';
        Console.WriteLine(mutable_str.ToString());
        Console.WriteLine(mutable_str2.ToString());
    }
}