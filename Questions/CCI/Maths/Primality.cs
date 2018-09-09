using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.CCI.Maths
{
    class Primality
    {
        public static bool PrimalityCheck(int num)
        {
            //return PrimalityCheckBF(num);
            //return PrimalityCheckBFImproved(num);
            return PrimalityCheckSieve(num);
        }

        private static bool PrimalityCheckBF(int num)
        {
            if (num < 2)
            {
                return false;
            }

            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                    return false;
            }

            return true;
        }

        private static bool PrimalityCheckBFImproved(int num)
        {
            if (num < 2)
            {
                return false;
            }

            int max = (int)System.Math.Sqrt(num);

            for (int i = 2; i <= max; i++)
            {
                if (num % i == 0)
                    return false;
            }

            return true;
        }

        private static bool PrimalityCheckSieve(int num)
        {
            bool[] values = new bool[num + 1];
            Init(values);

            int prime = 2;

            while (prime < num)
            {
                ClearState(prime, values);
                prime = GetNextPrime(prime, values);

                if (!values[num])
                {
                    return false;
                }
            }

            return true;
        }

        private static int GetNextPrime(int prime, bool[] values)
        {
            int next = prime + 1;
            while (next < values.Length && !values[next])
            {
                next++;
            }
            return next;
        }

        private static void ClearState(int prime, bool[] values)
        {
            for (int i = prime; i < values.Length; i = i + prime)
                values[i] = false;
        }

        private static void Init(bool[] values)
        {
            values[0] = false;
            values[1] = false;

            for (int i = 2; i < values.Length; i++)
            {
                values[i] = true;
            }
        }
    }
}
