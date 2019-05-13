using Questions.IK;
using Questions.IK.Adhoc_;
using Questions.IK.DP_;
using Questions.IK.Graph;
using Questions.IK.String;
using Questions.IK.Tree;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //var solution = new GroupingDishes();
            //var solution = new FirstDuplicate();
            //var solution = new FirstNotRepeatingCharacter();
            //var solution = new RemoveKFromList();
            //var solution = new AddTwoNumbers();
            //var solution = new ReverseInteger();
            //var solution = new LargestPalindrome();
            //var solution = new Primes();
            //var solution = new Palindrome();
            //var solution = new Heaters();
            //var solution = new Reverse_String();
            //var solution = new MaxDepthOfTree();
            //var solution = new Romans();
            //IQuestion solution = new BuildBST();
            //IQuestion solution = new HappyNumber();
            //var solution = new PascalsTriangle();

            ///var solution = new DeleteMiddleNode();
            //var solution = new PartitionList();

            //var solution = new SumOfLists();
            //var solution = new ListLoop();
            //var solution = new Bitwise();
            var solution
                //= new ElementInCircularRotated();
                // = new SortingDriver();
                 // = new LinkedListDriver();
                //= new LinkedListDriverGFG();
                // = new SortingDriverGFG();
                // = new IK.Recursion.RecursionDriver();
                // = new Trees();
                // = new DP();
                //= new Graphs();
                // = new Strings();
                //= new Adhoc();
                //= new ProducerConsumerDriver();
                // = new ObjectPoolDriver();
                // = new ReaderWriterLockDriver();
                // = new BoundedHashSetDriver();
                // = new GraphDriver();
                // = new StringDriver();
                // = new   AdhocDriver();
                 // = new TreeDriver();
                // = new BitDriver();
                // = new MathDriver();
                = new DPDriver();
                //= new CCI.Recursion_DP.RecursionDriver();
                // = new StacksQueuesDriver();
                // = new StringDriverGFG();
                

            solution.Run();
            Console.ReadKey();
        }
    }
    
    public class Solution11
    {
        public int FindUnsortedSubarray(int[] nums)
        {
            if (nums == null)
            {
                return 0;
            }
            else if (nums.Length == 0)
            {
                return 0;
            }

            int? startIndex = null;
            int? endIndex = null;

            for (int i = 0, j = nums.Length; i < nums.Length && j >= 0; i++, j--)
            {
                if (i > 0 && nums[i] < nums[i - 1])
                {
                    for (int k = i - 1; k >= 0; k--)
                    {
                        if (nums[k] > nums[i])
                        {
                            startIndex = k;
                        }
                    }
                }

                if (j < nums.Length - 2 && nums[j] > nums[j + 1])
                {
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        if (nums[k] < nums[j])
                        {
                            endIndex = k;
                        }
                    }
                }
            }

            if (endIndex.HasValue && startIndex.HasValue)
            {
                return endIndex.Value - startIndex.Value + 1;
            }
            else
            {
                return 0;
            }
            
        }

        public int FindUnsortedSubarray2(int[] nums)
        {
            if (nums == null)
            {
                return 0;
            }
            else if (nums.Length == 0)
            {
                return 0;
            }

            int startIndex = -1;
            int endIndex = startIndex;

            for (int i = 0; i < nums.Length; i++)
            {
                // find the index where the order is broken
                if (i > 0 && nums[i] < nums[i - 1])
                {
                    for (int k = i; k < nums.Length; k++)
                    {
                        if (nums[k] == nums[i])
                        {
                            endIndex = k;
                        }
                    }

                    // travel backwards to find the start
                    if (startIndex == -1)
                    {
                        for (int j = i - 1; j >= 0; j--)
                        {
                            if (nums[j] > nums[i])
                            {
                                startIndex = j;
                            }
                        }
                    }
                }                
            }

            if (startIndex == -1 && endIndex == -1)
            {
                return 0;
            }
            else
            {
                return endIndex - startIndex + 1;
            }
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    

    public class Solution8
    {
        public int MaxRotateFunction(int[] A)
        {
            int maxValue = int.MinValue;

            if (A.Length == 0)
            {
                return 0;
            }

            for (int i = 0; i < A.Length; i++)
            {
                int value = CalculateValue2(A, i);
                maxValue = value > maxValue ? value : maxValue;
            }

            return maxValue;
        }

        private int CalculateValue(int[] A, int k)
        {
            int[] rotatedArray = RotateArray(A, k);

            int value = 0;

            for (int i = 0; i < rotatedArray.Length; i++)
            {
                value += i * rotatedArray[i];
            }

            return value;
        }

        private int CalculateValue2(int[] A, int k)
        {
            int value = 0;

            for (int i = 0; i < A.Length; i++)
            {
                int newIndex = i + k;
                if (newIndex >= A.Length)
                {
                    newIndex -= A.Length;
                }

                value += i * A[newIndex];
            }

            return value;
        }


        private int[] RotateArray(int[] A, int k)
        {
            int[] rotatedArray = new int[A.Length];
            for (int i = 0; i < A.Length; i++)
            {
                int newIndex = i + k;
                if (newIndex >= A.Length)
                {
                    newIndex -= A.Length;
                }

                rotatedArray[newIndex] = A[i];
            }

            return rotatedArray;
        }
    }

    public class Solution7
    {
        int[] nums;
        Random rand;

        public Solution7(int[] nums)
        {
            this.nums = nums;
            rand = new Random();
        }

        public int pick(int target)
        {
            for (int i = 0; i < this.nums.Length; i++)
            {
                if (nums[i] != target)
                {
                    continue;
                } 
                else
                {
                    int minIndex = i;
                    int maxIndex = i;

                    while(true)
                    {
                        if (maxIndex < nums.Length && nums[maxIndex] == target)
                        {
                            maxIndex++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    return rand.Next(minIndex, maxIndex);
                }
            }

            return -1;
        }
    }

    public class Solution6
    {
        //public double[] CalcEquation(string[,] equations, double[] values, string[,] queries)
        //{
        //    HashSet<string> totalStrings = new HashSet<string>();

        //    int x = equations.GetLength(0);
        //    int y = equations.GetLength(1);

        //    for (int i = 0; i < x; i++)
        //    {
        //        for (int j = 0; j < y; j++)
        //        {
        //            totalStrings.Add(equations[x, y]);
        //        }
        //    }



        //    foreach (var item in equations)
        //    {
        //        item
        //    }
        //}
    }

    public class Solution5
    {
        public int IntegerReplacement(int n)
        {
            return GetReplacements(n, 0);
        }

        private int GetReplacements(long n, int level)
        {
            if (n == 1)
            {
                return level;
            }

            if (n % 2 == 0)
            {
                return GetReplacements(n/2, level + 1);
            }
            else
            {
                int nplus1 = GetReplacements(n + 1, level + 1);
                int nminus1 = GetReplacements(n - 1, level + 1);
                return Math.Min(nplus1, nminus1);
            }
        }
    }


    public class Solution4
    {
        public double[] MedianSlidingWindow(int[] nums, int k)
        {
            int i, j;
            List<double> medians = new List<double>();
            for (i = 0, j = i + k - 1; j < nums.Length; i++, j++)
            {
                int[] sortedWindow = new int[k];
                int x, y;
                for (y = 0, x = i; x <= j; x++, y++)
                {
                    sortedWindow[y] = nums[x];
                }

                
                Array.Sort(sortedWindow);

                if (sortedWindow.Length % 2 == 0)
                {
                    long value = (long)sortedWindow[sortedWindow.Length / 2] + (long)sortedWindow[(sortedWindow.Length / 2) - 1];
                    medians.Add((double)value / 2);
                }
                else
                {
                    int value = sortedWindow[sortedWindow.Length / 2];
                    medians.Add(value);   
                }
            }

            return medians.ToArray();
        }
    }

        public class Solution3
    {
        public string LicenseKeyFormatting(string S, int K)
        {
            Stack<char> replace = new Stack<char>();
            string newS = S.ToUpper();
            newS = newS.Replace("-", "");

            int count = 0;
            for (int i = newS.Length - 1; i >= 0; i--)
            {
                if (count == K)
                {
                    replace.Push('-');
                    count = 0;
                }

                replace.Push(newS[i]);
                count++;
            }

            return new string(replace.ToArray());
        }
    }

    public class Solution2
    {
        public int FindComplement(int num)
        {
            char[] binary = Convert.ToString(num, 2).ToCharArray();
            for(int i = 0; i< binary.Length; i++)
            {
                binary[i] = binary[i] == '1' ? '0' : '1';
            }

            return Convert.ToInt32(new string(binary), fromBase: 2);
        }
    }

    public class Solution1
    {
        private static char[] allowedChars = { 'A', 'P', 'L' };
        private static int length = allowedChars.Length;

        private ConcurrentBag<string> bag = new ConcurrentBag<string>();

        private List<string> BuildPermutations(int num)
        {
            
            List<string> permutations = new List<string>();
            StringBuilder builder = new StringBuilder();



            return permutations;
        }

        private void fillIndex(char[] array, int index)
        {
            if (index + 1 == length)
            {
                bag.Add(array.ToString());
                return;
            }

            for (int i = 0; i < 3; i++)
            {
                fillIndex(array, i);
            }
        }

        //private AddChar(char[] chars, int index, int maxLength)
        //{
        //    char[] allowedchars = { 'A', 'P', 'L' };

        //    if (index + 1 > maxLength)
        //    {
        //        return;
        //    }

        //    chars[index] = allowedchars[index];
        //}

        private int totalA = 0;
        private int consL = 0;
        public bool CheckRecord(string s)
        {
            char[] chars = s.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == 'A')
                {
                    totalA++;

                    if (totalA == 2)
                    {
                        return false;
                    }

                    consL = 0;
                }
                else if (chars[i] == 'L')
                {
                    consL++;

                    if (consL >= 3)
                    {
                        return false;
                    }
                }
                else
                {
                    consL = 0;
                }
            }

            return true;
        }
    }
}
