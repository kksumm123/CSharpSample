using System;
using System.Collections.Generic;

namespace 머드게임
{
    public enum TypeOfStats
    {
        Power,
        hp,
    }
    class Program
    {
        static Random random = new Random();
        // 머드게임을 만들면서 클래스에 대해서 배워봅시다.
        // 왜 new를 할까? static 변수와 static클래스 만으로 구현할 수 없는 건가?
        static void Main(string[] args)
        {
            Print("바람의 킹덤 Ver0.16");

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

            Print(player + " : logTest");
            return player;
        }

        private static bool ProcessBattle(Player player)
        {
            int dungeonLevel = 1;

            do
            {
                
                int monsterCount = random.Next(1, 3); // 1 ~ 2개(최소값은 포함해도 최대값은 포함하지 않음) 
                List<Monster> monsters = new List<Monster>(); // 몬스터 스폰, 리젠
                //for (int i = 0; i < monsterCount; i++)
                //{
                //    monsters.Add(new Monster(dungeonLevel));
                //}

                //monsters.Add(new DoubleBladeSlime(dungeonLevel));
                monsters.Add(new CounterAttackTroll(dungeonLevel));

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

                while (monsters.Count > 0)
                {
                    Print("");
                    Print("몬스터 정보 출력");
                    // 몬스터 정보 출력.
                    foreach (var m in monsters)
                    {
                        Print(m);// ToString을 오버라이드 하여 간단히 표현하자.
                        //Print($"{m.name} 공격력:{m.power}, 체력:{m.hp}");
                    }

                    // 유저 정보 출력.
                    Print(player);

                    //유저 행동.
                    PlayerTurn(player, monsters);

                    // 몬스터가 플레이어를 공격.
                    MonsterTurn(player, monsters);


                    // 플레이어 죽었다면 게임 끝내자.
                    if (player.hp <= 0)
                    {
                        Print($@"{player.DisplayName}는 사망했습니다.
GameOver
처음부터 하시겠습니까?(R)etry/(Q)uit");

                        // (R)etry/(Q)uit
                        bool isQuit = GetAllowedAnswer("R", "Q") == "Q";
                        return isQuit;
                    }
                }

                Print($@"던전 탐험을 종료하시겠습니까?(Y)es/(N)o");
                if (GetAllowedAnswer("Y", "N") == "Y")
                {
                    Print($@"용사가 이겼습니다. 점수 : {player.score}");
                    return true;
                }
            

                // 모든 몬스터를 죽였으므로 던전 레벨 증가
                dungeonLevel++;

            } while (true);// 무한 반복. 나가는 조건은 나갈 것인가 묻는 조건에 q라고 입력해야함.
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

            // 몬스터 HP회복 진행.
            MonsterRestoreHp(monsters);

            // 몬스터가 플레이어 때리는 과정 진행
            MonsterAttackToPlayer(player, monsters);
        }

        /// <summary>
        /// 몬스터의 HP회복.
        /// </summary>
        /// <param name="monsters"></param>
        private static void MonsterRestoreHp(List<Monster> monsters)
        {
            foreach (var item in monsters)
            {
                string log = item.ToString();
                item.hp += 1;
                Console.WriteLine($"{log} 현재 HP : {item.hp}");
            }
        }

        enum AttackType
        {
            Normal,
            광역공격,
        }
        private static void PlayerTurn(Player player, List<Monster> monsters)
        {
            Print("");
            Print("1:공격, 2:광역공격, 3:회복, 3:도망");
            char userInput = GetAllowedAnswer("1", "2", "3", "4")[0];
            switch (userInput)
            {
                case '1':// 공격
                    PlayerAttack(player, monsters);
                    break;
                case '2': // 광역 공격
                    PlayerAttack(player, monsters, AttackType.광역공격);
                    break;
                case '3': // 회복
                    player.RestoreHp();
                    break;
                case '4': // 도망.
                    bool successRun = TryRun();
                    break;
                default:
                    Print("없는 명령어 입니다" + userInput);
                    break;
            }
        }

        private static void Print(Object log)
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

        private static void PlayerAttack(Player player, List<Monster> monsters, AttackType attackType = AttackType.Normal)
        {
            // 공
            switch (attackType)
            {
                case AttackType.Normal:
                    NormalAttack(player, monsters);
                    break;
                case AttackType.광역공격:
                    광역공격(player, monsters);
                    break;
            }

            static void NormalAttack(Player player, List<Monster> monsters)
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
                selectedMonster.OnHit(player.power, player);

                // 몬스터가 죽었는가?
                OnMonsterDie(player, monsters, selectedMonster);
            }

            static void 광역공격(Player player, List<Monster> monsters)
            {
                // 모든 몬스터를 때린다.
                var mostersTemp = monsters.ToArray();
                foreach (var monster in mostersTemp)
                {
                    monster.OnHit(player.power, player);

                    OnMonsterDie(player, monsters, monster);
                }

                // 모든 몬스터를 때린다.
                //List<Monster> deleteMonsters = new List<Monster>();
                //foreach (var monster in monsters)
                //{
                //    monster.OnHit(player.power, player);

                //    Monster dieMonster = OnMonsterDie(player, monsters, monster);
                //    if (dieMonster != null)
                //        deleteMonsters.Add(dieMonster);
                //}
                //deleteMonsters.ForEach(x => monsters.Remove(x));
            }
        }

        private static Monster OnMonsterDie(Player player, List<Monster> monsters, Monster monster)
        {
            if (monster.hp <= 0)
            {
                Print($"{monster.name}이 죽었다");
                monsters.Remove(monster);

                // [완료]몬스터 죽일시 경험치 획득 
                player.score += 1; // player.score++ 과 동일
                player.GetExp(monster.getExp);

                Random random = new Random();
                double ratio = random.NextDouble();
                if (ratio < 0.5)
                {
                    // todo : [랜덤]아이템 획득
                    GetItem(player);
                }

                return monster;
            }

            return null;
        }


        static List<Item> dropItems = new List<Item>
        {
            new Item(TypeOfStats.Power, 1)
            ,new Item(TypeOfStats.Power, 2)
            , new Item(TypeOfStats.hp, 3)
            , new Item(TypeOfStats.Power, 4)
        };

        private static void GetItem(Player player)
        {
            // Item 클래스 필요(이름, 능력치(hp, power))
            // Player한테는 여러개의 아이템을 장착 가능하도록
            Random random = new Random();
            var selectedRandomItem = dropItems[random.Next(dropItems.Count)];
            player.AddItem(selectedRandomItem);
        }

        private static bool TryRun()
        {
            int result = random.Next(0, 10);
            bool successRun = result > 3;
            return successRun;
        }

        // [완료] Monster와  Player의 ToString을 오버라이드 하여 정보 출력하는 부분을 개선합시다.

        // [완료] 광격 공격을 추가 해봅시다. - 플레이어가 광역공격. -. 스킬

        // [완료] :일정 확률로 반격하는 적을 추가해봅시다.

        // Todo:AI동료를 추가해 봅시다.

        // 메인 함수를 이해 하기 쉽도록 단계별로 함수로 묶어 봅시다.

    }
}
