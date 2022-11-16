bool IsNested((int, int) a, (int, int) b)
{
    return a.Item1 < b.Item1 && a.Item2 < b.Item2 || a.Item1 < b.Item2 && a.Item2 < b.Item1;
}

int GetEnvelopesCount((int, int)[] envelopes)
{
    int n = envelopes.Length;

    if (n == 0)
    {
        return 0;
    }

    var arr = envelopes.ToList();
    arr.Sort((a, b) => Math.Min(a.Item1, a.Item2).CompareTo(Math.Min(b.Item1, b.Item2)));

    var dp = new int[n];
    for (int i = 0; i < n; i++)
    {
        dp[i] = 1;
        for (int j = 0; j < i; j++)
        {
            if (IsNested(arr[j], arr[i]))
            {
                dp[i] = Math.Max(dp[i], dp[j] + 1);
            }
        }
    }

    var ans = 0;
    for (int i = 0; i < n; i++)
    {
        ans = Math.Max(ans, dp[i]);
    }

    return ans;
}


var examples = new[]
{
    new[] { (5, 4), (6, 4), (6, 7), (2, 3) },
    new[] { (1, 1), (1, 1), (1, 1) }
};

foreach (var example in examples)
{
    var ans = GetEnvelopesCount(example);
    Console.Out.WriteLine(ans);
}