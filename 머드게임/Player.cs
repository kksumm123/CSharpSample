using System;

namespace 머드게임
{
    internal class Player
    {
        public string userName;
        public int power;
        public int hp;
        int maxHp;

        public Player(string userName, int power, int hp)
        {
            this.userName = userName;
            this.power = power;
            this.maxHp = hp;
            this.hp = maxHp;
        }

        internal void RestoreHp()
        {
            if (hp < maxHp)
                hp++;

            //hp = Math.Min(hp + 1, maxHp);
        }
    }
}