using System;

namespace Questions.LeetCode
{
    public class Primes
    {
        public int CountPrimes(int n)
        {
            int numOfPrimes = 0;

            n = n - 1;

            while (n > 0)
            {
                if (isPrime(n))
                {
                    numOfPrimes++;
                }

                n--;
            }
            
            return numOfPrimes;
        }

        private bool isPrime(int n)
        {
            if (n <= 1)
            {
                return false;
            }
            else if (n <= 3)
            {
                return true;
            }
            else if (n % 2 == 0)
            {
                return false;
            }

            int maxTestNumber = (int)Math.Sqrt(n);
            int currentDivisor = 2;

            while (currentDivisor <= maxTestNumber)
            {
                if (n % currentDivisor == 0)
                {
                    return false;
                }

                currentDivisor++;
            }

            return true;
        }


        public void Run()
        {
            Console.WriteLine(CountPrimes(2));
        }
    }
}
