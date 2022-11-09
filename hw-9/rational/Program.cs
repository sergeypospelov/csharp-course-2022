// See https://aka.ms/new-console-template for more information

using System.Text;

int Gcd(int a, int b)
{
    return a > 0 ? Gcd(b % a, a) : b;
}

string Rational(int a, int b)
{
    if (a < 1 || b < 1 || a >= b)
    {
        throw new ArgumentException();
    }

    int g = Gcd(a, b);
    a /= g;
    b /= g;

    var remainders = new int[b];

    var cur = a;
    var sb = new StringBuilder();
    sb.Append("0,");
    var fst = -1;

    for (int p = 1;; p++)
    {
        int rem = cur % b;
        cur *= 10;
        int d = cur / b;
        cur = cur % b;


        if (rem == 0)
        {
            return sb.ToString();
        }

        if (remainders[rem] != 0)
        {
            fst = remainders[rem];
            break;
        }
        else
        {
            sb.Append(d);
            remainders[rem] = p;
        }
    }

    var res = sb.ToString();
    return res.Insert(fst + 1, "(") + ")";
}

var examples = new[]
{
    new[] { 2, 5 },
    new[] { 1, 6 },
    new[] { 1, 3 },
    new[] { 1, 7 },
    new[] { 1, 77 },
    new[] { 2, 9 },
    new[] { 15, 73 },
    new[] { 15, 20 },
};

foreach (var example in examples)
{
    var a = example[0];
    var b = example[1];
    var res = Rational(a, b);
    Console.Out.WriteLine($"{a}/{b} => {res}");
}
