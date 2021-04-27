using System;

namespace 클래스_2.상속
{
    public class Father
    {
        public Father()
        {
            money = 100;

            Console.WriteLine($"아빠의 재산은 {money}원 이에요");
        }
        public int money; //public, protected를 사용해야 자식 클래스에서 사용가능
    }

    public class Me : Father
    {
        public Me()
        {
            Console.WriteLine($"나는 {money}을 상속 받았어요");
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
