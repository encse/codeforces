// k-Tree
// http://codeforces.com/problemset/problem/431/C
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication3
{
    internal class Program
    {
        private static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var n = input[0];
            var k = input[1];
            var d = input[2];

            Console.WriteLine(Solve(n, k, d, false, new Cache()));
        }

        private static int Solve(int n, int k, int d, bool hasD, Cache cache)
        {
            var key = new Tuple<int, bool>(n, hasD);
            if (cache.ContainsKey(key))
                return cache[key];
            if (n == 0)
                return hasD ? 1 : 0;

            var res = 0;
            for (var i = 1; i <= Math.Min(n, k); i++)
                res = (res + Solve(n - i, k, d, hasD | i >= d, cache))%1000000007;

            return cache[key] = res;
        }

        class Cache : Dictionary<Tuple<int, bool>, int>
        {
             
        }
    }
}
