using System;

namespace lucky
{
    internal static class Program
    {
        public static long LuckyTicket(int n)
        {
            if (n < 0 || n % 2 != 0)
            {
                throw new ArgumentException("n must be non-negative even number");
            }

            n /= 2;

            long[,] dp = new long[n + 1, 9 * n + 1];
            for (int i = 0; i <= n; i++)
            {
                dp[i, 0] = 1;
                for (int sum = 1; sum <= i * 9; sum++)
                {
                    dp[i, sum] = dp[i - 1, sum] + dp[i, sum - 1];
                    if (sum > 9)
                    {
                        dp[i, sum] -= dp[i - 1, sum - 10];
                    }
                }
            }

            long ans = 0;
            for (int sum = 0; sum <= n * 9; sum++)
            {
                ans += dp[n, sum] * dp[n, sum];
            }

            return ans;
        }

        public static void Main(string[] args)
        {
            int[] examples = { 2, 4, 6, 8, 10, 12 };
            foreach (var example in examples)
            {
                long ans = LuckyTicket(example);
                Console.Out.WriteLine($"{example} -- {ans}");
            }
        }
    }
}