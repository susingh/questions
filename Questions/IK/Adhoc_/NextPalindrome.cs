//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Questions.IK.Adhoc_
//{
//    class NextPalindrome
//    {
//        // 234897 432902 2147447411
//        public static long next_palindrome(int n)
//        {
//            int[] arr = Build(n+1);

//            int i = 0, j = arr.Length - 1;

//            while (i <= j)
//            {
//                if (arr[i] != arr[j])
//                {
//                    // make them same, but higher
//                    arr[j] = arr[i];
//                    int num = Build(arr);
                    
//                    if (num < n)
//                    {
//                        arr[i]++;
//                    }
//                    else
//                    {
//                        i++;
//                        j--;
//                    }
//                }
//                else
//                {
//                    i++;
//                    j--;
//                }
//            }
//        }

//        private static int[] Build(int n)
//        {

//        }

//        private static int Build (int[] arr)
//    }
//}
