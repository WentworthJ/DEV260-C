using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace Week2Foundations
{
    class Program
    {

        static void Main()
        {
            //Console.WriteLine("Program reaches Main");
            ArraysDemo();
            ListDemo();
            StackDemo();
            QueueDemo();
            DictionaryDemo();
            HashSetDemo();
            PerformanceComparison();

        }


        // A
        static void ArraysDemo()
        {
            Console.WriteLine("Part A: Array");
            // Create array
            int[] arr = new int[10];


            arr[1] = 2;
            arr[2] = 9;
            arr[9] = 14;

            // Print at index slot 2
            Console.WriteLine("Value at index 2: " + arr[2]);

            // search
            int successValue = 9;
            bool success = false;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == successValue)
                {
                    success = true;
                    i = arr.Length;
                }
            }

            if (success == true)
            {
                Console.WriteLine("The number '" + (successValue) + "' was found in the array.");
            }
            else
            {
                Console.WriteLine("The number '" + (successValue) + "' was not found in the array.");
            }
        }

        // B
        static void ListDemo()
        {
            Console.WriteLine("Part B: List");
            // Make List

            List<int> list1 = new List<int> { 1, 2, 3, 4, 5 };

            // Modify list

            list1.Insert(2, 99);

            list1.Remove(99);

            Console.WriteLine("Final Count: " + list1.Count);

        }

        //C

        static void StackDemo()
        {
            Console.WriteLine("Part C: Stack");
            // make Stack

            Stack<string> navHistory = new Stack<string>();

            // Push URLs
            navHistory.Push("https://url.com/main");
            navHistory.Push("https://url.com/page1");
            navHistory.Push("https://url.com/page2");


            Console.WriteLine("Peeking at current page: " + navHistory.Peek());

            // go back through history
            Console.WriteLine();
            Console.WriteLine("Going back through navigation history:");

            while (navHistory.Count > 0)
            {
                string page = navHistory.Pop();
                Console.WriteLine("Visited: " + page);
            }

        }

        //D

        static void QueueDemo()
        {
            // Create Queue
            Queue<string> printQueue = new Queue<string>();

            // Enqueue
            printQueue.Enqueue("Print Job 1");
            printQueue.Enqueue("Print Job 2");
            printQueue.Enqueue("Print Job 3");


            Console.WriteLine("Peeking at next job: " + printQueue.Peek());

            Console.WriteLine("\nProcessing print jobs:");

            while (printQueue.Count > 0)
            {
                string job = printQueue.Dequeue();
                Console.WriteLine("Processed: " + job);
            }

        }

        //E

        static void DictionaryDemo()
        {
            // Create dictionary
            Dictionary<string, int> inventory = new Dictionary<string, int>();

            // Fill dictionary
            inventory["SKU111"] = 10;
            inventory["SKU222"] = 5;
            inventory["SKU333"] = 20;

            // Update second value
            inventory["SKU222"] = 8;


            if (inventory.TryGetValue("missing", out int missingValue))
            {
                Console.WriteLine($"Found 'missing': " + missingValue);
            }
            else
            {
                Console.WriteLine("'missing' key not found.");
            }
        }

        static void HashSetDemo()
        {
            // Create Hashset
            HashSet<int> numbers = new HashSet<int>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(2); // Duplicate


            bool added = numbers.Add(1); // Duplicate
            Console.WriteLine("Adding another 1 returns: " + added); // should be false

            numbers.UnionWith(new[] { 3, 4, 5 });

            Console.WriteLine("Final Count: " + numbers.Count);

        }
        

        


                        #region PerformanceComparison

                static void PerformanceComparison()
                {
                    int[] testSizes = { 1000, 10000, 100000 };

                    foreach (int N in testSizes)
                    {
                        // Prepare data
                        List<int> list = new List<int>();
                        HashSet<int> hashSet = new HashSet<int>();
                        Dictionary<int, bool> dict = new Dictionary<int, bool>();

                        for (int i = 0; i < N; i++)
                        {
                            list.Add(i);
                            hashSet.Add(i);
                            dict[i] = true;
                        }

                        int targetExists = N - 1;
                        int targetMissing = -1;

                        Console.WriteLine($"N = {N}");

                        // --- Contains(N-1)
                        Console.Write("List.Contains(N-1):   ");
                        TimeIt(() => list.Contains(targetExists));

                        Console.Write("HashSet.Contains:     ");
                        TimeIt(() => hashSet.Contains(targetExists));

                        Console.Write("Dict.ContainsKey:     ");
                        TimeIt(() => dict.ContainsKey(targetExists));

                        // --- Contains(-1)
                        Console.Write("List.Contains(-1):    ");
                        TimeIt(() => list.Contains(targetMissing));

                        Console.Write("HashSet.Contains(-1): ");
                        TimeIt(() => hashSet.Contains(targetMissing));

                        Console.Write("Dict.ContainsKey(-1): ");
                        TimeIt(() => dict.ContainsKey(targetMissing));

                        Console.WriteLine();
                    }
                }

                static void TimeIt(Action action)
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    action();
                    sw.Stop();
                    Console.WriteLine($"{sw.Elapsed.TotalMilliseconds:F3} ms");
                }

                #endregion


    }
}