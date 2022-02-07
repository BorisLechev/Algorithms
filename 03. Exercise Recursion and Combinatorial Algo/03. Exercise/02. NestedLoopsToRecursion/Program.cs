using System;

namespace _02._NestedLoopsToRecursion
{
    public class Program
    {
        public static void Main()
        {
            var elementsCount = int.Parse(Console.ReadLine());

            var elements = new int[elementsCount];

            Loop(elements, 0);
        }

        private static void Loop(int[] elements, int index)
        {
            if (index == elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            for (int number = 1; number < elements.Length + 1; number++)
            {
                elements[index] = number;

                Loop(elements, index + 1);
            }
        }
    }
}
