using System.Collections.Generic;

namespace Questions.IK.Adhoc_
{
    class AdhocDriver : IQuestion
    {
        public void Run()
        {
            int[][] buildings = new int[][]
            {
                new int[] { 1,11,5 },
                new int []{ 2, 6, 7 },
                new int[] {3, 13, 9 },
                new int[] {12, 7, 16 },
                new int[] {14, 3, 25 },
                new int[] { 19, 18, 22},
                new int[] {23, 13, 29},
                new int[]{24, 4, 28}
            };

            var sol
                // = Sum_Zero.sumZero(new int[] { 5, 1, 2, -3, 7, -4 });
                //= Histogram.findMaxPossibleArea(new long[] { 1, 1, 1, 10, 1, 1, 1 }, 0, 6);
                // = MaxSubsetSum.MaxSumSubArray(new int[] { 5, -4, 4, -3, 11 });
                // = PrimeNumbers.detect_primes(new int[] { 6, 2, 5, 8 });
                //= HammingWeight.Weight(new List<long> { 1, 2, 3 });
                // = FindSkyline.Find_skyline(buildings);
                // = AlternatingPositiveNegatives.alternating_positives_and_negatives(new int[] { 2, 3, -4, -9, -1, -7, 1, -5, -6 });
                // = NextPalindrome.next_palindrome(192);
                //= MergeOverappingIntervals.getMergedIntervals(new int[][]
                //{
                //    new int[] { 1, 3 },
                //    new int[] { 5, 7 },
                //    new int[] { 2, 4 },
                //    new int[] { 6, 8 },
                //});
                // = MinRotatedSortedArray.FindMin(new int[] { 7, 8, 1, 2, 3, 4, 5, 6 });
                = string.Empty; MoveZeros.MoveZeroes(new int[] { 0, 1, 3, 0, 12 });
        }
    }
}
