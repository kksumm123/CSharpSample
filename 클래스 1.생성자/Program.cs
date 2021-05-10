using System;

namespace 클래스_1.생성자
{
    public class Me
    {
        public Me()
        {
            Console.WriteLine($"Me 클래스 생성자 실행됨");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Me();
        }
    }
}
