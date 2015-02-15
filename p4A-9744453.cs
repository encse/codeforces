// Watermelon
// http://codeforces.com/problemset/problem/4/A
using System;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = long.Parse(Console.ReadLine());
            Console.WriteLine(num % 2 == 0 && num > 2 ? "YES" : "NO");
        }
    }
}
