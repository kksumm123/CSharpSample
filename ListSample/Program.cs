using System;
using System.Collections.Generic;

namespace ListSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // 초기화 방법 1
            var names = new List<string> { "<name>", "Ana", "Felipe" };

            // 초기화 방법 2
            List<string> list1 = new List<string>();
            list1.Add("1");
            list1.Add("aa");
            list1.Add("22");

            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }

            Console.WriteLine("Hello World!");
        }
    }
}
