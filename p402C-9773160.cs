// Searching for Graph
// http://codeforces.com/problemset/problem/402/C
using System;
using System.Linq;

namespace ConsoleApplication3
{
    internal class Program
    {
        private static void Main()
        {
            var ctest = int.Parse(Console.ReadLine());

            for (var itest = 0; itest < ctest; itest++)
            {
                var nAndp = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                var n = nAndp[0];
                var p = nAndp[1];

                var m = Graph(n, p);
                for (var inode = 0; inode < n; inode++)
                {
                    for (var jnode = inode+1; jnode < n; jnode++)
                    {
                        if (m[inode, jnode])
                            Console.WriteLine( (inode+1) + " "+ (jnode+1));
                    }
                }
            }

            Console.WriteLine();
        }

        private static bool[,] Graph(int n, int p)
        {
            var m = new bool[n, n];
            var cedgeToAdd = 2*n + p;
            var d = 1;
            while (true)
            {
                for (var inodeSrc = 0; inodeSrc < n; inodeSrc++)
                {
                    var inodeDst = (inodeSrc + d)%n;
                    if (m[inodeSrc, inodeDst])
                        continue;
                    m[inodeSrc, inodeDst] = m[inodeDst, inodeSrc] = true;

                    cedgeToAdd--;
                    if (cedgeToAdd == 0)
                        return m;
                }
                d++;
            }
        }
    }
}
