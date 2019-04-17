namespace Questions.IK.Adhoc_
{
    class NextPalindrome
    {
        private static int GetValue(char[] s, int i, int j)
        {
            int val = 0;
            for (int k = i; k <= j; k++)
            {
                val = val * 10 + (s[k] - '0');
            }
            return val;
        }

        private static char[] GetString(long n)
        {
            return n.ToString().ToCharArray();
        }

        private static bool Increment(char[] s, int i)
        {
            int curr = s[i] - '0';
            bool overflow = false;
            curr++;
            if (curr == 10)
            {
                curr = 0;
                overflow = true;
            }
            s[i] = curr.ToString().ToCharArray()[0];
            return overflow;
        }

        public static long next_palindrome(int n)
        {
            long newNumber = n + 1;

            char[] s = GetString(newNumber);

            int i = 0;
            int j = s.Length - 1;

            bool isGreater = newNumber > n;

            while (i <= j)
            {
                if (i == j)
                {
                    while (!isGreater)
                    {
                        bool overflow = Increment(s, i);
                        if (overflow)
                        {
                            i = i - 2;
                            j = j + 2;
                        }
                        else
                        {
                            newNumber = GetValue(s, 0, s.Length - 1);
                            isGreater = newNumber > n;
                        }
                    }
                }
                else if (i + 1 == j)
                {
                    s[j] = s[i];
                    newNumber = GetValue(s, 0, s.Length - 1);
                    isGreater = newNumber > n;

                    while (!isGreater)
                    {
                        Increment(s, i);
                        Increment(s, j);
                        newNumber = GetValue(s, 0, s.Length - 1);

                        isGreater = newNumber > n;
                    }
                }
                else if (s[i] != s[j])
                {
                    // do something to fix the numbers
                    s[j] = s[i];
                    newNumber = GetValue(s, 0, s.Length - 1);
                    isGreater = newNumber > n;
                }

                i++;
                j--;
            }

            return newNumber;
        }

        //    // 234897 432902 2147447411
        //    //public static long next_palindrome(int n)
        //    {
        //        int[] arr = Build(n + 1);

        //        int i = 0, j = arr.Length - 1;

        //        while (i <= j)
        //        {
        //            if (arr[i] != arr[j])
        //            {
        //                // make them same, but higher
        //                arr[j] = arr[i];
        //                int num = Build(arr);

        //                if (num < n)
        //                {
        //                    arr[i]++;
        //                }
        //                else
        //                {
        //                    i++;
        //                    j--;
        //                }
        //            }
        //            else
        //            {
        //                i++;
        //                j--;
        //            }
        //        }
        //    }

        //    private static int[] Build(int n)
        //    {

        //    }

        //    private static int Build(int[] arr)
        //}
    }

}