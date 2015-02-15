// Alternating Current
// http://codeforces.com/problemset/problem/343/B
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleApplication3
{
    internal class Program
    {
        private static void Main()
        {
            var wires = Console.ReadLine();

            var ll = new LinkedList<int>();
            for (var i = 0; i < wires.Length;)
            {
                var ch = wires[i];
                var cch = 0;
                while (i < wires.Length && wires[i] == ch)
                {
                    i++;
                    cch++;
                }

                ll.AddLast(ch == '+' ? cch : -cch);
            }

            var li = ll.First;
            while (li != null)
            {
                var v = li.Value;
                if (v > 0)
                {
                    v -= 2*(v/2);
                }
                else
                {
                    v = -v;
                    v -= 2*(v/2);
                    v = -v;
                }

                if (v != 0)
                {
                    li.Value = v;
                    li = li.Next;
                }
                else
                {
                    if (li == ll.First)
                    {
                        ll.RemoveFirst();
                        li = ll.First;
                    }
                    else if (li == ll.Last)
                    {
                        ll.Remove(li);
                        li = null;
                    }
                    else
                    {
                        var liPrev = li.Previous;
                        if (v < 0)
                            liPrev.Value -= li.Next.Value;
                        else
                            liPrev.Value += li.Next.Value;
                        ll.Remove(li.Next);
                        ll.Remove(li);

                        li = liPrev;
                    }
                }
            }

            Console.WriteLine(ll.Count == 0 ? "Yes":"No");
        }
    }
}
