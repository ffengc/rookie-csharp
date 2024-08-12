using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static SortMethods;

internal class RandomArrayGenerator
{
    public static int[] GenerateRandomIntArray(int length, int min, int max)
    {
        Random random = new Random();
        int[] array = new int[length];
        for (int i = 0; i < length; i++)
            array[i] = random.Next(min, max);
        return array;
    }
}
internal class Utils
{
    public static void ShowList<T>(T container)
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
    public static void Swap<T>(ref T lhs, ref T rhs)
    {
        T temp;
        temp = lhs;
        lhs = rhs;
        rhs = temp;
    }
}
internal class SortMethods
{
    public static void BubbleSort(int[] arr)
    {
        int sz = arr.Length;
        for (int i = 0; i < sz - 1; i++)
            for (int j = 0; j < sz - 1 - i; j++)
                if (arr[j] > arr[j + 1])
                    Utils.Swap(ref arr[j], ref arr[j + 1]);
    }
    public static void SelectSort(int[] arr)
    {
        int sz = arr.Length;
        for (int i = 0; i < sz - 1; i++) 
        {
            int min_idx = i;
            for(int j = i+ 1; j < sz; j++)
                if (arr[j] < arr[min_idx])
                    min_idx = j;
            Utils.Swap(ref arr[i], ref arr[min_idx]);
        }
    }
    public static void InsertSort(int[] arr)
    {
        int sz = arr.Length;
        int sort_num = 0;
        for (int i = 0; i < sz; i++)
        {
            int j;
            sort_num = arr[i]; // the number need to be sort
            for(j =i - 1; j>= 0; j--)
            {
                if (arr[j] < sort_num) break;
                arr[j + 1] = arr[j];
            }
            arr[j + 1] = sort_num;
        }
    }
    private static void ShellSortInGroup(int[] arr, int pos, int step)
    {
        // pos+step is the idx of the first element in this group
        // and sort this group with insert_sort, same with insert sort
        int sort_num = 0;
        int i = 0, j = 0;
        int sz = arr.Length;
        for (i = pos + step; i < sz; i += step)
        {
            sort_num = arr[i];
            for (j = i - step; j >= 0; j -= step)
            {
                if (arr[j] < sort_num) break;
                arr[j + step] = arr[j];
            }
            arr[j + step] = sort_num;
        }
    }
    public static void ShellSort(int[] arr)
    {
        int i = 0;
        int step = 0;
        int sz = arr.Length;
        // step is the step length, each time it is reduced to half of the original value,
        // take an integer, the last one must be 1
        for (step = sz / 2; step > 0; step /= 2) 
            for (i = 0; i < step; i++)
                ShellSortInGroup(arr, i, step);
    }
    private static int QuickSortPartSort(int[] arr, int begin, int end)
    {
        int left = begin;
        int right = end;
        int keyi = left;
        while (left < right) 
        {
            // right move first, find smaller
            while (left < right && arr[right] >= arr[keyi]) --right;
            // left move, find bigger
            while (left < right && arr[left] <= arr[keyi]) ++left;
            Utils.Swap(ref arr[left], ref arr[right]);
        }
        Utils.Swap(ref arr[keyi], ref arr[right]);
        keyi = left;
        return keyi;
    }
    private static void QuickSortByRange(int[] arr, int begin, int end)
    {
        // The interval does not exist or has only one value and does not need to be processed anymore
        // Quick sort: Get the key right each time, and recursively solve the numbers on both sides of the key
        if (begin >= end) return;
        int keyi = QuickSortPartSort(arr, begin, end);
        QuickSortByRange(arr, begin, keyi - 1);
        QuickSortByRange(arr, keyi + 1, end);
    }
    public static void QuickSort(int[] arr)
    {
        int begin = 0; int end = arr.Length - 1;
        QuickSortByRange(arr, begin, end);
    }
    private static void MergeSortByRange(int[] arr, int[] temp, int start, int end)
    {
        Debug.Assert(arr.Length == temp.Length, "arr.Length should equal to temp.Length");
        if (start >= end) return;
        int mid = start + (end - start) / 2; // find the mid idx of the array
        // cut the array into to parts
        int istart1 = start;
        int iend1 = mid;
        int istart2 = mid + 1;
        int iend2 = end;
        // both part call the range sort
        MergeSortByRange(arr, temp, istart1, iend1);
        MergeSortByRange(arr, temp, istart2, iend2);
        // merge 2 parts
        int i = start;
        while (istart1 <= iend1 && istart2 <= iend2)
        {
            temp[i] = arr[istart1] < arr[istart2] ? arr[istart1++] : arr[istart2++];
            ++i;
        }
        while (istart1 <= iend1)
        {
            temp[i] = arr[istart1];
            i++;
            istart1++;
        }
        while (istart2 <= iend2)
        {
            temp[i] = arr[istart2];
            i++;
            istart2++;
        }
        Array.Copy(temp, start, arr, start, end - start + 1);
    }
    public static void MergeSort(int[] arr)
    {
        if (arr.Length < 2) return;
        int[] temp = new int[arr.Length];
        MergeSortByRange(arr, temp, 0, arr.Length - 1);
    }
    private static void HeapSortAdjustDown(int[] arr, int begin, int end)
    {
        int parent = begin;
        int child = parent * 2 + 1;
        while(child <= end)
        {
            if ((child + 1 <= end) && (arr[child] < arr[child + 1])) child++;
            if (arr[parent] > arr[child]) return;
            Utils.Swap(ref arr[parent], ref arr[child]);
            parent = child;
            child = parent * 2 + 1;
        }
    }
    public static void HeapSort(int[] arr)
    {
        int i = 0;
        // make_heap
        for (i = (arr.Length - 1) / 2; i >= 0; i--)
            HeapSortAdjustDown(arr, i, arr.Length - 1);
        // swap first element and the last element
        for (i = arr.Length - 1; i > 0; i--)
        {
            Utils.Swap(ref arr[0], ref arr[i]);
            HeapSortAdjustDown(arr, 0, i - 1);
        }
    }
    internal class RadixSort
    {
        private static int K = -1; // Up to three digits
        private const int RADIX = 10; // ten radixes
        private static Queue<int>[] Q = Enumerable.Range(0, RADIX).Select(_ => new Queue<int>()).ToArray(); // array of queue
        private static int GetKey(int val, int k)
        {
            int key = 0;
            while (k >= 0) 
            {
                key = val % 10;
                val /= 10;
                k--;
            }
            return key;
        }
        private static void Distribute(int[] arr, int left, int right, int k)
        {
            for(int i = left; i < right; i++)
            {
                int key = GetKey(arr[i], k);
                Q[key].Enqueue(arr[i]);
            }
        }
        private static void Collect(int[] arr)
        {
            /* No need to distinguish the order, just recycle the data into the array
            Check all queues, because we don't know which queues have data and which don't */
            int k = 0;
            for(int i = 0; i < RADIX; ++i)
                while (Q[i].Count > 0)
                    arr[k++] = Q[i].Dequeue();
        }
        private static void SortByRange(int[] arr, int left, int right)
        {
            Debug.Assert(K > 0, "need to init the K in Sort()");
            for (int i = 0; i < K; ++i)
            {
                // How many digits are there and how many times are they repeated
                // distribute the data
                Distribute(arr, left, right, i); // i represents the digit I am currently operating on
                // collect the data
                Collect(arr);
            }
        }
        private static bool CheckSequenceValidity(int[] arr)
        {
            /* Radix sorting can generally only process non - negative numbers,
                otherwise special preprocessing is required */
            foreach (int number in arr)
                if (number < 0)
                    return false;
            return true;
        }
        public static void Sort(int[] arr, int InputK)
        {
            K = InputK;
            int left = 0; int right = arr.Length;
            Debug.Assert(CheckSequenceValidity(arr));
            SortByRange(arr, left, right);
        }
    }
    public static void Run()
    {
        //int[] arr = new int[] { 1, 3, 5, 7, 9, 2, 4, 6, 8, 10, 12 };
        int len = 10;
        int max = 100;
        int min = 0;
        int[] arr = RandomArrayGenerator.GenerateRandomIntArray(len, min, max);
        int[] sorted_arr = (int[])arr.Clone();
        Array.Sort(sorted_arr);
        RadixSort.Sort(arr, 3); // 3 refs to the max digits number of the seq
        if (len <= 30)
        {
            Console.Write("My Sort:    "); Utils.ShowList(arr);
            Console.Write("Array.Sort: "); Utils.ShowList(sorted_arr);
        }
        Console.WriteLine(arr.SequenceEqual(sorted_arr));
    }
}
internal class PerformanceTest
{
    public static void RunPerformanceTests(int numberOfTests)
    {
        int len = 10000; // 可以根据需要调整数组的大小
        int max = 100000;
        int min = 0;
        Random rnd = new Random();
        // Create an initial array and copy it for different sorting methods
        int[] originalArray = Enumerable.Range(0, len).Select(x => rnd.Next(min, max)).ToArray();
        Stopwatch sw = new Stopwatch();
        Console.WriteLine("Running performance tests...");
        // Used to store the total time for each sort
        double[] times = new double[8]; // Corresponding to 8 sorting methods
        for (int test = 0; test < numberOfTests; test++)
        {
            int[] tempArray;
            // Bubble Sort
            tempArray = (int[])originalArray.Clone();
            sw.Restart();
            BubbleSort(tempArray);
            sw.Stop();
            times[0] += sw.Elapsed.TotalMilliseconds;
            // Select Sort
            tempArray = (int[])originalArray.Clone();
            sw.Restart();
            SelectSort(tempArray);
            sw.Stop();
            times[1] += sw.Elapsed.TotalMilliseconds;
            // Insert Sort
            tempArray = (int[])originalArray.Clone();
            sw.Restart();
            InsertSort(tempArray);
            sw.Stop();
            times[2] += sw.Elapsed.TotalMilliseconds;
            // Shell Sort
            tempArray = (int[])originalArray.Clone();
            sw.Restart();
            ShellSort(tempArray);
            sw.Stop();
            times[3] += sw.Elapsed.TotalMilliseconds;
            // Quick Sort
            tempArray = (int[])originalArray.Clone();
            sw.Restart();
            QuickSort(tempArray);
            sw.Stop();
            times[4] += sw.Elapsed.TotalMilliseconds;
            // Merge Sort
            tempArray = (int[])originalArray.Clone();
            sw.Restart();
            MergeSort(tempArray);
            sw.Stop();
            times[5] += sw.Elapsed.TotalMilliseconds;
            // Heap Sort
            tempArray = (int[])originalArray.Clone();
            sw.Restart();
            HeapSort(tempArray);
            sw.Stop();
            times[6] += sw.Elapsed.TotalMilliseconds;
            // Radix Sort
            tempArray = (int[])originalArray.Clone();
            sw.Restart();
            RadixSort.Sort(tempArray, 6); // Assuming 6 digits max for simplicity
            sw.Stop();
            times[7] += sw.Elapsed.TotalMilliseconds;
        }
        // print avg time
        string[] sortNames = { "Bubble Sort", "Select Sort", "Insert Sort", "Shell Sort", "Quick Sort", "Merge Sort", "Heap Sort", "Radix Sort" };
        Console.WriteLine($"Average times for {numberOfTests} tests:");
        for (int i = 0; i < times.Length; i++)
        {
            Console.WriteLine($"{sortNames[i],-12}: {times[i] / numberOfTests} ms");
        }
    }
}