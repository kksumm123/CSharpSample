using System;

namespace 클래스_4.static변수와_static함수
{
    public class Program
    {
        static void Main(string[] args)
        {
            Monster.TotalCount++;
        }
    }
    public class Monster
    {
        static public int TotalCount;
    }
    public class Animal
    {
        static int TotalCount;

        string name = "이름";
        int power   = 1;

        // 실행파일 실행시 항상 고정된 static Main함수 실행.
        // 인스턴스가 없는 상태에서 시작해야 하므로 static함수로 설정.
        static void Main(string[] args)
        {
            Console.WriteLine("static설명");


            // static 설명:
            // 인스턴스가 독립적으로 사용하는 변수나 함수는 static이 아니다.
            // 인스턴스가 공용으로 사용하는 변수나 함수는 static이다.


            Animal fox;
            fox = new Animal();
            fox.name = "여우";
            fox.power = 3;

            Animal.TotalCount++;

            Animal lion;
            lion = new Animal();
            lion.name = "사자";
            lion.power = 5;
            TotalCount++;
            // Animal 클래스 내에서 사용하므로 "Animal."생략 가능.
            // static변수는 해당 클래스 내에서 언제나 사용가능


            Console.WriteLine($"전체 동물은 {TotalCount}마리 있다");
            Console.WriteLine($"{fox.name}의 power는{fox.power}입니다");
            Console.WriteLine($"{lion.name}의 power는{lion.power}입니다");

            Console.WriteLine($"전체 동물은 {GetTotalCount()}마리 있다(static 함수로 호출)");
        }

        static public int GetTotalCount()
        {
            return TotalCount;
        }
    }
}
