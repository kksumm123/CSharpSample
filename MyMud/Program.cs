﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace MyMud
{
    class Program
    {
        static void Main(string[] args)
        {
            // 유저님 환영합니다.
            Console.WriteLine("유저님 환영합니다.");

            string playerRandomName = SetRandomPlayerName();


            // 플레이어 능력치를 입력받자. power, hp
            string powerString = Console.ReadLine();// power
            string hpString = Console.ReadLine(); // hp

            int power = int.Parse(powerString);
            int hp = int.Parse(hpString);

            Player player = new Player(playerRandomName, power, hp);

            // 몬스터 한마리 만들어서 때리자.
            Monster monster = new Monster();
            monster .hp -= player .power;

            Console.WriteLine($"hp:{monster.hp}{1,2},");

        }

        private static string SetRandomPlayerName()
        {
            // 플레이어 이름 랜덤 자동 생성.
            // 숫자 랜덤만 배웠다. -> 지정된 문자 내에서 랜덤으로 생성시키고 싶어, 
            // 1. 문자열 여러개를 미리 설정해두고
            // 2. 거기서 랜덤으로 지정하자.
            List<string> names = new List<string>();  // 89% List, 10 : Dictionary, ,...
            Dictionary<string, string> nameMap = new Dictionary<string, string>(); // 사전, 
            nameMap["찬선"] = "학원강사";
            nameMap["안텐츠"] = "게임 학원";       //
            nameMap.Add("안텐츠", "게임 학원");    // 이미 
            List<int> intList = new List<int>();
            intList.Add(2);
            intList.Add(1);
            intList.Add(3);
            intList.Sort();

            Console.WriteLine(nameMap["안텐츠"]);



            names.Add("동환");    // 0
            names.Add("명수");    // 1
            names.Add("성운");    // 2
            names.Add("성현");    // 3
            names.Add("찬선");    // 4

            Random random = new Random();

            // 0부터 시작하겠구나.
            int index = random.Next(names.Count);
            string playerName = names[index];
            return playerName;


            //int[] myArray = new int[10];///(배열) : 처음 정한 크기 변경불가(단순한 작업에만 이용)
            ////myArray.장점 빠르다.
            //// 단점 :  

            ////ArrayList: 아무타입이나 넣을 수 있고 크기 자유롭게 변함, 살짝 느림(그래서 사용 잘 안함)
            //ArrayList arrayList = new ArrayList();
            //arrayList.Add(1);
            //arrayList.Add("1");
            //arrayList.Add(true);

            //List<int> iList = new List<int>();// (리스트): value를 넣는 일반적인 자료구조, 자주 쓰임, 크기 변경되는 배열로 생각하면됨
            ////iList.Contains
            //iList.Add(1);
            //iList.Add(1);
            //int f = iList[0];
            //iList.RemoveAt(0);

            //int count = iList.Count; // 2;
            //if (iList.Contains(1) == false)
            //    iList.Add(1);

            //Dictionary<int, string> myDic = new Dictionary<int, string>(); // (딕셔너리) : key, value
            ////myDic.Add(2, "2번");
            //string value = myDic[2];
            ////myDic.ContainsKey();
            ////myDic.ContainsValue();

            //HashSet<int> mYset = new HashSet<int>();// (셋) : 리스트와 비슷, 중복을 허용하지 않음
            //mYset.Add(1);
            //mYset.Add(1);
            //count = mYset.Count; // 1

            ////if(mYset.Contains(1))
            //// 1 있다.

            //Stack<int> myStack = new Stack<int>();// (스택): 마지막에 넣은게 뽑힘(LIFO)
            //myStack.Push(1); // add 넣기, 
            //int pop = myStack.Pop(); // 빼기

            //Queue<int> myQueue = new Queue<int>();/// (큐):처음넣은게 뽑힘(FIFO)
            //myQueue.Enqueue(1); // add 넣기
            //int e = myQueue.Dequeue(); // 빼기

            //LinkedList<int> myLinkedList = new LinkedList<int>(); //(링크드리스트):리스트에 자주 넣고 뺄때 유리

        }
    }
}
