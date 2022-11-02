string Repetition(string s)
{
    int n = s.Length;
    var ans = "";
    
    for (int i = 0; i < n - 1; i++)
    {
        for (int j = 0; j < n - i - 1; j++)
        {
            for (int k = i + 1; k <= n - j; k++)
            {
                var str1 = s.Substring(i, j);
                var str2 = s.Substring(k, j);
                if (str1.Equals(str2) && str1.Length > ans.Length)
                {
                    ans = str1;
                }
            }
        }
    }

    return ans;
}

var examples = new[]
{
    "mask4cask",
    "abcde"
};

foreach (var example in examples)
{
    var res = Repetition(example);
    Console.Out.WriteLine($"{example} -> ({res})");
}