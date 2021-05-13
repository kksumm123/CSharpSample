using System;

namespace Sort_버블정렬
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = { 1, 5, -1, 4, 0};

            for (int turn = 0; turn < intArray.Length; turn++)
            {
                int fixCount = turn;
                int checkLength = intArray.Length - fixCount - 1;
                checkLength = checkLength - 1;// 오른쪽 왼쪽을 한쌍으로 검사하므로 최대길이 -1까지만 검사하면 된다

                for (int x = 0; x < checkLength; x++)
                {
                    int left = intArray[x];
                    int right = intArray[x + 1];
                    if (left > right)
                        Swap(x, intArray);
                }
            }

            foreach (var item in intArray)
                Console.WriteLine(item);
        }

        private static void Swap(int index, int[] intArray)
        {
            int leftIndex = index;
            int rightIndex = index + 1;

            int temp = intArray[leftIndex];
            intArray[leftIndex] = intArray[rightIndex];
            intArray[rightIndex] = temp;
        }
    }
}
