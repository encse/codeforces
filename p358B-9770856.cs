// Dima and Text Messages
// http://codeforces.com/problemset/problem/358/B
using System;
using System.Linq;
using System.Text;

namespace ConsoleApplication3
{
    internal class Program
    {
        private static void Main()
        {
            var cword = int.Parse(Console.ReadLine());
            var msgA = new StringBuilder();
            msgA.Append("<3");
            for (var iword = 0; iword < cword; iword++)
            {
                msgA.Append(Console.ReadLine().TrimEnd());
                msgA.Append("<3");
            }

            var msgB = Console.ReadLine();
            var ichA = 0;
            var ichB = 0;

            while (ichA < msgA.Length)
            {
                if (ichB == msgB.Length)
                {
                    Console.WriteLine("no");
                    return;
                }
                if (msgA[ichA] == msgB[ichB])
                {
                    ichA++;
                    ichB++;
                }
                else
                {
                    ichB++;
                }
            }
            Console.WriteLine("yes");
        }

    }
}
