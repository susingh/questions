using System;
using System.Collections;
using System.Collections.Generic;

namespace Questions.LeetCode
{
    public class ReverseInteger
    {
        public int Reverse(int x)
        {
            if (x == 0)
            {
                return x;
            }

            double returnValue = 0;
            int multiplier = x < 0 ? -1 : 1;
            int input = x;

            try
            {
                 input = Math.Abs(x);
            }
            catch (OverflowException)
            {
                return 0;
            }

            Stack<int> stack = new Stack<int>();
            
            while (input > 0)
            {
                int digit = input % 10;
                stack.Push(digit);
                input = input / 10;
            }

            int index = 0;
            while (stack.Count > 0)
            {
                int digit = stack.Pop();
                double value = digit * Math.Pow(10, index++);
                returnValue += value;
            }

            return (returnValue > int.MaxValue ? 0 : (int)returnValue * multiplier);
        }

        public void Run()
        {
            Console.WriteLine(Reverse(1563847412));
            Console.WriteLine(Reverse(-321));
            Console.WriteLine(Reverse(120));
        }
    }
}
