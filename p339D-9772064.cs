// Xenia and Bit Operations
// http://codeforces.com/problemset/problem/339/D
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;

namespace ConsoleApplication3
{
    internal class Program
    {
        private static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var cquery = input[1];
            var rga = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var rgnode = new Node[rga.Length*2-1];
            for (var i = 0; i < rga.Length; i++)
                rgnode[i] = new Node {V = rga[i]};

            var k = 0;
            var inode = rga.Length;
            var fXor = false;
            var l = rga.Length >> 1;
            while (l > 0)
            {
                for (int i = 0; i < l; i ++)
                {
                    rgnode[inode] = new Node {childA = rgnode[k], childB = rgnode[k + 1], fXor = fXor};
                    rgnode[k].parent = rgnode[k+1].parent = rgnode[inode];
                    inode++;
                    k += 2;
                }
                l /= 2;
                fXor = !fXor;
            }

            var root = rgnode[rgnode.Length - 1];
            for (var iquery = 0; iquery < cquery; iquery++)
            {
                var query = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var node = rgnode[query[0] - 1];
                node.V = query[1];
                node.parent.Update();

                Console.WriteLine(root.V);
            }
        }

        private class Node
        {
            public Node childA;
            public Node childB;
            public Node parent;
            public bool fInput;
            public bool fXor;
            public int? V;

            public int Compute()
            {
                if (childA == null)
                    return V.Value;
                if (V == null)
                    V = fXor ? childA.Compute() ^ childB.Compute() : childA.Compute() | childB.Compute();
                return V.Value;
            }

            public void Update()
            {
                V = fXor ? childA.Compute() ^ childB.Compute() : childA.Compute() | childB.Compute();
                if (parent != null)
                    parent.Update();
            }
        }
    }
}
