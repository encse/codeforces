// Vanya and Exams
// http://codeforces.com/problemset/problem/492/C
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApplication3
{
    internal class Program
    {
        private static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(uint.Parse).ToArray();

            var n = input[0];
            var r = input[1];
            var avg = input[2];
            var rgt = new List<uint[]>();
            var minSum = avg * (ulong)n;

            ulong sum = 0;
            for (int i = 0; i < n; i++)
            {
                var t = Console.ReadLine().Split(' ').Select(uint.Parse).ToArray();
                sum += t[0];
                if(t[0]<r)
                    rgt.Add(t);
            }
            rgt.Sort((t1, t2) => t1[1] < t2[1] ? -1 : t1[1] == t2[1] ? 0 :  1);
            ulong res = 0;
            foreach (var t in rgt)
            {
                if (sum >= minSum)
                    break;

                var a = t[0];
                var b = t[1];
                var d = r - a < minSum - sum ? r - a : minSum - sum;

                sum += d;
                res += d*b;
            }

            Console.WriteLine(res);
        }

    }
}