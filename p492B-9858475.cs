// Vanya and Lanterns
// http://codeforces.com/problemset/problem/492/B
using System;
using System.Globalization;
using System.Linq;

namespace ConsoleApplication3
{
    internal class Program
    {
        private static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var n = input[0];
            var l = input[1];
            var rga = Console.ReadLine().Split(' ').Select(int.Parse).OrderBy(x=>x).ToList();

            double d = rga[0];
            for (var i = 0; i < rga.Count - 1; i++)
                d = Math.Max( (rga[i + 1] - rga[i]) / 2.0, d);

            d = Math.Max(l - rga[n - 1], d);

            Console.WriteLine( d.ToString(CultureInfo.InvariantCulture));
        }

    }
}