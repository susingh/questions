using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.LeetCode
{
    public class Romans
    {
        private readonly IDictionary<char, int> romanDigits = new Dictionary<char, int>
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 },
            };

        public int RomanToInt(string s)
        {
            int returnValue = 0;
            char[] arr = s.ToCharArray();

            int i = 0;
            while (i < arr.Length)
            {
                if (i+1 < arr.Length)
                {
                    int valA = romanDigits[arr[i]];
                    int valB = romanDigits[arr[i + 1]];

                    if (valA >= valB)
                    {
                        returnValue += valA;
                        i++;
                    }
                    else
                    {
                        returnValue += valB - valA;
                        i += 2;
                    }
                }
                else
                {
                    int valA = romanDigits[arr[i]];
                    returnValue += valA;
                    i++;
                }
            }

            return returnValue;
        }

        public void Run()
        {
            Console.WriteLine(RomanToInt("MDCCLXXVI"));
            Console.WriteLine(RomanToInt("MCMLIV"));
            Console.WriteLine(RomanToInt("MCMXC"));
        }
    }
}
