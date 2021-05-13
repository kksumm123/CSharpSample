using System;
using System.Collections.Generic;

namespace Virtual_함수_사용법_인터페이스로_구현
{
    public interface IAttack
    {
        public void Attack(Player player);
    }

    class Monster
    {
    }

    class ChildMonsterA : Monster, IAttack // 클래스는 1개만 상속 가능하지만 인터페이스는 갯수 제한 없음
    {
        public void Attack(Player player)
        {
            Console.WriteLine("A Attack");
        }
    }
    class ChildMonsterB : Monster, IAttack
    {
        public void Attack(Player player)
        {
            Console.WriteLine("B Attack");
        }
    }

    class ChildMonsterC : Monster, IAttack
    {
        public void Attack(Player player)
        {
            Console.WriteLine("C Attack");
        }
    }

    class Trap : IAttack
    {
        public void Attack(Player player)
        {
            Console.WriteLine("Trap Attack");
        }
    }

    public class Player
    {
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("virtual 사용법 - 상속으로 구현");

            Player player = new Player();

            ChildMonsterA a1 = new ChildMonsterA();
            ChildMonsterA a2 = new ChildMonsterA();
            ChildMonsterA a3 = new ChildMonsterA();

            ChildMonsterB b1 = new ChildMonsterB();
            ChildMonsterB b2 = new ChildMonsterB();

            ChildMonsterC c1 = new ChildMonsterC();

            Trap t1 = new Trap();

            List<IAttack> allMonsters = new List<IAttack> { a1, a2, a3, b1, b2, c1, t1 };

            allMonsters.ForEach(x => x.Attack(player));
        }
    }
}
