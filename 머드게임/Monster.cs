using System;

namespace 머드게임
{

    internal class Monster
    {
        static Random random = new Random();
        static int idTotal;

        public int id;
        public string name;
        public int power;
        public int hp;
        public Monster()
        {
            id = ++idTotal;

            name = "몬스터" + id;
            power = random.Next(1, 2);
            hp = random.Next(1, 2);
        }
    }
}