// Double Cola
// http://codeforces.com/problemset/problem/82/A
using System;
using System.Linq;

namespace ConsoleApplication3
{
    internal class Program
    {
        private static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var i = input[0] -1;

            var d = 1L;
            
            var xP = 0L;
            var x = 0L;
            while (x <= i)
            {
                xP = x;
                x += d * 5;
                d *= 2;
            }
            var names = new[] {"Sheldon", "Leonard", "Penny", "Rajesh", "Howard"};
            Console.WriteLine(names[(i - xP) / (d/2)]);
        }
    }
}
