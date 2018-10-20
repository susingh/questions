//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Questions.IK.DP_
//{
//    class Levenshtein
//    {
//        public static int levenshteinDistance(string strWord1, string strWord2)
//        {
//            List<char> word2 = strWord2.ToList();
//            return levenshteinDistance(strWord1, word2, 0);
//         }

//        private static int levenshteinDistance(string strWord1, List<char> word2, int i)
//        {
//            if (strWord1 == new string(word2.to))
//            {
//                return 0;
//            }

//            int operations = 0;
//            if (strWord2.Length == i)
//            {
//                operations++;
//                strWord2 = string.Concat(strWord2, strWord1[i]);
//                operations += levenshteinDistance(strWord1, strWord2, i + 1); 
//            }
//            else if (strWord1[i] != strWord2[i])
//            {
//                operations++;
//                strWord2[i] = strWord1[i];
//            }

//            return operations;
//        }
//    }
//}
