using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.Practice
{
    public class ElementInCircularRotated : IQuestion
    {
        
        public bool IsElementPresent(int[] array, int x)
        {
            bool found = false;
            int low = 0, high = array.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (array[mid] == x)
                {
                    found = true;
                    break;
                }
                else if (array[mid] <= array[high])
                {
                    if (array[mid] < x && x >= array[high])
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }
                else
                {
                    high = mid - 1; 
                }
            }
            return found;
        }

        public void Run()
        {
            int[] array = { 15, 18, 2, 4, 8, 9, 11, 14 };

            Console.WriteLine(IsElementPresent(array, 2));
            //Console.WriteLine(IsElementPresent(array, 18));
            //Console.WriteLine(IsElementPresent(array, 10));
            //Console.WriteLine(IsElementPresent(array, 10));
        }
    }
}
