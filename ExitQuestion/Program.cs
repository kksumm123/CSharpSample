using System;

namespace ExitQuestion
{
    class Program
    {
        static void Main()
        {
            // 키보드를 눌러주세요
            // 누르신 키보드는 ()입니다
            // 계속 하시겠습니까 ? (y / n)

            bool isContinue;
            do
            {
                Print("키보드를 눌러주세요");
                string inputKey = Console.ReadLine();
                Print($"누르신 키는 {inputKey}입니다.");
                Print("계속 하시겠습니까?(y/n)");

                inputKey = Console.ReadLine();
                isContinue = inputKey == "y" || inputKey == "Y";
            } while (isContinue);        
        }

        private static void Print(string log)
        {
            Console.WriteLine(log);
        }
    }
}
