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
                // 플레이어 이름 입력받기, 능력치 랜덤 설정.
                Player player = MakePlayer();

                Print("");
                Print("탐험을 시작합니다. Press any key");
                Console.ReadKey();  // 키 입력 받기

                quit = ProcessBattle(player);

            } while (quit == false);
        }

        private static Player MakePlayer()
        {
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
            return player;
        }

        private static bool ProcessBattle(Player player)
        {
            // 몬스터 스폰, 리젠
            int monsterCount = random.Next(1, 3); // 1 ~ 2개(최소값은 포함해도 최대값은 포함하지 않음) 
            List<Monster> monsters = new List<Monster>();
            for (int i = 0; i < monsterCount; i++)
            {
                monsters.Add(new Monster());
            }

            monsters.Add(new DoubleBladeSlime());

            Print($"몬스터 {monsters.Count}마리를 만났습니다.");

            // 문자열앞에 $를 사용하는 예제
            // $를 문자열앞에 붙였을때        : "몬스터 {2}마리를 만났습니다.")
            // $를 문자열앞에 붙이지 않았을때 : "몬스터 {monsterCount}마리를 만났습니다.")

            // 문자열앞에 @를 붙였을때의 예제
            // @를 붙이면 줄바꿈과 빈공간 표시를 직관적으로 할수 있다.
            string s1 = @"1
줄바꿈
                    빈공간";

            //문자여에서 글자 앞에 '\'이 있으면 이스케이프 문자를 의미합니다
            // 이스케이프 문자는 뒤에 오는 글자에 따라 다양한 기능이 있습니다.
            // 예를 들어 \n은 줄바꿈 표시 입니다.
            // https://docs.microsoft.com/ko-kr/dotnet/standard/base-types/character-escapes-in-regular-expressions
            string s2 = "1\n줄바꿈\n" +
"                   빈공간";

            // $와 @는 동시에 사용가능하며 순서는 상관없다.

            while (player.hp > 0)
            {
                Print("");
                Print("몬스터 정보 출력");
                // 몬스터 정보 출력.
                foreach (var m in monsters)
                {
                    Print($"{m.name} 공격력:{m.power}, 체력:{m.hp}");
                }

                // 유저 정보 출력.
                Print($"{player.DisplayName} 공격력:{player.power}, 체력:{player.hp}");

                //유저 행동.
                PlayerTurn(player, monsters);

                // 몬스터가 플레이어를 공격.
                MonsterTurn(player, monsters);
            }

            Print($@"{player.DisplayName}는 사망했습니다.
GameOver
처음부터 하시겠습니까?(R)etry/(Q)uit");

            string retryOrQuit;
            // (R)etry/(Q)uit
            retryOrQuit = GetAllowedAnswer("R", "Q");

            bool isQuit = retryOrQuit == "Q";
            return isQuit;
        }

        private static string GetAllowedAnswer(params string[] alllowsAnserStringArray)
        {
            string retryOrQuit;
            List<string> allowedAnswer = new List<string>(alllowsAnserStringArray);
            do
            {
                retryOrQuit = Console.ReadLine().ToUpper();
            } while (allowedAnswer.Contains(retryOrQuit) == false);
            return retryOrQuit;
        }

        private static void MonsterTurn(Player player, List<Monster> monsters)
        {
            Print("");

            // todo: 몬스터 HP회복 진행.

            // 몬스터가 플레이어 때리는 과정 진행
            MonsterAttackToPlayer(player, monsters);
        }

        private static void PlayerTurn(Player player, List<Monster> monsters)
        {
            Print("");
            Print("1:공격, 2:회복, 3:도망");
            char userInput = GetAllowedAnswer("1", "2", "3")[0];
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
        }

        private static void Print(string log)
        {
            Console.WriteLine(log);
        }

        private static void MonsterAttackToPlayer(Player player, List<Monster> monsters)
        {
            Print("모든 몬스터가 플레이어 공격");
            foreach (var m in monsters)
            {
                m.OnAttack(player);
            }
        }

        private static void PlayerAttack(Player player, List<Monster> monsters)
        {
            Print("");
            Print("공격할 몬스터를 선택하세요");

            List<string> allowedAnswer = new List<string>();
            for (int i = 0; i < monsters.Count; i++)
            {
                var m = monsters[i];
                int monsterNumber = i + 1;
                Print($"{monsterNumber} : {m.name} 공격력:{m.power}, 체력:{m.hp}");

                allowedAnswer.Add(monsterNumber.ToString());
            }


            int selected;

            string userInput = GetAllowedAnswer(allowedAnswer.ToArray());
            
            selected = int.Parse(userInput) - 1; // 인덱스는 0부터 시작하므로 -1해주자
            
            var selectedMonster = monsters[selected];
            selectedMonster.hp -= player.power;

            Print($"{selectedMonster.name}의 체력이 {selectedMonster.hp}가 되었다");

            // 몬스터가 죽었는가?
            if (selectedMonster.hp <= 0)
            {
                Print($"{selectedMonster.name}이 죽었다");

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

        // Monster와  Player의 ToString을 오버라이드 하여 정보 출력하는 부분을 개선합시다.

        // 광격 공격을 추가 해봅시다.

        // AI동료를 추가해 봅시다.

        // 일정 확률로 반격하는 적을 추가해봅시다.

        // 메인 함수를 이해 하기 쉽도록 단계별로 함수로 묶어 봅시다.
    }
}
