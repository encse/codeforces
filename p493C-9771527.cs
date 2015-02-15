// Vasya and Basketball
// http://codeforces.com/problemset/problem/493/C
using System;
using System.Linq;
using System.Text;

namespace ConsoleApplication3
{
    internal class Program
    {
        private static void Main()
        {
            var cthrowA = int.Parse(Console.ReadLine());
            var throwsA = Console.ReadLine().Split(' ').Select(int.Parse).OrderBy(x=>x).ToArray();
            var cthrowB = int.Parse(Console.ReadLine());
            var throwsB = Console.ReadLine().Split(' ').Select(int.Parse).OrderBy(x => x).ToArray();


            var pointsA = 0;
            var pointsB = 0;
            var maxDist = int.MinValue;

            var j = 0;
            for (var i=0;i <= cthrowA;i++)
            {
                var d = i == cthrowA ? int.MaxValue : throwsA[i];
             
                while (j < cthrowB && throwsB[j] < d) j++;

                var ptA = i * 2 + (cthrowA - i) * 3;
                var ptB = j * 2 + (cthrowB - j) * 3;

                if (ptA - ptB > maxDist)
                {
                    maxDist = ptA - ptB;
                    pointsA = ptA;
                    pointsB = ptB;
                }
            }

            Console.WriteLine(pointsA + ":" + pointsB);
        }

    }
}
