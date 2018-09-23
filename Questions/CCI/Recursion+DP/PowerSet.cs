using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.CCI.Recursion_DP
{
    class PowerSet
    {
        public static void Subsets(int[] set)
        {
            //int[] result = new int[set.Length];
            Stack<int> result = new Stack<int>();
            Subsets(set, 0, result);
        }

        private static void Subsets (int[] set, int i, Stack<int> result)
        {
            if (i == set.Length)
            {
                PrintSet(result);
                return;
            }

            Subsets(set, i + 1, result);
            result.Push(set[i]);
            Subsets(set, i + 1, result);
            result.Pop();
        }

        private static void PrintSet(Stack<int> result)
        {
            Console.Write("{");
            foreach (var item in result)
            {
                Console.Write(item);
            }

            Console.Write("}");
            Console.WriteLine();
        }
    }
}
