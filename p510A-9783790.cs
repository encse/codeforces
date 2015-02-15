// Fox And Snake
// http://codeforces.com/problemset/problem/510/A
using System;
using System.Linq;

namespace ConsoleApplication3
{
    internal class Program
    {
        private static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var crow = input[0];
            var ccol = input[1];

            var rows = new[]
            {
                new string('#', ccol),
                new string('.', ccol - 1) + '#',
                new string('#', ccol),
                "#" + new string('.', ccol - 1)
            };
            for (var irow = 0; irow < crow; irow++)
                Console.WriteLine(rows[irow%4]);
        }

    }
}
