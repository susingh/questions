using System.Linq;

namespace Questions.IK.Recursion
{
    class Subsets
    {
        public static string[] generate_all_subsets(string s)
        {
            if (s == null)
            {
                return null;
            }

            char[] output = new char[s.Length];
            return generate_all_subsets(s, 0, output, 0);
        }

        private static string[] generate_all_subsets(string s, int i, char[] output, int j)
        {
            if (i == s.Length)
            {
                return new string[] { new string(output, 0, j) };
            }

            // generate subsets is a binary local decision - at every character we need to decide whether
            // to keep the char in the subset or leave it.

            string[] without = generate_all_subsets(s, i + 1, output, j);
            output[j] = s[i];
            string[] with = generate_all_subsets(s, i + 1, output, j + 1);

            return without.Concat(with).ToArray();
        }

        public static void printSubsetSum(int[] arr, int val)
        {
            int[] output = new int[arr.Length];

        }

        private static void printSubsetSum(int[] arr, int i, int[] output, int j, int sumSoFar, int val)
        {
            if (sumSoFar == val)
            {
                printSum(output, j);
                return;
            }

            if (sumSoFar > val || i == arr.Length)
                return;

            printSubsetSum(arr, i + 1, output, j, sumSoFar, val);

            output[j] = arr[i];
            printSubsetSum(arr, i + 1, output, j + 1, sumSoFar + arr[i], val);
        }

        private static void printSum(int[] arr, int i)
        {
            // do something here.
        }

        private static int printSubsetSum(int[] arr, int i, int remaining)
        {
            if (i == arr.Length)
            {
                if (remaining == 0)
                {
                    return 1;
                }

                return 0;
            }

            return printSubsetSum(arr, i + 1, remaining) + printSubsetSum(arr, i + 1, remaining - arr[i]);
        }
    }
}
