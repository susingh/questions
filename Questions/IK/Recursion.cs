using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK
{
    class RecursionOld : IQuestion
    {
        /*
         * Original permutation problem
         */
        void Permute(char[] arr)
        {
            Permute(arr, 0);
        }

        void Permute(char[] arr, int i)
        {
            if (i == arr.Length - 1)
            {
                Print(arr);
                return;
            }

            for (int j = i; j < arr.Length; j++)
            {
                Swap(arr, i, j);
                Permute(arr, i + 1);
                Swap(arr, i, j);
            }
        }

        void Swap<T>(T[] arr, int i, int j)
        {
            T temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        void Print(char[] arr)
        {
            Console.WriteLine(arr);
        }

        void Print(int[] arr)
        {
            foreach (var item in arr)
                Console.Write(item);

            Console.WriteLine();
        }

        /*
         * Assume that the input is an array of size 'n' where 'n' is an even number. 
         * Additionally, assume that half the integers are even and the other half are odd. 
         * Print only those permutations where odd and even integers alternate, starting with odd.
         */

        void PermuteOddEven(int[] arr)
        {
            PermuteOddEven(arr, 0, false);
        }

        void PermuteOddEven(int[] arr, int i, bool isEven)
        {
            if (i == arr.Length - 1)
            {
                Print(arr);
                return;
            }

            for (int j = i; j < arr.Length; j++)
            {
                if (isEven && arr[j] % 2 != 0 ||
                    !isEven && arr[j] % 2 == 0)
                {
                    continue;
                }

                Swap(arr, i, j);
                PermuteOddEven(arr, i+1, !isEven);
                Swap(arr, i, j);
            }
        }

        /*
         * Assume that the input is an array of characters. 
         * Print any one permutation that is also a word in the dictionary. Assume that you have two library functions you can use.
         * 
         * bool ValidWord(char array a) returns true if and only if the string a is a dictionary word.
         * bool ValidWordPrefix(char array a, int a_size) returns true if and only if a[0...a_size-1] is a prefix of at least one word in the dictionary
         */
       
        void PermuteValidWord(char[] arr)
        {
            PermuteValidWord(arr, 0);
        }

        bool PermuteValidWord(char[] arr, int i)
        {
            bool found = false;

            if (i == arr.Length - 1)
            {
                if (ValidWord(arr))
                {
                    Print(arr);
                    found = true;
                }
            }
            else
            {
                for (int j = i; j < arr.Length; j++)
                {
                    Swap(arr, i, j);
                    if (ValidWordPrefix(arr, i+1))
                    {
                        found = PermuteValidWord(arr, i + 1);
                        if (found)
                        {
                            break;
                        }
                    }
                    Swap(arr, i, j);
                }
            }

            return found;
        }

        bool ValidWord(char[] arr)
        {
            string a = new string(arr);
            return (a == "cat");
        }

        bool ValidWordPrefix(char[] arr, int a_size)
        {
            string a = new string(arr, 0, a_size);
            return (a == "c" || a == "ca");
        }

        void PermuteSet(char[] arr)
        {
            char[] s = new char[arr.Length];
            PermuteSet(arr, 0, s, 0);
        }

        void PermuteSet(char[] a, int i, char[] s, int j)
        {
            if (i == a.Length)
            {
                Print(s, j);
                return;
            }

            PermuteSet(a, i + 1, s, j);
            s[j] = a[i];
            PermuteSet(a, i + 1, s, j+1);
        }

        void Print<T>(T[] arr, int j)
        {
            for (int i = 0; i < j; i++)
            {
                Console.Write(arr[i]);
            }

            Console.WriteLine();
        }

        void PermuteSetOfSum(int[] input, int sum)
        {
            int[] output = new int[input.Length];
            PermuteSetOfSum(input, 0, output, 0, 0, sum);
        }

        void PermuteSetOfSum(int[] input, int i, int[] output, int j, int sum_so_far, int sum)
        {
            if (sum_so_far == sum)
            {
                Print(output, j);
                return;
            }

            if (sum_so_far > sum || i == input.Length) 
            {
                return;
            }

            PermuteSetOfSum(input, i + 1, output, j, sum_so_far, sum);
            output[j] = input[i];
            PermuteSetOfSum(input, i + 1, output, j + 1, sum_so_far + input[i], sum);
        }

        int SubsetSum(int[] output, int j)
        {
            int sum = 0;
            for (int i = 0; i < j; i++)
            {
                sum += output[i];
            }
            return sum;
        }

        int CodePaths(int[,] grid)
        {
            return CodePaths(grid, 0, 0);
        }

        int CodePaths(int[,] grid, int row, int col)
        {
            int numRows = grid.GetLength(0);
            int numCols = grid.GetLength(1);

            if (row == numRows -1 && col == numCols-1)
            {
                return 1;
            }

            if (row >= numRows || col >= numCols)
            {
                return 0;
            }

            int rightPaths = CodePaths(grid, row, col + 1);
            int leftPaths = CodePaths(grid, row+1, col);
            return rightPaths + leftPaths;
        }
        
        // 222, target = 24; 2+22, 22+2
        static string[] generate_all_expressions(string s, long target)
        {
            //List<string> result = new List<string>();
            char[] output = new char[s.Length * 2];
            return generate_all_expressions(s, 0, output, 0, target);
        }

        static string[] generate_all_expressions(string input, int i, char[] output, int j, long target)
        {
            // base case
            if (i == input.Length - 1)
            {
                // add the last digit from the input
                output[j] = input[i];

                if (IsTarget(output, j, target))
                {
                    string outStr = new string(output, 0, j+1);
                    outStr = outStr.Replace("\"", string.Empty);
                    return new string[] { outStr }; 
                }

                return new string[0];
            }

            output[j++] = input[i];

            output[j] = '"';
            string[] withSpace = generate_all_expressions(input, i + 1, output, j + 1, target);

            output[j] = '+';
            string[] withPlus = generate_all_expressions(input, i + 1, output, j + 1, target);

            output[j] = '*';
            string[] withMultiple = generate_all_expressions(input, i + 1, output, j + 1, target);

            return withSpace.Concat(withPlus).Concat(withMultiple).ToArray();
        }

        static bool IsTarget(char[] arr, int j, long target)
        {
            //long value = 0;

            for (int i = 1; i < j; i++)
            {
                if (arr[i] == '"')
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(arr[i - 1]);
                    builder.Append(arr[i + 1]);
                    //value += int.Parse(builder.ToString());
                }
            }

            //Expression.Lambda()


            string val = new string(arr, 0, j+1);
            //val = val.Remove('"', '');

            return (val == "2+2\"2" || val == "2\"2+2");

            //return value == target;
        }

        int SubsetSumCount(int[] arr, int k)
        {
            return SubsetSumCount(arr, 0, k);
        }

        int SubsetSumCount(int[] input, int i, int sum)
        {
            if (sum == 0)
            {
                return 1;
            }

            if (i == input.Length)
            {
                return 0;
            }

            int sumWithout = SubsetSumCount(input, i + 1, sum);
            int sumWith = SubsetSumCount(input, i + 1, sum - input[i]);

            return sumWith + sumWithout;
        }

        static string[][] find_all_arrangements(int n)
        {
            int[] placement = new int[n];
            List<int[]> result = new List<int[]>();
            find_all_arrangements(placement, 0, result);
            return Transform(result);
        }

        static string[][] Transform(List<int[]> result)
        {
            List<string[]> value = new List<string[]>();

            for (int i = 0; i < result.Count; i++)
            {
                string[] values = new string[result[i].Length];

                for (int j = 0; j < values.Length; j++)
                {
                    char[] oneString = new char[values.Length];
                    for (int k = 0; k < oneString.Length; k++)
                    {
                        oneString[k] = '-';
                    }

                    oneString[result[i][j]] = '1';

                    values[j] = new string(oneString);
                }

                value.Add(values);
            }

            return value.ToArray();
        }

        static void find_all_arrangements(int[] arr, int r, List<int[]> result)
        {
            if (r == arr.Length)
            {
                Console.WriteLine(string.Join(",", arr));
                result.Add((int[])arr.Clone());
                return;
            }

            for (int c = 0; c < arr.Length; c++)
            {
                arr[r] = c;

                if (IsSafe(arr, r))
                {
                    find_all_arrangements(arr, r + 1, result);
                }
            }
        }

        static bool IsSafe(int[] arr, int r)
        {
            for (int i = 0; i <= r-1; i++)
            {
                if (i == r) return false;
                if (arr[i] == arr[r]) return false;
                if (Math.Abs(i - r) == Math.Abs(arr[i] - arr[r])) return false;
            }

            return true;
        }


        static bool check_if_sum_possible(long[] arr, long k)
        {
            return check_if_sum_possible(arr, 0, k, isEmpty: true);
        }

        static bool check_if_sum_possible(long[] input, int i, long sum, bool isEmpty)
        {
            if (sum == 0 && !isEmpty)
            {
                return true;
            }

            if (i == input.Length)
            {
                return false;
            }

            return check_if_sum_possible(input, i + 1, sum, isEmpty: false) || check_if_sum_possible(input, i + 1, sum - input[i], isEmpty: false);
        }


        static string[] find_all_well_formed_brackets(int n)
        {
            char[] arr = new char[n * 2];
            return find_all_well_formed_brackets(arr, 0);
        }

        static string[] find_all_well_formed_brackets(char[] output, int i)
        {
            // base case    
            if (i == output.Length)
            {
                if (IsWellFormed(output))
                {
                    return new string[] { new string(output) };
                }

                return new string[0];
            }

            List<string> result = new List<string>();

            // recurse
            output[i] = '(';
            string[] leftBracket = find_all_well_formed_brackets(output, i + 1);

            output[i] = ')';
            string[] rightBracket = find_all_well_formed_brackets(output, i + 1);

            return leftBracket.Concat(rightBracket).ToArray();
        }

        static bool IsWellFormed(char[] output)
        {
            int opened = 0;
            for (int i = 0; i < output.Length; i++)
            {
                if (output[i] == '(')
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

        

        static long how_many_BSTs(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            n--;

            if (n == 0)
            {
                return 1;
            }

            long count = 0;
            for (int i = 0; i <= n; i++)
            {
                count += how_many_BSTs(i);
                count += how_many_BSTs(n-i);
            }

            return count;
        }
       
        public void Run()
        {
            //Permute(new char[] {'a', 'c', 'e', 'f' });
            //PermuteOddEven(new int[] { 1, 2, 4, 5, 3, 6 });
            //PermuteValidWord(new char[] { 'a', 't', 'c' });
            //PermuteSet(new char[] { 'a', 't', 'c' , 'o'});
            //PermuteSetOfSum(new int[] { 1, 3, 4, 6, 2 }, 5);

            //var grid = new int[1,2] { { 0, 0 } };
            //var result = CodePaths(grid);

            var result = generate_all_expressions("222", 24);

            //var result = SubsetSumCount(new int[] { 5, 6, 8, 4, 10, 13 }, 18);

            //var result = find_all_arrangements(4);
            //var result = check_if_sum_possible(new long[] { 2, 4, 8, 12 }, 0);

            //var result = find_all_well_formed_brackets(2);

            //var result = how_many_BSTs(3);

            //var result = generate_all_subsets("");

        }
    }
}
