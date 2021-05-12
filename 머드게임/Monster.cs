using System;

namespace 머드게임
{
    public class CounterAttackTroll : Monster
    {
        public CounterAttackTroll(int dungeonLevel):base(dungeonLevel)
        {
        }

        public override void OnHit(int damage, Player player)
        {
            base.OnHit(damage, player);

            // 몬스터가 맞을때 반격 해야한다. -> 특정 확률로 반격한다.
            Random random = new Random();
            if (random.NextDouble() // 0 ~ 1
                > 0.3) // 30% 확률로 반격 하자., 0 ~ 0.3 
            {
                player.hp -= power;
                Console.WriteLine($"{name}이 반격했다. 플레이어 체력:{player.hp}");
            }
        }
    }

    public class Monster
    {
        static Random random = new Random();
        static int idTotal;

        public int id;
        public string name;
        public int power;
        public int hp;


        public int getExp = 1;

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

        public override string ToString()
        {
            return $"{name} 공격력:{power}, 체력:{hp}";
        }

        virtual public void OnHit(int damage, Player player)
        {
            hp -= damage;

            Print($"{name}의 체력이 {hp}가 되었다");
        }

        private void Print(string log)
        {
            Console.WriteLine(log);
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