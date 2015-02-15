// Chewbaсca and Number
// http://codeforces.com/problemset/problem/514/A
using System;
using System.Linq;

namespace ConsoleApplication3
{
    internal class Program
    {
        private static void Main()
        {
            var input = Console.ReadLine();//.Split(' ').Select(int.Parse).ToArray();
            var f = false;
            string st = "";
            foreach (var ch in input)
            {
                int i = ch - '0';
                var flip = 9 - i;
                if (!f && flip == 0)
                    st += ch;
                else
                {
                   
                    if (flip < i)
                        st += (char)(flip + '0');
                    else
                        st += ch;
                }
                f = true;

            }
            Console.WriteLine(st);
        }
    }
}