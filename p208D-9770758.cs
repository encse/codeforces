// Prizes, Prizes, more Prizes
// http://codeforces.com/problemset/problem/208/D
using System;
using System.Linq;

namespace ConsoleApplication3
{
    internal class Program
    {
        private static void Main()
        {
            var cchocolate = int.Parse(Console.ReadLine());
            var rgpoint = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var rgprice = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var res = new long[rgprice.Length];
            var s = 0L;
            foreach (var point in rgpoint)
            {
                s += point;
                for (var i = rgprice.Length - 1; i >= 0; i--)
                {
                    var d = s / rgprice[i];
                    res[i] += d;
                    s = s % rgprice[i];
                }
            }

            foreach(var r in res)
                Console.Write(r + " ");
            Console.WriteLine();
            Console.WriteLine(s);
        }

    }
}
