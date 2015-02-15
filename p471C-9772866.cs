// MUH and House of Cards
// http://codeforces.com/problemset/problem/471/C
using System;

namespace ConsoleApplication3
{
    internal class Program
    {
        private static void Main()
        {
            var ccard = long.Parse(Console.ReadLine());

            var distinctLevels = 0;
            int level = 0;
            switch (ccard % 3)
            {
                case 0: level = 3; break;
                case 1: level = 2; break;
                case 2: level = 1; break;
            }

            while (ccard >= Phi(level))
            {
                distinctLevels++;
                level += 3;
            }
            Console.WriteLine(distinctLevels);
        }

        private static long Phi(long level)
        {
            return (3 * level * level + level)/2;
        }
    }
}
