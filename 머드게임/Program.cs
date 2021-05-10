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
            Print("바람의 킹덤 Ver0.1");

            bool quit = false;
            do
            {
                //quit = true; // <- 나가야 되는 상황에서 변경
                Print("당신의 이름을 입력해주세요");
                string userName = Console.ReadLine();

                bool isReset = true;
                int power = 0, hp = 0;

                while (isReset)
                {
                    power = random.Next(4, 10);// 4는 포함하고 10은 포함하지 않는 -> 4 ~ 9
                    hp = random.Next(3, 10);
                    //당신의 능력은 입니다. 공격력 3, 체력 5 입니다.
                    Print($"{userName}님은 공격력:{power}, 체력:{hp} 입니다. 다시 생성 하시겠습니까?(Y/N)");
                    string resetAnswer = Console.ReadLine(); //  y, n
                    isReset = resetAnswer.ToLower() == "y";
                };

                Player player = new Player(userName, power, hp);

                Print("");
                Print("탐험을 시작합니다. Press any key");

                // 키 입력 받기
                Console.ReadKey();

                while (player.hp > 0)
                {
                    // 웨이브 시작.

                    // 몬스터 스폰, 리젠
                    int monsterCount = random.Next(1, 3); // 1 ~ 2개(최소값은 포함해도 최대값은 포함하지 않음) 
                    List<Monster> monsters = new List<Monster>();
                    for (int i = 0; i < monsterCount; i++)
                    {
                        monsters.Add(new Monster());
                    }

                    // 몬스터를 만났습니다.
                    Print($"몬스터 {monsterCount}마리를 만났습니다. 전투 시작!");
                    // $ : "몬스터 {2}마리를 만났습니다. 전투 시작!")
                    //  : "몬스터 {monsterCount}마리를 만났습니다. 전투 시작!")
                    string s1 = @"1
줄바꿈
                    빈공간";

                    string s2 = "1\n줄바꿈\n" +
"                   빈공간";


                    // 몬스터 정보 출력.
                    foreach (var m in monsters)
                    {
                        Print($"{m.name} 공격력:{m.power}, 체력:{m.hp}");
                    }

                    // 유저 정보 출력.
                    Print($"{player.userName} 공격력:{player.power}, 체력:{player.hp}");

                    Print("");
                    //유저 행동.
                    Print("1:공격, 2:회복, 3:도망");  //\n 이스케이프 문자.
                    char userInput = Console.ReadKey().KeyChar; // '1' ->  "1"

                    //string userName = Console.ReadLine();// <- 기존에 유저 입력 받던 방식.

                    switch (userInput)
                    {
                        case '1':// 공격
                            PlayerAttack(player, monsters);
                            break;
                        case '2': // 회복
                            player.RestoreHp();
                            break;
                        case '3': // 도망.
                            bool successRun = TryRun();
                            break;
                        default:
                            Print("없는 명령어 입니다" + userInput);
                            break;
                    }

                    // 몬스터가 플레이어를 공겨.
                    MonsterAttackToPlayer(player, monsters);
                }

                Print(@$"{userName}은 사망했습니다.
GameOver");
            } while (quit == false);
        }

        private static void Print(string log)
        {
            Console.WriteLine(log);
        }

        private static void MonsterAttackToPlayer(Player player, List<Monster> monsters)
        {
            Print("몬스터가 플레이어를 공격하는 로직은 아직 작성하지 않음");
        }

        private static void PlayerAttack(Player player, List<Monster> monsters)
        {
            Print("공격할 몬스터를 선택하세요");

            for (int i = 0; i < monsters.Count; i++)
            {
                var m = monsters[i];
                Print($"{i + 1} : {m.name} 공격력:{m.power}, 체력:{m.hp}");
            }

            int selected = -1 + int.Parse(Console.ReadKey().KeyChar.ToString()); // 인덱스는 0부터 시작하므로  -1
            
            var selectedMonster = monsters[selected];
            selectedMonster.hp -= player.power;

            Print($"{selectedMonster.name}의 체력이 {selectedMonster.hp}가 되었다");

            // 몬스터가 죽었는가?
            if (selectedMonster.hp <= 0)
            {
                Print($"{selectedMonster.name}가 죽었다");

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

        // 메인 함수를 이해 하기 쉽도록 단계별로 함수로 묶자.
    }
}
