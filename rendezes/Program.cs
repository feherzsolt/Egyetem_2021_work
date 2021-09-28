using System;
using System.Linq;

namespace rendezes
{
    class Program
    {
        static void Main(string[] args)
        {
            SorterTests tests = new SorterTests();
            tests.Run();
        }
    }

    class SorterTests
    {
        public void Run()
        {
            Action[] tests = new Action[]
            {
                OneElementArray,
                EmptyArray, 
                ExpectSwap
            };

            int errorCount = 0;

            for (int index = 0; index < tests.Length; index++)
            {
                try
                {
                    tests[index]();
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Message);
                    errorCount++;
                }
            }

            System.Console.WriteLine($"Result {tests.Length - errorCount} OK, {errorCount} fail.");
        }

        public void OneElementArray()
        {
            int[] array = Sort(new int[] { 0 });
            AssertEqual(new int[] { 0 }, array);
        }

        public void EmptyArray()
        {
            int[] array = Sort(new int[0]);
            AssertEqual(new int[0], array);
        }

        public void ExpectSwap()
        {
            int[] array = Sort(new int[] { 1, 0 });
            AssertEqual(new int[] { 0, 1 }, array);
        }

        private static int[] Sort(int[] array)
        {
            Sorter uut = new Sorter();
            uut.Sort<int>(array);
            return array;
        }

        private void AssertEqual<T>(T[] expected, T[] actual) where T : IEquatable<T>
        {
            if (expected.Length != actual.Length)
                Error(expected, actual);
            for (int index = 0; index < expected.Length; index++)
            {
                if (!expected[index].Equals(actual[index]))
                    Error(expected, actual);
            }
        }

        private void Error<T>(T[] expected, T[] actual)
        {
            string expectedT = expected.Aggregate(string.Empty, (a,b)=> $"{a} {b}");
            string actualT = actual.Aggregate(string.Empty, (a,b) => $"{a} {b}");
            throw new Exception($"Error {expectedT} differ from {actualT}");
        }
    }

    class Sorter
    {
        public void Sort<T>(Span<T> elements) where T : IComparable
        {
            for (int index = 0; index < elements.Length; index++)
            {
                for (int current = 0; current < elements.Length - 1; current++)
                {
                    if (elements[current].CompareTo(elements[current + 1]) > 0)
                    {
                        (elements[current], elements[current + 1]) = (elements[current + 1], elements[current]);
                    }
                }
            }
        }
    }
}
