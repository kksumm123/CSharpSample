using System;

namespace 콘솔계산기
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"계산기 예제 입니다");
            bool quit = false;
            for(; quit == false;)
            {
                Console.WriteLine(@"
메뉴를 선택해주세요
(a)dd, (s)ubtract, (m)ultiply, (d)ivide, or (q)uit");
                string inputString = Console.ReadLine();
                // 문제 1) 산술연산자를 선택할때 대문자로 입력해도 작동되게 하자.
                // A -> add
                string operatorString = inputString.ToLower();

                if (operatorString == "q")
                    break;

                int inputNumberCount = 0;
                int a = 0;
                int b = 0;

                while(inputNumberCount != 2)
                {
                    Console.WriteLine("계산할 숫자를 2개 입력해주세요");
                    string numberString = Console.ReadLine();
                    string[] numberArray = numberString.Split(" ");
                    inputNumberCount = numberArray.Length;
                    if (inputNumberCount == 2)
                    {
                        a = int.Parse(numberArray[0]);
                        b = int.Parse(numberArray[1]);
                    }
                    else
                    {
                        Console.WriteLine($"2개의 숫자를 입력해야 합니다. 입력된 문자는 {numberString}({numberArray.Length}개)입니다.");
                    }
                }

                switch (operatorString)
                {
                    case "a": Console.WriteLine($"계산 결과는 {a} + {b} = {a + b}입니다"); break;
                    case "s": Console.WriteLine($"계산 결과는 {a} - {b} = {a - b}입니다"); break;

                    // 문제 2) 나누기 했을때 올바른 결과가 나오게 하자.
                    // ex) 5/2 = 2.5,...
                    case "m": Console.WriteLine($"계산 결과는 {a} * {b} = {a * b}입니다"); break;
                    case "d": Console.WriteLine($"계산 결과는 {a} / {b} = {(float)a / b}입니다"); break;
                    default: Console.WriteLine($"잘못된 연산자 입니다 {operatorString}"); break;
                }
            }

            Console.WriteLine("프로그램을 종료합니다");
        }
    }

    // 문제 1) 산술연산자를 선택할때 대문자로 입력해도 작동되게 하자.
    // A -> add

    // 문제 2) 나누기 했을때 올바른 결과가 나오게 하자.
    // ex) 5/2 = 2.5,...

    // 문제 3) do While문을 for문이나 while문을 사용해서 구현하자.

    // 문제 4) 올바른 연산 기호와 숫자가 아닌경우 다시 입력 받자.

    // 문제 5) 계산식을 입력 받아서 계산해보자 
    //ex) 1 + 1, 4*2,...

    // 문제 6) 2개 이상의 숫자를 연산하자.
    // ex ) 1 + 1 + 1,...
}
