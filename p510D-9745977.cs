// Fox And Jumping
// http://codeforces.com/problemset/problem/510/D
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main()
        {
            var ccard = int.Parse(Console.ReadLine());
            var rgl = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var rgcost = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Console.WriteLine(SolveRecursive(0, rgl, rgcost, 0, new Cache()));
        }

        private static int SolveRecursive(int icard, int[] rgl, int[] rgcost, int gcd, Cache cache )
        {
            var key = new Tuple<int, int>(icard, gcd);
            int res;
            if (cache.TryGetValue(key, out res))
                return res;

            if (gcd == 1)
                return 0;

            if (icard == rgl.Length)
                return -1;

            Func<int, int> madd = cost => cost == -1 ? -1 : cost + rgcost[icard];

            var costWithChildren = new[]
            {
                 madd(SolveRecursive(icard + 1, rgl, rgcost,  GreatestCommonDivisor(gcd, rgl[icard]), cache)),
                 SolveRecursive(icard + 1, rgl, rgcost, gcd, cache),
              };

            return cache[key] = costWithChildren.All(cost => cost == -1) ?
                        -1 : 
                        costWithChildren.Where(cost => cost != -1).Min();
        }

        private class Cache : Dictionary<Tuple<int, int>, int>
        {
        }

        static int GreatestCommonDivisor(int a, int b)
        {
            int rem;

            while (b != 0)
            {
                rem = a % b;
                a = b;
                b = rem;
            }

            return a;
        }
    }
}
