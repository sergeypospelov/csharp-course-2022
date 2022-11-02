using Microsoft.VisualBasic;

string Sorting(string str)
{
    var res = str.ToList();
    res.Sort(delegate(char c1, char c2)
    {
        var t1 = char.IsDigit(c1);
        var t2 = char.IsDigit(c2);

        if (t1 != t2)
        {
            return t1.CompareTo(t2);
        }
        else
        {
            if (t1)
            {
                return c1.CompareTo(c2);
            }
            else
            {
                var l1 = char.IsUpper(c1);
                var l2 = char.IsUpper(c2);

                var lower1 = char.ToLower(c1);
                var lower2 = char.ToLower(c2);
                if (lower1 == lower2)
                {
                    return l1.CompareTo(l2);
                }
                else
                {
                    return lower1.CompareTo(lower2);
                }
            }
        }
    });
    return new String(res.ToArray());
}

var examples = new []
{
    "eA2a1E",
    "Re4r",
    "6jnM31Q",
    "846ZIbo",
};

foreach (var example in examples)
{
    var res = Sorting(example);
    Console.Out.WriteLine($"{example} -> {res}");
}