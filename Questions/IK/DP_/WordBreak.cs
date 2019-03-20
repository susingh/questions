using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.DP_
{
    class WordBreak
    {
        static string[] wordBreak(string strWord, string[] strDict)
        {
            List<string> result = new List<string>();
            HashSet<string> dict = new HashSet<string>(strDict);
            wordBreak(0, strWord, dict, result, string.Empty);
            return result.ToArray();
        }

        static void wordBreak(int i, string strWord, HashSet<string> strDict, List<string> result, string curr)
        {
            if (i >= strWord.Length)
            {
                curr = curr.TrimEnd(' ');
                result.Add(curr);
                return;
            }

            int e = 0;
            // find the next break
            while (e < strWord.Length)
            {
                string str = strWord.Substring(i, e - i + 1);
                if (strDict.Contains(str))
                {
                    curr += str + " ";
                }

                e++;
            }
        }
    }
}
