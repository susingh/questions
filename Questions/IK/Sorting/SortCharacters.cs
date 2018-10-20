using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Sorting
{
    class SortCharacters
    {
        public static string sortCharacters(string inString)
        {
            char[] input = inString.ToCharArray();
            var bytes = Encoding.ASCII.GetBytes(input);
            int[] charArr = new int[128];
            foreach (var b in bytes)
            {
                charArr[b] = charArr[b] + 1;
            }

            int inputStart = 0;
            for (int i = 0; i < charArr.Length; i++)
            {
                for (int j = 0; j < charArr[i]; j++)
                {
                    input[inputStart++] = (char)i;
                }
            }

            return new string(input);
        }
    }
}
