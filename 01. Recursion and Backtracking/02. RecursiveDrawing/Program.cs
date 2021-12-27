using System;

namespace _02._RecursiveDrawing
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            DrawFigure(n);
        }

        private static void DrawFigure(int size)
        {
            if (size == 0)
            {
                return;
            }

            Console.WriteLine(new string('*', size));

            DrawFigure(size - 1);

            Console.WriteLine(new string('#', size));
        }
    }
}
