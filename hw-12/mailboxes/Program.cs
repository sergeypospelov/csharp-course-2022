// See https://aka.ms/new-console-template for more information

(int[], long) GetMailboxPositions(int[] houses, int k)
{
    Array.Sort(houses);
    int n = houses.Length;
    long[,] dp = new long[n, k + 1];
    int[,] from = new int[n, k + 1];

    for (int i = 0; i < n; i++)
    {
        dp[i, 0] = long.MaxValue / 4;
        for (int m = 1; m <= Math.Min(k, i + 1); m++)
        {
            dp[i, m] = long.MaxValue / 4;
            from[i, m] = -1;
            for (int j = 0; j <= i; j++)
            {
                int pos = houses[(j + i) / 2];
                long sum = j > 0 ? dp[j - 1, m - 1] : 0;
                for (int t = j; t <= i; t++)
                {
                    sum += Math.Abs(houses[t] - pos);
                }
    
                if (sum < dp[i, m])
                {
                    dp[i, m] = sum;
                    from[i, m] = j - 1;
                }
            }
        }
    }

    var ans = new List<int>();
    var cur = (n - 1, k);
    while (cur.k > 0)
    {
        var j = from[cur.Item1, cur.k];
        ans.Add(houses[(cur.Item1 + j + 1) / 2]);
        cur.k--;
        cur.Item1 = j;
    }

    ans.Reverse();
    return (ans.ToArray(), dp[n - 1, k]);
}

var examples = new []
{
    (new []{1, 4, 8, 10, 20}, 3),
    (new []{2, 3, 5, 12, 18}, 2),
    (new []{7, 4, 6, 1}, 1),
    (new []{3, 6, 14, 10}, 4),
};

foreach (var (houses, k) in examples)
{
    Console.Out.WriteLine("Houses: " + String.Join(" ", houses));
    Console.Out.WriteLine("K: " + k);
    var (ansPoses, ans)  = GetMailboxPositions(houses, k);
    Console.Out.WriteLine("Ans: " + ans);
    Console.Out.WriteLine("Positions: " + String.Join(" ", ansPoses));
    Console.Out.WriteLine();
}