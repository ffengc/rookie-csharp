using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;
using System.Globalization;
using System.Runtime.CompilerServices;

internal class Lesson5
{
    public void ShowList<T>(T container)
    {
        // 处理 IEnumerable<T> 类型的容器，如 List<T>, Stack<T>, Queue<T>
        if (container is IEnumerable enumerable)
        {
            foreach (var item in enumerable)
            {
                Console.Write(item + " ");
            }
        }
        // 处理 Dictionary<TKey, TValue> 类型的容器
        else if (container is IDictionary dictionary)
        {
            foreach (DictionaryEntry entry in dictionary)
            {
                Console.Write($"[{entry.Key}, {entry.Value}] ");
            }
        }
        else
        {
            Console.WriteLine("Unsupported container type.");
            return;
        }
        Console.WriteLine();
    }
    public void Test1()
    {
        // C# 的 List 相当于 std::vector
        // doc: https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.list-1?view=net-8.0
        List<int> lst = new List<int>(new int[] { 1, 3, 5, 7, 9 });
        ShowList(lst);
        var pos1 = lst.Find(x => x == 7); // List<T>中的Find方法用于查找满足条件的元素，但要传递一个谓词（predicate）来进行查找
        Console.WriteLine(pos1); // 这里直接是int类型了
        // LinkedList 相当于 std::list
        // doc: https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.linkedlist-1?view=net-8.0
        LinkedList<int> link_lst = new LinkedList<int>(new int[] { 1, 3, 5, 7, 9 });
        link_lst.AddLast(10);
        link_lst.AddFirst(-1);
        ShowList(link_lst);
        var pos2 = link_lst.Find(20); // 这里返回的是一个节点
        if (pos2 != null)
            Console.WriteLine(pos2.Value);
        else
            Console.WriteLine("cannot find");
        // size
        Console.WriteLine(link_lst.Count);
        Console.WriteLine(link_lst.First.Value); // first node
        Console.WriteLine(link_lst.Last.Value); // last node
    }
    public void Test2()
    {
        // Stack / C++ std::stack
        // doc: https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.stack-1?view=net-8.0
        Stack<int> st = new Stack<int>();
        st.Push(1);
        st.Push(2);
        st.Push(3);
        st.Push(4);
        while (st.Count > 0)
        {
            var num = st.First();
            st.Pop();
            Console.Write(num + " ");
        }
        Console.WriteLine();
        st.Clear();
        Console.WriteLine(st.Count);
        // Queue / C++ std::queue
        // doc: https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.queue-1?view=net-8.0
        Queue<int> q1 = new Queue<int>(new int[] { 1, 2, 3, 4, 5 });
        Queue<int> q2 = new Queue<int>(Enumerable.Range(1, 5));
        Console.WriteLine(q1 == q2); // false 比较的不是内容，而是两个队列的引用
        Console.WriteLine(q1.SequenceEqual(q2));
        q1.Clear();
        Console.WriteLine(q1.Count);
        // PriorityQueue / C++ std::priority_queue
        // PriorityQueue 的第二个类型参数应该是优先级
        // : 第一个数字是存储的数据来的，不参与排序，第二个数字是用来排序的数字
        // 不能直接批量初始化，但是可以手动写一个方法
        // 使用扩展方法简化初始化
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>().Initialize((1, 3), (2, 1), (3, 2));
        ShowList(pq); // error 不能迭代器访问
        while (pq.Count > 0)
        {
            int task = pq.Dequeue();
            Console.WriteLine(task);
        }
    }
    public void Test3()
    {
        // doc: https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.dictionary-2?view=net-8.0
        // Dictionary<k, v> --> hastable  / C++ std::unordered_map
        Dictionary<int, string> map1 = new Dictionary<int, string>();
        // Add(Tkey,TValue) 将指定的键和值添加到字典中
        map1.Add(1, "hello world");
        map1.TryAdd(1, "hello world, test"); // will return false
        map1.Add(2, "hello linux");
        ShowList(map1);
        Dictionary<int, string> map2 = new Dictionary<int, string>();
        map2.Add(1, "hello world1");
        map2.Add(2, "hello linux1");
        // Compare 属性 可以用来看key是如何比较的
        var comp = map1.Comparer;
        Console.WriteLine(comp.ToString());
        // Count属性
        Console.WriteLine(map1.Count);
        // []访问数据
        Console.WriteLine(map2[1]);
        // .Keys获取所有的键
        var res = map1.Keys;
        foreach (var key in res) Console.Write(key + " ");
        Console.WriteLine();
        // .Values获取所有的值
        var res2 = map1.Values;
        foreach (var v in res2) Console.Write(v + " ");
        Console.WriteLine();
        // Clear() 将所有键和值从 Dictionary<TKey,TValue> 中移除
        map2.Clear();
        Console.WriteLine(map2.Count);
        // ContainsKey(TKey) :确定是否 Dictionary<TKey,TValue> 包含指定键
        Console.WriteLine(map1.ContainsKey(1));
        Console.WriteLine(map1.ContainsKey(3));
        // ContainsValue(TValue) 确定 Dictionary<TKey, TValue> 是否包含特定值, 效率比较低，建议尽可能使用前一个方法
        // 找key可以O(1), 但是找值需要线性查找
        // Remove(TKey) 从 Dictionary<TKey, TValue> 中移除所指定的键的值
        // Remove(TKey, TValue) 从 Dictionary<TKey,TValue> 中删除具有指定键的值，并将元素复制到 value 参数
    }
    public void Test4()
    {
        // doc: https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.sorteddictionary-2?view=net-8.0
        // SortedDictionary<TKey,TValue> red-black tree / C++ std::map
        // 基本操作和 Dictionary<k, v> 相同
        SortedDictionary<int, int> map = new SortedDictionary<int, int> { { 1, 2 }, { 2, 3 }, { 3, 4 }, { -1, 2 } };
        ShowList(map);
    }
    public void Test5()
    {
        // doc: https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.sortedlist-2?view=net-8.0
        // SortedList<TKey,TValue> 底层是数组实现的，操作基本上和SortedDictionary/Dictionary相同
        SortedList<int, int> lst = new SortedList<int, int> { { 1, 2 }, { 2, 3 }, { 3, 4 }, { -1, 2 } };
        ShowList(lst);
    }
    public void Test6()
    {
        // doc: https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.hashset-1?view=net-8.0
        // HashSet / C++ std::unordered_set
        // 和Dictionary操作类似
        HashSet<int> s = new HashSet<int>(new int[] { 1, 3, 5, 7, 9, 2, 4, 6 });
        ShowList(s);
        // 提供了数学集运算
        HashSet<int> s2 = new HashSet<int>(new int[] { -1, 1, -2, 2 });
        // Union
        var res = s2.Union(s);
        foreach (int i in res) { Console.Write(i + " "); }
        Console.WriteLine();
        // IntersectWith
        res = s2.Intersect(s);
        foreach (int i in res) { Console.Write(i + " "); }
        Console.WriteLine();
        // ExceptWith
        s2.ExceptWith(s);
        ShowList(s2);
        // SymmetricExceptWith
        s2.SymmetricExceptWith(s);
        ShowList(s2);
    }
    public void Test7()
    {
        // doc: https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.sortedset-1?view=net-8.0
        // SortedSet / C++ std::set
        SortedSet<int> s = new SortedSet<int>(new int[] { 1, 3, 5, 7, 9, 2, 4, 6 });
        ShowList(s); // sorted result
    }
}
public static class PriorityQueueExtensions
{
    public static PriorityQueue<TElement, TPriority> Initialize<TElement, TPriority>(
        this PriorityQueue<TElement, TPriority> pq,
        params (TElement element, TPriority priority)[] items) // 第一个参数是this指针
    {
        foreach (var item in items)
            pq.Enqueue(item.element, item.priority);
        return pq;
    }
}