using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.LinkedList
{
    public class BalancedParenthesis
    {

        //public static int find_max_length_of_matching_parentheses(string brackets)
        //{
        //    char[] arr = brackets.ToCharArray();
        //    Stack<int> stack = new Stack<int>();
        //    int maxLength = 0;

        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        if (arr[i] == '(')
        //        {
        //            stack.Push(i);
        //        }
        //        else
        //        {
        //            if (stack.Count != 0)
        //            {
        //                int index = stack.Pop();
        //                maxLength = Math.Max(maxLength, i - index + 1);
        //            }
        //        }
        //    }
        //}

        //public static int find_max_length_of_matching_parentheses(string brackets)
        //{
        //    // generate all possible combinations of a string.
        //    // check if the string is valid
        //    // keep a track of the maximum length of string.

        //    char[] arr = brackets.ToCharArray();
        //    int maxLength = int.MinValue;

        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        for (int j = i; j < arr.Length; j++)
        //        {
        //            if (IsValid(arr, i, j))
        //            {
        //                int length = j - i + 1;
        //                maxLength = Math.Max(maxLength, length);
        //            }
        //        }
        //    }

        //    return maxLength;
        //}

        //public static int find_max_length_of_matching_parentheses(string brackets)
        //{
        //    // Keep minimum two items in the window.
        //    // if the window is valid, expand the window by two
        //    // expand the window on either side by one Or expand the window on right side by 2.
        //    // check if the string is valid
        //    // keep a track of the maximum length of string.

        //    char[] arr = brackets.ToCharArray();
        //    int maxLength = 0;

        //    if (arr.Length == 1)
        //        return maxLength;

        //    for (int i = 0; i < arr.Length - 1; i++)
        //    {
        //        int j = i + 1;
        //        if (IsValid(arr, i, j))
        //        {
        //            int length = end - start + 1;
        //            maxLength = Math.Max(maxLength, length);

        //            // start expanding
        //            while (i >= 0 && j < arr.Length)
        //            {
        //                if (IsValid())
        //            }
        //        }
        //        int maxSubstringLength = FindMaxSubstringLength(arr, i, i + 1);
        //        maxLength = Math.Max(maxLength, maxSubstringLength);
        //    }

        //    return maxLength;
        //}

        //private static int FindMaxSubstringLength(char[] arr, int start, int end)
        //{
        //    int maxLength = 0;
        //    if (IsValid(arr, start, end))
        //    {
        //        int length = end - start + 1;
        //        maxLength = Math.Max(maxLength, length);

        //        int i = start - 1;
        //        int j = end + 1;

        //        while (i >= 0 && j < arr.Length)
        //        {
        //            if (IsValid(arr, i, j))
        //            {
        //                length = j - i + 1;
        //                maxLength = Math.Max(maxLength, length);
        //            }

        //            i--;
        //            j++;
        //        }
        //    }
        //}

        //private static int FindMaxSubstringLength(char[] arr, int start, int end)
        //{
        //    if (start < 0 || end >= arr.Length)
        //    {
        //        return 0;
        //    }

        //    int maxLength = 0;
        //    if (IsValid(arr, start, end))
        //    {
        //        int length = end - start + 1;
        //        maxLength = Math.Max(maxLength, length);

        //        int eitherSideLength = FindMaxSubstringLength(arr, start - 1, end + 1);
        //        int rightSideLength = FindMaxSubstringLength(arr, start, end + 2);

        //        int maxExpantional = Math.Max(eitherSideLength, rightSideLength);
        //        maxLength = Math.Max(maxExpantional, maxLength);
        //    }

        //    return maxLength;
        //}

        private static bool IsValid(char[] arr, int start, int end)
        {
            int opened = 0;
            for (int i = start; i <= end; i++)
            {
                if (arr[i] == '(')
                {
                    opened++;
                }
                else
                {
                    opened--;
                }

                if (opened < 0)
                {
                    return false;
                }
            }

            return opened == 0;
        }
    }
}
