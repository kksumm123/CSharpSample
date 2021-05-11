using System;
using System.Diagnostics;

namespace 클래스_1.생성자
{
    public class Me
    {
        public int i = 1;
        public int k = 2;
        public int x = 3;

        public Me()
        {
            Debug.WriteLine($"Me 클래스 생성자 실행됨");
        }


        // C#에서 소멸자는 사용하지 말것을 권장 -> 실제 사용할일 없음.
        ~Me() 
        {
            Debug.WriteLine(@"Me 클래스 소멸자 실행됨
-> 아무도 참조 안하면 쓰레기 수거 대상이 됨
GC(Garbage Collector)실행시 소멸, GC실행시기는 GC가 판단");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 인스턴스 할당 = new 클래스타입()
            // 레퍼런스 형식(class, array, string)은 주소값만 갖는다.
            // 레퍼런스 형식은 new를 통해서 메모리를 할당후
            // 할당된 주소를 레퍼런스 변수에 기록한다.
            // string은 new가 생략되어 있음, 글자를 넣을때마다 새로운 공간 할당되고 메모리 주소만 기억하는건 동일.

            Me me;
            me = new Me();
        }
    }
}
