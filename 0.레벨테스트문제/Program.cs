using System;
using System.Collections.Generic;
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

        //문제 6에서 사용.
        private struct ValueType
        {
            public int x;
        }

        private class RefType
        {
            public int x;
        }

        private static void Main(string[] args)
        {
            // https://forms.gle/HNBT2KP2N94dJMTR6 // 실력 확인을 위한 설문조사

            // 변수 생명 주기 : 선언된 괄호 안에서 살아 있다
            {
                int x = 0; // 변수(x)는 괄호가 끝나기 전까지 살아 있다.
            }

            {
                // 선언되기 전에 사용할순 없다.
                //Console.Write(x);

                int x = 0; // 위에 있는 x와 변수 이름이 같지만 에러가 아니다. 괄호 내에 살아 있는 x가 없기 때문이다.
            }// 괄호가 닫힐때 사라진다.

            {
                //함수사용법.
                Method1(1, 2);
                Method1(1, 2, 3);
                Method1(param2: 1, param1: 2);
            }

            {
                //함수 사용법 2 : 반환하고 싶은게 2개 이상일때?
                // 방법1:반환하기 위한 임시 클래스(구조체 생성)
                // 방법2: out파라미터 사용
                int int1 = 2;
                int int2;

                Method2(in int1, out int2, out int int3);
                Console.WriteLine($"int1:{int1}, int2:{int2}, int3:{int3}"); //int1:2, int2:3, int3:4
            }

            //형 변환double 타입의 변수 x를 int타입의 변수 a에 캐스팅하시오
            {
                float f1 = 1.3f;
                int i1 = (int)f1;
                float f2 = 1.6f;
                int i2 = (int)f2;

                float f3 = -1.3f;
                int i3 = (int)f3;
                float f4 = -1.6f;
                int i4 = (int)f4;
                Console.WriteLine($"i1:{i1}, i2:{i2}, i3:{i3}, i4:{i4}"); // 형변한하면 반올림 되는게 아니라 값이 짤림
            }

            // 문제1
            {
                int answer = (13 % 3) * 3 - 9;
                CountCorrectAnswer("여기답적기", answer);
            }

            // 문제2
            {
                int x = 1;
                string answer = $"{x++}, {x}, {++x}, {x}";
                CountCorrectAnswer(" , , , ", answer);
            }

            // 문제3
            {
                int answer = (int)Weekend.Wednesday;
                CountCorrectAnswer("여기답적기", answer);
            }

            // 문제4. || && 사용
            {
                CountCorrectAnswer("여기답적기", Question());

                bool Question()
                {
                    bool isA = true;
                    bool isB = false;
                    bool isC = true;
                    bool isD = false;
                    return !(((isA && isC) || isB) && ((isA && isB) == isD) == true);
                }
            }

            // 문제 5
            {
            }

            // 문제 6 값타입에서의 대입과 참조타입에서의 대입.
            {
                ValueType v1, v2;
                v1.x = 1;
                v2 = v1;
                v1.x = 2;
                CountCorrectAnswer("여기답적기", v2.x);
                // 값 타입에서의 대입은 값을 복사한다.

                RefType r1 = new RefType(), r2 = new RefType();
                r1.x = 1;
                r2 = r1;
                r1.x = 2;
                CountCorrectAnswer("여기답적기", r2.x);
                // 참조 타입에서의 대입은 주소를 넘겨준다. -> 값을 바꾸면 같은 주소를 보고 있기에 모두 변한다.
            }

            // 문제 7. 함수 기본값 사용, 자식 부모관계에서 형 변환
            {
                Point a = new Point(10, 20);
                Point b = new Point3D(10, 20, 30); // 부모 클래스는 자식 클래스를 담을 수 있다.(자식 클래스에 있는 변수는 사용할 수 없다.
                Point3D c = (Point3D)b;
                CountCorrectAnswer("여기답적기", c.z);
            }

            // 문자열 포멧 사용.
            {
                int score = 1000;
                Console.WriteLine($"{score:N}");

                Console.WriteLine(string.Format("{0:N}", score));
            }

            // static을 이해하고 있는가?
            // static(정적) <-> dynamic(동적)
            // static 프로그램 실행시바로 초기화 되어 언제든지 사용할 수 있다
            // dynamic은 프로그램 실행중에 코드가 실행되면 초기화되어 사용된다
            {
                // static 변수 사용.
                {
                    StaticVariableInclude staticVariableInclude = new StaticVariableInclude();
                    staticVariableInclude.normalInt = 1;
                    StaticVariableInclude.staticInt = 2;
                }

                {
                    StaticVariableInclude staticVariableInclude = new StaticVariableInclude();

                    CountCorrectAnswer("여기답적기", staticVariableInclude.normalInt, "일반 변수 생존 주기");
                    CountCorrectAnswer("여기답적기", StaticVariableInclude.staticInt, "Static 변수 생존 주기");
                }
            }

            // static 함수 사용
            {
                StaticMethodInclude staticMethodInclude = new StaticMethodInclude();
                staticMethodInclude.MyNotStaticMethod();

                StaticMethodInclude.MyStaticMethod();
            }

            // 확장 함수 사용
            {
                int score = 1000;
                Console.WriteLine(score.ToNumber());
            }

            // 형식 매개 변수
            {
                //List는 어떻게 모든 타입을 사용할 수 있을까?
                List<int> intList = new List<int>();
                List<string> stringList = new List<string>();

                // 우리도 모든 타입을 담는 클래스를 만들어보자.
                AllType<int> intVariable = new AllType<int>();
                intVariable.value = 1;

                AllType<string> stringVariable = new AllType<string>();
                stringVariable.value = "string";
            }

            Console.WriteLine($"맞힌 정답수는 : {correctAnswer}개({correctAnswer / (float)qustionCount * 100})%입니다");
            Console.WriteLine(sb.ToString());
        }

        private static void Method1(int param1, int param2, int param3 = 10)
        {
            Console.WriteLine($"parma1:{param1}, parma2:{param2}, parma3:{param3}");
        }

        private static void Method2(in int param1, out int param2, out int param3)
        {
            //param1 = 1; //in 파라미터는 읽기전용이라서 값 할당 불가.
            param2 = param1 + 1; // out파라미터에 값 할당 안하면 컴파일 에러
            param3 = param1 * 2;
        }

        private class StaticVariableInclude
        {
            static public int staticInt;
            public int normalInt;
        }

        private class StaticMethodInclude
        {
            static public void MyStaticMethod()
            {
                Console.WriteLine("static 함수 호출");
            }

            public void MyNotStaticMethod()
            {
                Console.WriteLine("일반 함수 호출");
            }
        }

        public class AllType<UndefinedType>
        {
            public UndefinedType value;
        }

        public class Point
        {
            public int x, y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public class Point3D : Point
        {
            public int z;

            public Point3D(int x, int y, int z) : base(x, y)
            {
                this.z = z;
            }
        }

        private static StringBuilder sb = new StringBuilder();

        private static void CountCorrectAnswer(string 입력한답, Object answerObject, string 문제내용 = "")
        {
            qustionCount++;

            string answer = answerObject.ToString();
            입력한답 = 입력한답.Replace(" ", "").Replace("여기답적기", "").ToLower();
            answer = answer.ToString().Replace(" ", "").ToLower();

            bool isCorrect = false;
            if (입력한답 == answer)
                isCorrect = true;

            if (isCorrect)
                correctAnswer++;
            sb.AppendLine($"문제{qustionCount}:{(isCorrect ? "o" : "x")} {문제내용}\n\t입력:{입력한답}\n\t정답:{answer}\n");
        }
    }
}