using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtentionMethodTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //2
            string s = "Привет мир";
            char c = 'и';
            int i = s.CharCount(c);
            Console.WriteLine(i);



            //3 Linq
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 4, 4 });

            Dictionary<int, int> res = new Dictionary<int, int>();

            foreach (var item in list)
            {
                int tmp = (from n in list where n == item select n).Count();
                if (!res.ContainsKey(item))
                    res.Add(item, tmp);
            }

            foreach (var item in res)
            {
                Console.WriteLine(item.Key.ToString() + " - " + item.Value.ToString());
            }



            //3 Lambda
            List<int> list2 = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 4, 4 });

            Dictionary<int, int> res2 = new Dictionary<int, int>();

            foreach (var item in list)
            {
                int tmp = list.Count(x => x == item);
                if (!res.ContainsKey(item))
                    res.Add(item, tmp);
            }

            foreach (var item in res)
            {
                Console.WriteLine(item.Key.ToString() + " - " + item.Value.ToString());
            }



            //4a
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };
            //var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            //Console.WriteLine($"{pair.Key} - {pair.Value}");
            foreach (var item in dict.OrderBy(e => e.Value))
            {
                Console.WriteLine(item);
            }


            Console.Read();
        }

    }
}
