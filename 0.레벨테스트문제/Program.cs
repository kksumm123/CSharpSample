using System;
using System.Text;

namespace _0.레벨테스트문제
{
    internal static class MyExtension
    {
        static public string ToNumber(this int intNumber)
        {
            return $"{intNumber:N}";
        }
    }

    internal class Program
    {
        private static int correctAnswer = 0;
        private static int qustionCount = 0;
        private static readonly string answer5 = "a = (int)x;";

        //문제 3번에서 사용.
        public enum Weekend
        {
            NONE = -2,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        private static void Main(string[] args)
        {
            // https://forms.gle/HNBT2KP2N94dJMTR6 // 실력 확인을 위한 설문조사

            // 문제1
            {
                int answer = (13 % 3) * 3 - 9;
                Console.WriteLine($"1. answer의 값은?:{answer}");

                CountCorrectAnswer("여기답적기", answer.ToString());
            }

            // 문제2
            {
                int x = 1;
                string answer = $"{x++}, {x}, {++x}, {x}";
                Console.WriteLine(answer);
                CountCorrectAnswer(" , , , ", answer);
            }

            // 문제3
            {
                int answer = (int)Weekend.Wednesday;
                CountCorrectAnswer("여기답적기", answer.ToString());
            }

            // 문제4. || && 사용
            {
                CountCorrectAnswer("여기답적기", Question().ToString());

                bool Question()
                {
                    bool isA = true;
                    bool isB = false;
                    bool isC = true;
                    bool isD = false;
                    return !(((isA && isC) || isB) && ((isA && isB) == isD) == true);
                }
            }

            //문제 5. double 타입의 변수 x를 int타입의 변수 a에 캐스팅하시오
            {
                double x = 12.3;
                int a;
                a = (int)x;
                CountCorrectAnswer("여기답적기", answer5);
            }

            // 문자열 포멧 사용.
            {
                int score = 1000;
                Console.WriteLine($"{score:N}");

                Console.WriteLine(string.Format("{0:N}", score));
            }

            // 확장 함수 사용
            {
                int score = 1000;
                Console.WriteLine(score.ToNumber());
            }

            Console.WriteLine($"맞힌 정답수는 : {correctAnswer}개({correctAnswer / (float)qustionCount * 100})%입니다");
            Console.WriteLine(sb.ToString());
        }

        private static StringBuilder sb = new StringBuilder();

        private static void CountCorrectAnswer(string 입력한답, string answer)
        {
            qustionCount++;

            입력한답 = 입력한답.Replace(" ", "").Replace("여기답적기", "").ToLower();
            answer = answer.Replace(" ", "").ToLower();

            bool isCorrect = false;
            if (입력한답 == answer)
                isCorrect = true;

            if (isCorrect)
                correctAnswer++;
            sb.AppendLine($"문제{qustionCount}:{(isCorrect ? "o" : "x")}\n\t입력:{입력한답}\n\t정답:{answer}\n");
        }
    }
}