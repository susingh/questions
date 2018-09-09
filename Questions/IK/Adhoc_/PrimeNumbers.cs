using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Adhoc_
{
    class PrimeNumbers
    {
        public static string detect_primes(int[] a)
        {
            //return detect_primes_bf(a);
            return detect_prime_sieve(a);
        }

        private static string detect_primes_bf(int[] a)
        {
            char[] result = new char[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                result[i] = IsPrime(a[i]) ? '1' : '0';
            }

            return new string(result);
        }

        private static bool IsPrime(int num)
        {
            if (num < 2)
                return false;

            int sqrt = (int)Math.Sqrt(num);
            for (int i = 2; i <= sqrt; i++)
            {
                if (num % i == 0)
                    return false;
            }

            return true;
        }

        private static string detect_prime_sieve(int[] a)
        {
            // find the maximum number in the array, solve the primes for that number using Sieve of blah blah
            // use the boolean array for all numbers.

            int maxNum = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                maxNum = Math.Max(maxNum, a[i]);
            }

            bool[] flags = new bool[maxNum + 1];
            Init(flags);

            HashSet<int> primes = new HashSet<int>();
            int prime = 2;
            
            while (prime <= maxNum)
            {
                primes.Add(prime);
                ClearState(prime, flags);
                prime = GetNextPrime(prime, flags);
            }

            char[] result = new char[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                result[i] = primes.Contains(a[i]) ? '1' : '0';
            }

            return new string(result);
        }

        private static int GetNextPrime(int prime, bool[] flags)
        {
            int next = prime + 1;
            while (next < flags.Length && !flags[next])
            {
                next++;
            }

            return next;
        }

        private static void ClearState(int prime, bool[] flags)
        {
            for (int i = prime; i < flags.Length; i = i + prime)
            {
                flags[i] = false;
            }
        }

        private static void Init(bool[] flags)
        {
            flags[0] = false;
            flags[1] = false;

            for (int i = 2; i < flags.Length; i++)
            {
                flags[i] = true;
            }
        }
    }
}
