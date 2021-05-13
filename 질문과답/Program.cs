using System;

namespace 질문과답
{
    class Program
    {

        // y, n에 따라 루프 반복.
        static void Main(string[] args)
        {
            //DoWhileVersion();

            //WhileVersion();

            ForVersion();
        }

        private static void ForVersion()
        {
            int tryCount = 0;
            bool reTry = true;
            //반복.
            for (; reTry; )
            {
                Console.WriteLine($"[While문 사용]{++tryCount}번째 시도, 어떤 일을 여기서 합니다");
                Console.WriteLine("다시 하시겠습니까? (Y)es/(N)o");
                reTry = Console.ReadLine().ToUpper() == "Y";
            }
        }

        private static void WhileVersion()
        {
            int tryCount = 0;
            bool reTry = true;
            //반복.
            while(reTry)
            {
                Console.WriteLine($"[While문 사용]{++tryCount}번째 시도, 어떤 일을 여기서 합니다");
                Console.WriteLine("다시 하시겠습니까? (Y)es/(N)o");
                reTry = Console.ReadLine().ToUpper() == "Y";
            } 
        }

        private static void DoWhileVersion()
        {
            int tryCount = 0;
            //반복.
            do
            {
                Console.WriteLine($"{++tryCount}번째 시도, 어떤 일을 여기서 합니다");
                Console.WriteLine("다시 하시겠습니까? (Y)es/(N)o");
            } while (Console.ReadLine().ToUpper() == "Y");
        }
    }
}
