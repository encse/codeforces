// Vanya and Cubes
// http://codeforces.com/problemset/problem/492/A
using System;
using System.Linq;

namespace ConsoleApplication3
{
    internal class Program
    {
        private static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var n = input[0];
            var x = 1;
            var s = 1;
            var d = 2;
            var h = 0;
            while (n >= x)
            {
                h++;
                s += d;
                d ++;
                x += s;
            }
            Console.WriteLine(h);
        }

    }
}