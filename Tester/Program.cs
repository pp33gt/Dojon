using GameLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester2
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LimitedList<string>(capacity: 3);

            Console.WriteLine(list.Add("first"));
            Console.WriteLine(list.Add("second"));
            Console.WriteLine(list.Add("third"));
            Console.WriteLine(list.Add("fourth"));

            //list.Remove("first");

            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine(list[i]);
            //}

            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}

            foreach (var item in GetEvenNumbers())
            {
                Console.WriteLine(item);
                if (item > 100) break;
            }

            Console.WriteLine("hit any key");
            Console.ReadKey();
        }

        public static IEnumerable<int> GetEvenNumbers()
        {
            int i = 0;
            while (true)
            {
                yield return i;
                i += 2;
            }
        }
    }
}
