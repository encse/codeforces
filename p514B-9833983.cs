// Han Solo and Lazer Gun
// http://codeforces.com/problemset/problem/514/B
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
            var coord0 = new Coord(input[1], input[2]);
            var rgcoord = new HashSet<Coord>();
            for (var i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                rgcoord.Add(new Coord(input[0], input[1]));
            }

            var d = 0;
            while (rgcoord.Any())
            {
                d++;
                var coord = rgcoord.First();
                var vX = coord.x - coord0.x;
                var vY = coord.y - coord0.y;

                foreach (var coordT in rgcoord.ToList())
                {
                    if (vY*(coordT.x - coord0.x) == vX*(coordT.y - coord0.y))
                        rgcoord.Remove(coordT);
                }
            }
           
            Console.WriteLine(d);
        }

        private class Coord
        {
            public int x, y;

            public Coord(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
