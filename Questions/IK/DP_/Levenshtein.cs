using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.DP_
{
    class Levenshtein
    {
        public static int levenshteinDistance(string strWord1, string strWord2)
        {
            return levenshteinDistance(strWord1, 0, strWord2, 0);
        }

        private static int levenshteinDistance(string w1, int i, string w2, int j)
        {
            if (i == w1.Length && j == w2.Length)
            {
                return 0;
            }

            if (i == w1.Length)
            {
                return w2.Length - j;
            }

            if (j == w2.Length)
            {
                return w1.Length - i;
            }

            if (w1[i] == w2[j])
            {
                return levenshteinDistance(w1, i + 1, w2, j + 1);
            }
            else
            {
                int add = levenshteinDistance(w1, i, w2, j + 1);
                int replace = levenshteinDistance(w1, i+1, w2, j + 1);
                int delete = levenshteinDistance(w1, i + 1, w2, j);

                return 1 + Math.Min(add, Math.Min(replace, delete));
            }
        }



        //private static int levenshteinDistance(List<char> word1, string word2, int i)
        //{
        //    if (i == word2.Length)
        //    {
        //        return 0;
        //    }

        //    if (word1[i] != word2[i])
        //    {
        //        // add
        //        word1.Insert(i, word2[i]);
        //        int distInt = levenshteinDistance(word1, word2, i + 1);
        //        word1.RemoveAt(i);

        //        // replace
        //        char old = word1[i];
        //        word1[i] = word2[i];
        //        int distRep = levenshteinDistance(word1, word2, i + 1);
        //        word1[i] = old;

        //        // remove
        //        char old = word1[i];
        //        word1[i] = word2[i];
        //        int distRep = levenshteinDistance(word1, word2, i + 1);
        //        word1[i] = old;


        //    }

        //    int operations = 0;
        //    if (strWord2.Length == i)
        //    {
        //        operations++;
        //        strWord2 = string.Concat(strWord2, strWord1[i]);
        //        operations += levenshteinDistance(strWord1, strWord2, i + 1);
        //    }
        //    else if (strWord1[i] != strWord2[i])
        //    {
        //        operations++;
        //        strWord2[i] = strWord1[i];
        //    }

        //    return operations;
        //}
    }
}
