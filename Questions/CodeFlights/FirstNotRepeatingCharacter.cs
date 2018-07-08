using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.CodeFlights
{
    public class FirstNotRepeatingCharacter
    {
        char firstNotRepeatingCharacter(string s)
        {
            int[] arr = new int[26];

            int aVal = 'a';

            foreach (char item in s)
            {
                arr[item - aVal]++;
            }

            foreach (char item in s)
            {
                if (arr[item - aVal] == 1)
                {
                    return item;
                }
            }

            return '_';
        }

        public void Run()
        {
            char value = firstNotRepeatingCharacter("abacabad");
        }
    }
}
