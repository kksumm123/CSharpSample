using System;

namespace 머드게임
{

    public class Monster
    {
        static Random random = new Random();
        static int idTotal;

        public int id;
        public string name;
        public int power;
        public int hp;
        public Monster(int dungeonLevel)
        {
            id = ++idTotal;

            name = "몬스터" + id;
            power = random.Next(1, 2);
            hp = random.Next(1, 2) + dungeonLevel;
        }

        virtual public void OnAttack(Player targetPlayer)
        {
            targetPlayer.hp -= power;
            Console.WriteLine($"{name}의 공격으로 {targetPlayer.DisplayName}의 체력은 {targetPlayer.hp}가 되었다");
        }
    }


    public class DoubleBladeSlime : Monster
    {
        public DoubleBladeSlime(int dungeonLevel): base(dungeonLevel)
        {
            name = "쌍칼 슬라임";
            power += dungeonLevel;
        }

        override public void OnAttack(Player targetPlayer)
        {
            // 쌍칼 슬라임은 자신의 power로 2번 때린다.
            targetPlayer.hp -= power;
            Console.WriteLine($"{name}의 첫번째 공격으로 {targetPlayer.DisplayName}의 체력은 {targetPlayer.hp}가 되었다");

            targetPlayer.hp -= power;
            Console.WriteLine($"{name}의 두번째 공격으로 {targetPlayer.DisplayName}의 체력은 {targetPlayer.hp}가 되었다");
        }
    }
}