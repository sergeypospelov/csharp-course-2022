bool CheckAlmostTheSame(string s1, string s2)
{
    if (Math.Abs(s1.Length - s2.Length) > 1)
    {
        return false;
    }

    if (s1.Length == s2.Length)
    {
        var res = s1.Zip(s2).Aggregate(0, (sum, chars) => sum + (chars.First != chars.Second ? 1 : 0));
        return res <= 1;
    }

    if (s1.Length > s2.Length)
    {
        (s1, s2) = (s2, s1);
    }

    for (int i = 0; i < s2.Length; i++)
    {
        string t = s1[0..i] + s2[i] + (i + 1 < s1.Length ? s1[i..] : "");
        if (t.Equals(s2))
        {
            return true;
        }
    }

    return false;
}

var examples = new[]
{
    new [] { "abc", "ab" },
    new [] { "a", "a" },
    new [] { "abc", "abd" },
    new [] { "aaabbbccc", "aaabbccc"},
    new [] { "", "a"},
    new [] { "", "ab"},
    new [] { "abc", "dce"},
};

foreach (var pair in examples)
{
    var a = pair[0];
    var b = pair[1];
    Console.Out.WriteLine($"({a}, {b}) -> {CheckAlmostTheSame(a, b)}");
}