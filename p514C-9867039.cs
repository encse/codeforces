// Watto and Mechanism
// http://codeforces.com/problemset/problem/514/C
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
            var m = input[1];

            var root = new Node();
            for (var i = 0; i < n; i++)
            {
                var st = Console.ReadLine();
                Insert(root, st, 0);
            }

            for (var i = 0; i < m; i++)
            {
                var st = Console.ReadLine();
                Console.WriteLine(Check(root, st, 0, false) ? "YES" : "NO");
            }
        }

        private static void Insert(Node node, string st, int ich)
        {
            if (ich == st.Length)
            {
                node.fEnd = true;
                return;
            }

            var ch = st[ich];
            if (!node.ContainsKey(ch))
                node[ch] = new Node();
            Insert(node[ch], st, ich + 1);
        }

        private static bool Check(Node node, string st, int ich, bool diff)
        {
            if (ich == st.Length)
                return node.fEnd && diff;

            var ch = st[ich];

            if (diff)
            {
                if (!node.ContainsKey(ch))
                    return false;
                return Check(node[ch], st, ich + 1, true);
            }

            foreach (var chT in "abc")
            {
                if (node.ContainsKey(chT) && Check(node[chT], st, ich + 1, chT != ch))
                    return true;
            }
            return false;
        }


        private class Node
        {
            public bool fEnd = false;
            public Node[] children = new Node[3];

            public bool ContainsKey(char ch)
            {
                return children[ch - 'a'] != null;
            }

            public Node this[char ch]
            {
                get { return children[ch - 'a']; }
                set { children[ch - 'a'] = value; }
            }
        }
    }
}