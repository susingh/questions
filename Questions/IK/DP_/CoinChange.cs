using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.DP_
{
    class CoinChange
    {
        public static int Coin_Change(int a, int[] denominations)
        {
            //return CoinChangeRecursion(a, denominations);
            //return CoinChangeDP(a, denominations);
            Dictionary<int, int> minCoins = new Dictionary<int, int>();
            return CoinChangeRecursionWithMemoization(a, denominations,  minCoins);
        }

        private static int CoinChangeRecursion(int a, int[] denominations)
        {
            if (a == 0) return 0;
            if (a < 0) return int.MaxValue;

            int minCoins = int.MaxValue;
            foreach (var coin in denominations)
            {
                int coins = CoinChangeRecursion(a - coin, denominations);
                minCoins = Math.Min(coins, minCoins);
            }

            return minCoins != int.MaxValue ? 1 + minCoins : minCoins;
        }

        private static int CoinChangeDP(int a, int[] demominations)
        {
            int[] dpTable = new int[a + 1];
            for (int i = 0; i < dpTable.Length; i++)
            {
                dpTable[i] = int.MaxValue;
            }

            dpTable[0] = 0;

            for (int i = 1; i <= a; i++)
            {
                int minCoins = int.MaxValue;
                foreach (var coin in demominations)
                {
                    int newValue = i - coin;
                    if (newValue >= 0)
                    {
                        int coins = dpTable[newValue];
                        minCoins = Math.Min(coins, minCoins);
                    }
                }

                if (minCoins != int.MaxValue)
                {
                    minCoins = minCoins + 1;
                }

                dpTable[i] = minCoins;
            }

            return dpTable[a];
        }

        private static int CoinChangeRecursionWithMemoization(int a, int[] denominations, IDictionary<int, int> minCoins)
        {
            if (a == 0) return 0;
            if (a < 0) return int.MaxValue;

            int minCoin = int.MaxValue;
            if (minCoins.ContainsKey(a))
            {
                minCoin = minCoins[a];
            }
            else
            {
                foreach (var coin in denominations)
                {
                    int coins = CoinChangeRecursionWithMemoization(a - coin, denominations, minCoins);
                    minCoin = Math.Min(coins, minCoin);
                }

                if (minCoin != int.MaxValue)
                {
                    minCoin += 1;
                }

                minCoins.Add(a, minCoin);
            }

            return minCoin;
        }
    }
}
