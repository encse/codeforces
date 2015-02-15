// New Year Ratings Change
// http://codeforces.com/problemset/problem/379/C
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApplication3
{
    internal class Program
    {
        private static void Main()
        {
           var sb = new StringBuilder();
          //  Console.SetIn(new StringReader(Input(300000)));
           // Console.SetOut(new StringWriter(sb));

            var dt = DateTime.Now;
            var cuser = int.Parse(Console.ReadLine());

            var users = new Tuple<int,int>[cuser];
            var i = 0;
            foreach (var x in Console.ReadLine().Split(' '))
            {
                users[i] = new Tuple<int, int>(int.Parse(x), i);

                i++;
                if (i == cuser)
                    break;
            }

            Array.Sort(users, (u1,u2) => u1.Item1 - u2.Item1);

            Console.Error.WriteLine(DateTime.Now - dt);

            var rgb = new int[cuser];
            var b = 0;
            foreach (var user in users)
            {
                if (b < user.Item1)
                    b = user.Item1;
                rgb[user.Item2] = b;
                b++;
            }
            Console.Error.WriteLine(DateTime.Now - dt);
            
            foreach (var q in rgb)
                Console.Write(q + " ");

            Console.WriteLine();
            Console.Error.WriteLine(DateTime.Now - dt);
        }

        private static string Input(int cuser)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(cuser.ToString());
            var r = new Random(42);
            for(int i=0;i<cuser;i++)
            {
                sb.Append(r.Next(1000000000));
                sb.Append(" ");
            }
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
