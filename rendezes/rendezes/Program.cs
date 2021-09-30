using System;
using System.Linq;

namespace rendezes
{
    class Program
    {
        static void Main(string[] args)
        {
            Sorter a = new Sorter();
            int[] array = new int[] { 1, 2, 3, 5, 4, 1, 8};
            a.Sort<int>(array);

            System.Console.WriteLine(array.Aggregate(string.Empty, (a, b) => $"{a} {b}"));
        }
    }

    public class Sorter
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
