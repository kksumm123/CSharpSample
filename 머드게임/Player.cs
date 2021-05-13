using System;
using System.Collections.Generic;

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

        int exp; // 10 -> 레벨 * 10 다음 레벨로 
        int level = 1;


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

        internal void GetExp(int getExp)
        {
            exp += getExp;

            if(exp >= level * 10)
            {
                // 레벨업
                level++;
                exp = 0;
                Print($"{userName}의 레벨이 {level}되었습니다");
            }
        }

        private void Print(string log)
        {
            Console.WriteLine(log);
        }

        // todo: 획득된 아이템 능력치 반영하기
        List<Item> equipedItems = new List<Item>();
        internal void AddItem(Item item)
        {
            equipedItems.Add(item);
        }
    }
}