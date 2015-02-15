// Next Round
// http://codeforces.com/problemset/problem/158/A
using System;
using System.Linq;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main()
        {
            var nAndK = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var n = nAndK[0];
            var k = nAndK[1];
            var points = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var advance = k;

            while (advance >= 1 && points[advance - 1] == 0)
                advance--;

            if (advance > 0)
            {
                var refPoints = points[advance - 1];

                while (advance < n && points[advance] == refPoints)
                    advance++;
            }
            Console.WriteLine(advance);
        }
    }
}
