using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Sorting
{
    class LexigraphicalOrdering
    {
        public static string[] solve(string[] arr)
        {
            List<string> result = new List<string>();
            Dictionary<string, int> countMap = new Dictionary<string, int>();
            Dictionary<string, string> stringMap = new Dictionary<string, string>();

            foreach (var str in arr)
            {
                string[] parts = str.Split(' ');
                if (!countMap.ContainsKey(parts[0]))
                {
                    countMap[parts[0]] = 1;
                    stringMap[parts[0]] = parts[1];
                }
                else
                {
                    countMap[parts[0]] += 1;
                    if (Compare(stringMap[parts[0]], parts[1]) > 0)
                    {
                        stringMap[parts[0]] = parts[1];
                    }
                }
            }

            foreach (var pair in countMap)
            {
                result.Add($"{pair.Key}:{pair.Value},{stringMap[pair.Key]}");
            }

            return result.ToArray();
        }
        static int Compare(string a, string b)
        {
            int i = 0;
            while (i < a.Length && i < b.Length)
            {
                if (a[i] > b[i])
                {
                    return -1;
                }
                else if (a[i] < b[i])
                {
                    return 1;
                }

                i++;
            }

            if (i == a.Length && i == b.Length)
            {
                return 0;
            }
            else if (i == a.Length)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
