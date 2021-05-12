using System;

namespace 머드게임
{
    public class Player
    {
        public string DisplayName
        {
            get { return $"용사({userName})"; }
        }

        string userName;
        public int power;
        public int hp;
        public int score;
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

        public override string ToString()
        {
            return $"{DisplayName} 공격력:{power}, 체력:{hp}";
        }


    }
}