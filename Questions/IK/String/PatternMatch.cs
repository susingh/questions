using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.String
{
    class PatternMatch
    {
        public static int[] KMP(string t, string p)
        {
            return new Algorithm.KMP().FindMatches(t, p);
        }

        private static void NaiveSearch(string t, string p, List<int> points)
        {
            int i = 0;
            while (i < t.Length)
            {
                int k = i;
                int j = 0;
                while (j < p.Length)
                {
                    if (k < t.Length && t[k] == p[j])
                    {
                        k++;
                        j++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (j == p.Length)
                {
                    // found match
                    points.Add(i);
                }


                i++;
            }
        }

    }
}
