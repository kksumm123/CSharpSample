using System;
using System.Collections.Generic;

namespace Virtual_함수_사용법
{
    class ChildMonsterA 
    {
        public void Attack(Player player)
        {
            Console.WriteLine("A Attack");
        }
    }
    class ChildMonsterB 
    {
        public void Attack(Player player)
        {
            Console.WriteLine("B Attack");
        }
    }

    class ChildMonsterC 
    {
        public void Attack(Player player)
        {
            Console.WriteLine("C Attack");
        }
    }

    class Player
    {
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("virtual 사용법 - 상속없이 구현");

            Player player = new Player();

            ChildMonsterA a1 = new ChildMonsterA();
            ChildMonsterA a2 = new ChildMonsterA();
            ChildMonsterA a3 = new ChildMonsterA();

            ChildMonsterB b1 = new ChildMonsterB();
            ChildMonsterB b2 = new ChildMonsterB();

            ChildMonsterC c1 = new ChildMonsterC();

            List<ChildMonsterA> aMonsters = new List<ChildMonsterA> { a1, a2, a3 };
            List<ChildMonsterB> bMonsters = new List<ChildMonsterB> { b1, b2 };
            List<ChildMonsterC> cMonsters = new List<ChildMonsterC> { c1 };

            aMonsters.ForEach(x => x.Attack(player));
            bMonsters.ForEach(x => x.Attack(player));
            cMonsters.ForEach(x => x.Attack(player));
        }
    }
}
