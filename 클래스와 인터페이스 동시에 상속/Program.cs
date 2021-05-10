using System;

namespace 클래스와_인터페이스_동시에_상속
{
    internal class Program
    {
        private class A
        {
            public void A클래스에있는함수()
            {
            }
        }

        private interface IA
        {
            public abstract void say();

            public abstract int prop
            {
                get; set;
            }
        }

        private class B : A, IA
        {
            private int b클래스의prop;
            public int prop { get => b클래스의prop; set => b클래스의prop = value; }

            public void say()
            {
                Console.WriteLine("IA에 있는 인터페이스 구현");
            }
        }

        private static void Main(string[] args)
        {
            B b = new B();
            b.say();
            b.prop = 5;
            Console.WriteLine($"b.prop : {b.prop}");
        }
    }
}