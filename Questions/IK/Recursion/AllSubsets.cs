using System.Linq;

namespace Questions.IK.Recursion
{
    class AllSubsets
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
    }
}
