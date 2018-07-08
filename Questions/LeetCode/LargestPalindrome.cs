using System;

namespace Questions.LeetCode
{
    public class LargestPalindrome
    {
        public int largestPalindrome(int n)
        {
            int maxN = (int)Math.Pow(10, n) - 1;
            int minN = (int)Math.Pow(10, n-1);
            long maxPalindrome = Int64.MinValue;

            for (int i = maxN; i >= minN; i--)
            {
                for (int j = maxN; j > minN; j--)
                {
                    long product = i * j;

                    if (product > maxPalindrome && isPalidrome(product))
                    {
                        maxPalindrome = product;
                        var newMin = i < j ? i : j;
                        if (newMin > minN)
                        {
                            minN = newMin;
                        }

                        break;
                    }
                }
            }

            return (int)(maxPalindrome % 1337);
        }

        private bool isPalidrome(long value)
        {
            string strValue = value.ToString();
            for (int i = 0, j = strValue.Length - 1; i <= j ; i++, j--)
            {
                if (strValue[i] != strValue[j])
                {
                    return false;
                }
            }

            return true;
        }

        public void Run()
        {
            Console.WriteLine(largestPalindrome(5));
        }
    }
}
