using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Lesson3
{
    public void Test1()
    {
        int[] arr1 = { 1, 2, 3, 4 };
        int[] arr2 = new int[3];
        int[] arr3 = new int[3] { 1, 3, 5 };
        arr1[0] = 10;
        foreach (int i in arr1) Console.Write(i + " ");
        Console.WriteLine();
        foreach (int i in arr2) Console.Write(i + " ");
        Console.WriteLine();
        foreach (int i in arr3) Console.Write(i + " ");
        Console.WriteLine();
    }
    public void Test2()
    {
        string[,] arr = { { "aaa", "bbb" }, { "ccc", "ddd" } };
        foreach (var subarr in arr) foreach (var i in subarr) Console.Write(i + " ");
        Console.WriteLine();
        /** 可以发现第一层 foreach之后已经可以拿到所有的数据了，不用第二层循环 */
        foreach (var i in arr) Console.Write(i + " ");
        Console.WriteLine();
        /** 分层打印 */
        for (int i = 0; i < arr.GetLength(0); ++i)
        {
            for (int j = 0; j < arr.GetLength(1); ++j)
            {
                Console.Write(arr[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    public void Test3()
    {
        int[][] arr = { new int[] { 1, 2, 3 }, new int[] { 2, 3 } };
        foreach (var subarr in arr)
        {
            foreach (int i in subarr) Console.Write(i + " ");
            Console.WriteLine();
        }
    }
    public void PrintArray(int[] arr)
    {
        foreach (var i in arr) Console.Write(i + " ");
        Console.WriteLine();
        //for (int i = 0; i < arr.Length; i++) Console.Write(arr[i] + " ");
        //Console.WriteLine();
    }
    public void Test4()
    {
        int[] arr = { 1, 2, 3, 4 };
        PrintArray(arr);
    }
    public void ShowAllParam(string str, params int[] arr)
    {
        Console.WriteLine(str);
        foreach (var i in arr) Console.Write(i + " ");
        Console.WriteLine();
    }
    public void Test5()
    {
        ShowAllParam("hello world", 1, 2, 3, 4, 5);
    }
    public void Test6()
    {
        int[] arr = { 1, 3, 5, 7, 9, 2, 4, 6, 8, 10 };
        PrintArray(arr);
        Array.Sort(arr, (x, y)=> y.CompareTo(x));
        PrintArray(arr);
    }
    public void Test7()
    {
        int[] arr = { 1, 3, 5, 7, -9, -2, 4, 6, 8, 10 };
        //Array.Sort(arr, (x, y)=> MyCompare(x, y));
        Array.Sort(arr, new MyComparetor());
        PrintArray(arr);
    }
    public int MyCompare(int x, int y)
    {
        if (x == y) return 0;
        else if (x > y) return 1;
        else return -1;
    }
    public class MyComparetor : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }
}
