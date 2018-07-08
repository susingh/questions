using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.LeetCode
{
    public class HappyNumber : IQuestion
    {
        public bool IsHappy(int n)
        {
            HashSet<int> seen = new HashSet<int>();
            while (n != 1)
            {
                if (seen.Contains(n))
                {
                    return false;
                }

                seen.Add(n);
                n = SumOfSquares(n);
            }

            return true;
        }

        int SumOfSquares(int n)
        {
            int sum = 0;

            while (n > 0)
            {
                int digit = n % 10;
                sum += (int)Math.Pow(digit, 2);
                n = n / 10;
            }

            return sum;
        }

        public void Run()
        {

            Convert.ToString(20, 2);
            //Console.WriteLine(IsHappy(19));
            Console.WriteLine(IsHappy(2));
        }
    }
}
