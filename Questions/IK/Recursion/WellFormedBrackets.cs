using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Recursion
{
    class WellFormedBrackets
    {
        public static string[] find_all_well_formed_brackets(int n)
        {
            char[] arr = new char[n * 2];
            List<string> result = new List<string>();
            find_all_well_formed_brackets(arr, 0, result);
            return result.ToArray();
        }

        private static void find_all_well_formed_brackets(char[] arr, int i, List<string> result)
        {
            if (i == arr.Length)
            {
                if (IsWellFormed(arr, i - 1))
                {
                    string val = new string(arr);
                    result.Add(val);
                }
                return;
            }
           
            char[] values = new char[] { '(', ')' };
            foreach (var bracket in values)
            {
                arr[i] = bracket;
                find_all_well_formed_brackets(arr, i + 1, result);
            }
        }

        private static bool IsWellFormed(char[] arr, int j)
        {
            int opened = 0;
            for (int i = 0; i <= j; i++)
            {
                if (arr[i] == ')')
                {
                    opened--;

                    if (opened < 0)
                    {
                        return false;
                    }

                }
                else
                {
                    opened++;
                }
            }

            return opened == 0;
        }
    }
}
