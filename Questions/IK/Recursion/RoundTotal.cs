using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Recursion
{
    class RoundTotal
    {
        public static int[] RoundTotalMain(double[] input)
        {
            double sum = 0.0;
            foreach (var item in input)
            {
                sum += item;
            }

            int[] result = new int[input.Length];
            double val = RoundTotalInternal(input, (int)Math.Round(sum), result, 0, 0.0);
            return result;
        }

        private static int GetValue(int[] result)
        {
            int sum = 0;
            foreach (var item in result)
            {
                sum += item;
            }

            return sum;
        }

        private static double RoundTotalInternal(double[] input, int total, int[] result, int i, double loss)
        {
            if (GetValue(result) > total)
            {
                return double.MaxValue;
            }

            if (i == input.Length)
            {
                return loss;
            }

            int upVal = (int)Math.Ceiling(input[i]);
            result[i] = upVal;
            double upLoss = RoundTotalInternal(input, total, result, i + 1, loss + Math.Abs(upVal - input[i]));

            int downVal = (int)Math.Floor(input[i]);
            result[i] = downVal;
            double downLoss = RoundTotalInternal(input, total, result, i + 1, loss + Math.Abs(downVal - input[i]));

            if (downLoss < upLoss)
            {
                result[i] = downVal;
                return downLoss;
            }
            else
            {
                result[i] = upVal;
                return upLoss;
            }
        }
    }
}
