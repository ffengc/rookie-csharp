// See https://aka.ms/new-console-template for more information

using rookie_csharp.src;
using System;
namespace HelloWorldApplication
{
    class HelloWorld
    {
        static void Main(string[] args)
        {
            /* 我的第一个 C# 程序*/
            Console.WriteLine("Hello World");
            test_class tc1 = new test_class();
            Console.WriteLine(tc1.v);
            tc1.test_f();
        }
    }
}