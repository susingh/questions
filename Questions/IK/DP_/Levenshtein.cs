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
            List<char> word1 = strWord1.ToList();
            return levenshteinDistance(word1, strWord2, 0);
        }

        private static int levenshteinDistance(List<char> word1, string word2, int i)
        {
            if (i == word2.Length)
            {
                return 0;
            }

            if (word1[i] != word2[i])
            {
                // add
                word1.Insert(i, word2[i]);
                int distInt = levenshteinDistance(word1, word2, i + 1);
                word1.RemoveAt(i);

                // replace
                char old = word1[i];
                word1[i] = word2[i];
                int distRep = levenshteinDistance(word1, word2, i + 1);
                word1[i] = old;

                // remove
                char old = word1[i];
                word1[i] = word2[i];
                int distRep = levenshteinDistance(word1, word2, i + 1);
                word1[i] = old;


            }

            int operations = 0;
            if (strWord2.Length == i)
            {
                operations++;
                strWord2 = string.Concat(strWord2, strWord1[i]);
                operations += levenshteinDistance(strWord1, strWord2, i + 1);
            }
            else if (strWord1[i] != strWord2[i])
            {
                operations++;
                strWord2[i] = strWord1[i];
            }

            return operations;
        }
    }
}
