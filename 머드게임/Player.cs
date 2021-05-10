using System;

namespace 머드게임
{
    internal class Player
    {
        public string userName;
        public int power;
        public int hp;
        int maxHp = 10;

        public Player(string _userName, int power, int mapHp)
        {
            userName = _userName;
            this.power = power;
            maxHp = mapHp;
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