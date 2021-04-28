using System;

namespace enum과_swich
{

    // enum 버전
    class Program
    {
        enum Weekly
        {
            월,화,수,목,금,토,일
        }
        static void Main(string[] args)
        {   
            Weekly 오늘은무슨요일이지 = Weekly.월;
            switch (오늘은무슨요일이지)
            {
                case Weekly.월:
                case Weekly.화:
                case Weekly.수:
                case Weekly.목:
                case Weekly.금:
                    Console.WriteLine("학원가는날");
                    break;
                case Weekly.토:
                case Weekly.일:
                    Console.WriteLine("빡세게 자습하는날");
                    break;
            }
        }
    }
    //class Program
    //{
    //    // 월 : 0, 화 : 1, 수 : 2, 목 : 3, 금 : 4, 토 : 5, 일 : 6 
    //    static void Main(string[] args)
    //    {
    //        int dayOfweekly; // 오늘의 요일을 넣자.
    //        dayOfweekly = 1; // 1일 월요일인지? 0월요일인지? 동료랑 같이 일함

    //        switch (dayOfweekly)
    //        {
    //            case 0:
    //            case 1:
    //            case 2:
    //            case 3:
    //            case 4:
    //                Console.WriteLine("학원가는날");
    //                break;
    //            case 5:// 토요일
    //            case 6:// 일요일
    //                Console.WriteLine("쉬는날");
    //                break;
    //        }
    //    }
    //}
}
