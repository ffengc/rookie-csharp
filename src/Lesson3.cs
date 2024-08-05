using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    public void Test8()
    {
        // 直接指定字符串
        string str1 = "abcd";
        Console.WriteLine(str1);
        // 使用 + 运算符
        string str2 = "abcd" + "efg";
        Console.WriteLine(str2);
        // 方法返回字符串
        string[] str_array = { "Hello ", "world" };
        string mesg = String.Join("", str_array);
        Console.WriteLine(mesg);
        // 用于转化值的格式化方法
        DateTime waiting = new DateTime(2012, 10, 10, 17, 58, 1);
        string str3 = String.Format("the time: {0:t} on {0:D}", waiting);
        Console.WriteLine(str3);
    }
    public void Test9()
    {
        // Compare
        string str1 = "abc";
        string str2 = "bb";
        Console.WriteLine(String.Compare(str1, str2)); // -1
        // Concat
        string str3 = "ccdd";
        Console.WriteLine(String.Concat(str1, str2, str3, str1, str2)); // abcbbccddabcbb
        // Contains
        str1 = "abcdefg";
        string sub_str1 = "bcd";
        string sub_str2 = "bb";
        Console.WriteLine(str1.Contains(sub_str1)); // True
        Console.WriteLine(str1.Contains(sub_str2)); // False
        // Copy
        string str4 = String.Copy(str1);
        Console.WriteLine(str4); // abcdefg
        // CopyTo
        char[] dest = new char[10];
        str4.CopyTo(1, dest, 0, 3); // copy "bcd" to dest
        Console.WriteLine(dest); // bcd\0\0\0... -> bcd
        // EndsWith
        string end = "efg";
        Console.WriteLine(str4.EndsWith(end)); // True
        // Equals / static Equals
        string str5 = "abc";
        string str6 = "abc";
        string str7 = "aBc";
        Console.WriteLine(str5.Equals(str6)); // True
        Console.WriteLine(str5.Equals(str7)); // False
        Console.WriteLine(String.Equals(str5, str6)); // True
    }
    public void Test10()
    {
        // Format
        string temp = "abc{0}{1}";
        string str1 = String.Format(temp, 1, 2);
        Console.WriteLine(str1); // abc12
        // IndexOf
        char ch = 'a';
        string str2 = "baba";
        Console.WriteLine(str2.IndexOf(ch)); // 1
        // IndexOf
        string sub1 = "ab";
        string sub2 = "abc";
        Console.WriteLine(str2.IndexOf(sub1)); // 1
        Console.WriteLine(str2.IndexOf(sub2)); // -1
        // IndexOfAny
        string str3 = "aaabbbcccddd";
        char[] ch_arr = { 'd', 'e', 'c' };
        Console.WriteLine(str3.IndexOfAny(ch_arr)); // 6
        // Insert
        temp = "eee";
        Console.WriteLine(str3.Insert(0, temp)); // eeeaaabbbcccddd
        // IsNullOrEmpty
        string str4 = new String("");
        string str5 = null;
        Console.WriteLine(String.IsNullOrEmpty(str4)); // True
        Console.WriteLine(String.IsNullOrEmpty(str5)); // True
        // Join
        string[] str_arr = { "aaa", "bbb", "ccc" };
        Console.WriteLine(String.Join("-", str_arr)); // aaa-bbb-ccc
    }
    public void PrintArray<type>(type[] arr)
    {
        foreach (type i in arr) Console.Write(i + " ");
        Console.WriteLine();
    }
    public void Test11()
    {
        // LastIndexOf
        string str1 = "abcdefea";
        Console.WriteLine(str1.LastIndexOf('a')); // 7
        // Remove
        string str2 = "abc****c";
        Console.WriteLine(str2.Remove(2)); // ab
        Console.WriteLine(str2.Remove(2, str2.Length - 1 - 2)); // abc
        // Replace
        string str3 = "aabaabcsda";
        Console.WriteLine(str3.Replace('a', 'A')); // AAbAAbcsdA
        Console.WriteLine(str3.Replace("ab", "AB")); // aABaABcsda
        // Split
        string str4 = "a*b*c^dd*cd^aa";
        PrintArray(str4.Split('*', '^')); // a b c dd cd aa
        // ToCharArray
        string str5 = "abcd";
        PrintArray(str5.ToCharArray()); // a b c d
        // Trim
        string str6 = "    aasdfa   ";
        Console.WriteLine(str6.Trim()); // aasdfa
    }
}