// Theatre Square
// http://codeforces.com/problemset/problem/1/A
using System;
using System.Linq;
using System.Numerics;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            var rgnum = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            var n = rgnum[0];
            var m = rgnum[1];
            var a = rgnum[2];

            var res = new BigInteger(Math.Ceiling((double) n/a)*Math.Ceiling((double) m/a));
            Console.WriteLine( res.ToString());
        }
    }
}
