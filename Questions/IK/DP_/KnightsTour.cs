using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.DP_
{
    class KnightsTour
    {
        private static Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>
        {
            { 0, new List<int> { 4, 6 } },
            { 1, new List<int> { 6, 8 } },
            { 2, new List<int> { 7, 9 } },
            { 3, new List<int> { 4, 8 } },
            { 4, new List<int> { 0, 3, 9 } },
            { 5, new List<int> { } },
            { 6, new List<int> {0, 1, 7} },
            { 7, new List<int> {2, 6} },
            { 8, new List<int> {1, 3} },
            { 9, new List<int> {2, 4} },
        };

        public static long numPhoneNumbers(int startdigit, int phonenumberlength)
        {
            //int[] number = new int[phonenumberlength];
            //return numPhoneNumbers(startdigit, phonenumberlength, number, 0);

            return numPhoneNumbersDP(startdigit, phonenumberlength);
        }

        private static long numPhoneNumbers(int startdigit, int phonenumberlength, int[] number, int j)
        {
            number[j] = startdigit;

            if (j == phonenumberlength - 1)
            {
                Console.WriteLine(string.Join("", number));
                return 1;
            }
            
            long numbers = 0;
            foreach (var next in dict[startdigit])
            {
                numbers += numPhoneNumbers(next, phonenumberlength, number, j + 1);
            }

            return numbers;
        }

        private static long numPhoneNumbersDP(int startDigit, int phonenumberlength)
        {
            long[,] dpTable = new long[10, phonenumberlength];
            for (int i = 0; i < 10; i++)
            {
                dpTable[i, phonenumberlength - 1] = 1;
            }

            for (int j = phonenumberlength - 2; j >= 0; j--)
            {
                for (int i = 0; i < 10; i++)
                {
                    long numbers = 0;
                    foreach (var next in dict[i])
                    {
                        numbers += dpTable[next, j + 1];
                    }

                    dpTable[i, j] = numbers;
                }
            }

            return dpTable[startDigit, 0];
        }
    }
}
