// Game
// http://codeforces.com/problemset/problem/513/A
using System;
using System.Linq;

namespace ConsoleApplication3
{
    internal class Program
    {
        private static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine(input[0]>input[1] ? "First":"Second");
        }
    }
}
