// Fox And Dinner
// http://codeforces.com/problemset/problem/510/E
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication3
{
    internal class Program
    {
        private static void Main()
        {
            var cfox = int.Parse(Console.ReadLine());
            var foxes =
                Console.ReadLine()
                    .Split(' ')
                    .Select((age, ifox) => new FordFulkerson.Node {age = int.Parse(age), ifox = ifox+1})
                    .ToArray();
            
            var ff = new FordFulkerson();

            for(var i =0;i<foxes.Length;i++)
            {
                var foxA = foxes[i];
                if (foxA.age % 2 == 1)
                    continue;

                for (var j= 0; j < foxes.Length; j++)
                {
                    var foxB= foxes[j];
                    if (foxB.age % 2 == 0)
                        continue;
                    if (IsPrime(foxA.age + foxB.age))
                    {
                        ff.AddEdge(foxA, foxB, 1);
                        ff.AddEdge(foxB, foxA, 0);
                    }
                }
            }

            var src = new FordFulkerson.Node{age=-1};
            foreach (var fox in foxes.Where(fox => fox.age%2 == 0))
            {
                ff.AddEdge(src, fox, 2);
                ff.AddEdge(fox, src, 0);
                
            }

            var dst = new FordFulkerson.Node {age = -2};
            foreach (var fox in foxes.Where(fox => fox.age%2 == 1))
            {
                ff.AddEdge(fox, dst, 2);
                ff.AddEdge(dst, fox, 0);
            }
           

            var flow = ff.FindFlow(src, dst);
            if (flow != cfox)
            {
                Console.WriteLine("Impossible");
            }
            else
            {
                var hlmFox = new HashSet<FordFulkerson.Node>(foxes);

                var rgpath = new List<List<FordFulkerson.Node>>();
                while (hlmFox.Any())
                {
                    var fox = hlmFox.First();
                    
                    var path = new List<FordFulkerson.Node>();
                    rgpath.Add(path);
                    while (fox != null)
                    {
                        hlmFox.Remove(fox);
                        path.Add(fox);
                        FordFulkerson.Node foxNew = null;
                        foreach (var edge in fox.NodeEdges)
                        {
                            if (fox.age%2 == 1)
                            {
                                var foxB = edge.NodeTo;
                                if (hlmFox.Contains(foxB) && ff.GetCapacity(foxB, fox) == 0)
                                {
                                    foxNew = foxB;
                                    break;
                                }
                            }
                            else
                            {
                                var foxB = edge.NodeTo;
                                if (hlmFox.Contains(foxB) && ff.GetCapacity(fox, foxB) == 0)
                                {
                                    foxNew = foxB;
                                    break;
                                }
                            }
                        }
                        fox = foxNew;
                    }
                }

                Console.WriteLine(rgpath.Count);
                foreach(var path in rgpath)
                {
                    Console.Write(path.Count);
                    foreach(var fox in path)
                        Console.Write(" " + fox.ifox);
                    Console.WriteLine();
                }
            }
        }

        public static bool IsPrime(int candidate)
        {
            if ((candidate & 1) == 0)
            {
                return candidate == 2;
            }

            for (var i = 3; (i * i) <= candidate; i += 2)
            {
                if ((candidate%i) == 0)
                    return false;
            }

            return candidate != 1;
        }
    }

    public class FordFulkerson
    {
        public readonly Dictionary<int, Edge> edges = new Dictionary<int, Edge>();

        public int FindFlow(Node nodeSource, Node nodeTerminal)
        {
            var flow = 0;

            var path = Bfs(nodeSource, nodeTerminal);

            while (path != null && path.Count > 0)
            {
                var minCapacity = int.MaxValue;
                foreach (var edge in path)
                {
                    if (edge.Capacity < minCapacity)
                        minCapacity = edge.Capacity;
                }

                if (minCapacity == int.MaxValue || minCapacity < 0)
                    throw new Exception("minCapacity " + minCapacity);

                AugmentPath(path, minCapacity);
                flow += minCapacity;

                path = Bfs(nodeSource, nodeTerminal);
            }
            return flow;
        }

        void AugmentPath(IEnumerable<Edge> path, int minCapacity)
        {
            foreach (var edge in path)
            {
                var keyResidual = GetKey(edge.NodeTo, edge.NodeFrom);
                var edgeResidual = edges[keyResidual];

                edge.Capacity -= minCapacity;
                edgeResidual.Capacity += minCapacity;
            }
        }

        List<Edge> Bfs(Node root, Node target)
        {
            root.TraverseParent = null;
            target.TraverseParent = null; //reset

            var queue = new Queue<Node>();
            var discovered = new HashSet<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                discovered.Add(current);

                if (current == target)
                    return GetPath(current);

                var nodeEdges = current.NodeEdges;
                foreach (var edge in nodeEdges)
                {
                    var next = edge.NodeTo;
                    var c = GetCapacity(current, next);
                    if (c > 0 && !discovered.Contains(next))
                    {
                        next.TraverseParent = current;
                        queue.Enqueue(next);
                    }
                }
            }
            return null;
        }
        
        List<Edge> GetPath(Node node)
        {
            var path = new List<Edge>();
            var current = node;
            while (current.TraverseParent != null)
            {
                var key = GetKey(current.TraverseParent, current);
                var edge = edges[key];
                path.Add(edge);
                current = current.TraverseParent;
            }
            return path;
        }

        public int GetKey(Node nodeA, Node nodeB)
        {
            return nodeA.ifox * 1000 + nodeB.ifox;
        }

        public int GetCapacity(Node node1, Node node2)
        {
            return edges[GetKey(node1, node2)].Capacity;
        }

        public void AddEdge(Node nodeFrom, Node nodeTo, int capacity)
        {
            var key = GetKey(nodeFrom, nodeTo);
            var edge = new Edge { NodeFrom = nodeFrom, NodeTo = nodeTo, Capacity = capacity };
            edges.Add(key, edge);
            nodeFrom.NodeEdges.Add(edge);
        }
       
        public class Node
        {
            public List<Edge> NodeEdges { get; set; }
            public Node TraverseParent { get; set; }

            public int age;
            public int ifox;

            public Node()
            {
                NodeEdges = new List<Edge>();
            }
        }

        public class Edge
        {
            public Node NodeFrom { get; set; }
            public Node NodeTo { get; set; }
            public int Capacity { get; set; }
            public string Name { get; set; }
        }
    }
}
