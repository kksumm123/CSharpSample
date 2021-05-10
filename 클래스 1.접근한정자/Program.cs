using System;

namespace 클래스_3.접근한정자
{
    public class Father
    {
        private int 아빠만사용하는비상금; // 상속하지 않음.
        protected int 은닉재산;           //protected 상속 받은 클래스에서도 사용가능
        public int 공개된재산;           // 상속 받은 클래스와 외부에서 모두 사용가능

        public Father()
        {
            아빠만사용하는비상금 = 1000000000;
            은닉재산 = 200000000;
            공개된재산 = 290000;
        }
        void PrintMyMoney()
        {
            Console.WriteLine(아빠만사용하는비상금);
            Console.WriteLine(은닉재산);
            Console.WriteLine(공개된재산);
        }
    }
    public class Me : Father
    {
        void PrintMyMoney()
        {
            //Console.WriteLine(아빠만사용하는비상금);
            Console.WriteLine(은닉재산);
            Console.WriteLine(공개된재산);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Me me = new Me();

            //Console.WriteLine(me.아빠만사용하는비상금);
            //Console.WriteLine(me.은닉재산);
            Console.WriteLine(me.공개된재산);
        }
    }
}
