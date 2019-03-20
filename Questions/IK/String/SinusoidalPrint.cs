using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.String
{
    class SinusoidalPrint
    {
        static void print_string_sinusoidally(string s)
        {
            char[][] arr = new char[3][];

            for (int r = 0; r < 3; r++)
            {
                arr[r] = new char[s.Length];

                for (int c = 0; c < s.Length; c++)
                {
                    arr[r][c] = ' ';
                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                int r = (i + 1) % 3;
                arr[r][i] = s[i];
            }

            Console.WriteLine(new string(arr[0]));
            Console.WriteLine(new string(arr[1]));
            Console.WriteLine(new string(arr[2]));
        }
    }
}
