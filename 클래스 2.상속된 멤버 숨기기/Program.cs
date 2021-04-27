using System;

namespace 클래스_2.상속된_멤버_숨기기
{
    public class Father
    {
        public Father()
        {
            money = 100;

            Console.WriteLine($"아빠 태어날때부터 {money}원 가지고 있었어요");
        }
        public int money; //public, protected를 사용해야 자식 클래스에서 사용가능
    }

    public class Me : Father
    {
        // 부모에게 있는 변수와 변수 이름이 같은 경우 실수가 아니라
        // 의도적인 코드란것을 컴파일러와 동료에게 알려주기 위해 new를 사용한다.
        // new를 안해도 에러는 발생하지 않는다. 
        new public int money; 
        public Me()
        {
            money = 10;

            Console.WriteLine($"나는 {money}을 가지고 태어났어요");
            Console.WriteLine($"나는 아빠돈 {base.money}을 사용할 수 있어요");
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
