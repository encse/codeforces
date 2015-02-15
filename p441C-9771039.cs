// Valera and Tubes 
// http://codeforces.com/problemset/problem/441/C
using System;
using System.Linq;
using System.Text;

namespace ConsoleApplication3
{
    internal class Program
    {
        private static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var n = input[0];
            var m = input[1];
            var k = input[2];

            var x = 1;
            var y = 1;

            var dy = 1;
            var c = 0;
            for (var i = 0; i < k; i++)
            {
                var d = i == k-1 ? n * m - c : 2;
                Console.Write(d);
                while (d > 0)
                {
                    c++;
                    d--;
                    Console.Write(" " + x + " " + y);
                    y += dy;
                    if (y > m)
                    {
                        y = m;
                        dy = -dy;
                        x++;
                    }
                    else if (y == 0)
                    {
                        y = 1;
                        dy = -dy;
                        x++;
                    }
                }
                Console.WriteLine();
            }
        }

    }
}
