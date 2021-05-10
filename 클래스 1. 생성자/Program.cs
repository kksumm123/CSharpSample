using System;

namespace 클래스 1.생성자
{
    public class Father
    {
        public Father()
        {
            Console.WriteLine("Father 클래스 생성자 호출되었어요");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Father();
        }
    }
}
