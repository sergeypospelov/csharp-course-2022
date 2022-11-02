using System;
using System.Text;

string StringyFib(int n)
{
    if (n <= 2)
    {
        return "invalid";
    }
    
    var fib = new[] { "b", "a", "" };
    var ans = new StringBuilder();

    ans.Append("b, a");

    for (int i = 2; i < n; i++)
    {
        fib[i % 3] = fib[(i + 2) % 3] + fib[(i + 1) % 3];
        ans.Append(", " + fib[i % 3]);
    }

    return ans.ToString();
}

var examples = new []
{
    1,
    3,
    7
};

foreach (var example in examples)
{
    var res = StringyFib(example);
    Console.Out.WriteLine($"{example} -> {res}");
}