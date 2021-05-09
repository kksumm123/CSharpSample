using System;
using System.Collections.Generic;

namespace 머드게임
{
    class Program
    {
        static Random random = new Random();
        // 머드게임을 만들면서 클래스에 대해서 배워봅시다.
        // 왜 new를 할까? static 변수와 static클래스 만으로 구현할 수 없는 건가?
        static void Main(string[] args)
        {
            Console.WriteLine("바람의 킹덤 Ver0.1");

            bool quit = false;
            while (quit == false)
            {
                Console.WriteLine("당신의 이름을 입력해주세요");
                string userName = Console.ReadLine();

                bool isReset;
                int power, hp;

                do
                {
                    power = random.Next(3, 10);
                    hp = random.Next(3, 10);
                    //당신의 능력은 입니다. 공격력 3, 체력 5 입니다.
                    Console.WriteLine($"{userName}님은 공격력:{power}, 체력:{hp} 입니다. 다시 생성 하시겠습니까?");
                    string resetAnswer = Console.ReadLine();
                    isReset = resetAnswer.ToLower() == "y";
                } while (isReset);



                Player player = new Player(userName, power, hp);

                Console.WriteLine("탐험을 시작합니다. Press any key");

                while (player.hp > 0)
                {
                    int monsterCount = random.Next(1, 3); // 1 ~ 2개(최소값은 포함해도 최대값은 포함하지 않음) 
                    List<Monster> monsters = new List<Monster>();
                    for (int i = 0; i < monsterCount; i++)
                    {
                        monsters.Add(new Monster());
                    }

                    // 몬스터를 만났습니다.
                    Console.WriteLine($"몬스터 {monsterCount}마리를 만났습니다. 전투 시작!");

                    // 몬스터 정보 출력.
                    foreach(var m in monsters)
                    {
                        Console.WriteLine($"{m.name} 공격력:{m.power}, 체력:{m.hp}");
                    }

                    // 유저 정보 출력.
                    Console.WriteLine($"{player.userName} 공격력:{player.power}, {player.hp}");

                    //유저 행동.
                    Console.WriteLine("1:공격, 2:회복, 3:도망");
                    int userInput = int.Parse(Console.ReadKey().KeyChar.ToString());
                    switch (userInput)
                    {
                        case 1:// 공격
                            PlayerAttack(player, monsters);
                            break;
                        case 2: // 회복
                            player.RestoreHp();
                            break;
                        case 3: // 도망.
                            bool successRun = TryRun();
                            break;
                        default:
                            Console.WriteLine("없는 명령어 입니다" + userInput);
                            break;
                    }

                    // 몬스터가 플레이어를 공겨.
                    MonsterAttackToPlayer(player, monsters);
                }

                Console.WriteLine(@$"{userName}은 사망했습니다.
GameOver");
            }

        }

        private static void MonsterAttackToPlayer(Player player, List<Monster> monsters)
        {
            throw new NotImplementedException();
        }

        private static void PlayerAttack(Player player, List<Monster> monsters)
        {
            Console.WriteLine("공격할 몬스터를 선택하세요");

            for (int i = 0; i < monsters.Count; i++)
            {
                var m = monsters[i];
                Console.WriteLine($"{i+1} : {m.name} 공격력:{m.power}, 체력:{m.hp}");
            }

            int selected  = int.Parse(Console.ReadKey().KeyChar.ToString());
            var selectedMonster = monsters[selected];
            selectedMonster.hp -= player.power;

            Console.WriteLine($"{selectedMonster.name}의 체력이 {selectedMonster.hp}가 되었다");

            // 몬스터가 죽었는가?
            if (selectedMonster.hp <= 0)
            {
                Console.WriteLine($"{selectedMonster.name}가 죽었다");

                // todo:몬스터 죽일시 아이템 경험치 획득, [랜덤]아이템 획득
                monsters.Remove(selectedMonster);
            }
        }

        private static bool TryRun()
        {
            int result = random.Next(0, 10);
            bool successRun = result > 3;
            return successRun;
        }

        // ToString을 오버라이드 하여 정보 출력하는 부분을 개선합시다.

        // 광격 공격을 추가 해봅시다.

        // AI동료를 추가해 봅시다.

        // 일정 확률로 반격하는 적을 추가해봅시다.
    }
}
