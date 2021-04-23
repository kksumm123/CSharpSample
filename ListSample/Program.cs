using System;
using System.Collections.Generic;

namespace ListSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new List<string> { "<name>", "Ana", "Felipe" };

            // list1 초기화 방법
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
