using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.DP_
{
    class WordBreak
    {
        public static List<string>  solver(List<string> dictionary, string txt)
        {
            HashSet<string> dict = new HashSet<string>(dictionary);

            List<string> result = new List<string>();
            Stack<string> path = new Stack<string>();

            wordBreak(0, txt, dict, path, result);

            return result;
        }

        static void wordBreak(int start, string strWord, HashSet<string> strDict, Stack<string> path, List<string> result)
        {
            if (start == strWord.Length)
            {
                var list = path.ToList();
                list.Reverse();
                result.Add(string.Join(" ", list));
                return;
            }

            int i = start;
            {
                for (int j = i; j < strWord.Length; j++)
                {
                    string temp = strWord.Substring(i, j - i + 1);
                    if (strDict.Contains(temp))
                    {
                        path.Push(temp);
                        wordBreak(j + 1, strWord, strDict, path, result);
                        path.Pop();
                    }
                }
            }
        }
    }
}
