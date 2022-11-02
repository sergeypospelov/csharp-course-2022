using System.Text;

var examples = new[]
{
    "Гроссмейстер",
    "Großmeister",
    "グランドマスター"
};

Console.OutputEncoding = Encoding.UTF8;

foreach (var example in examples)
{
    var encoded = Encoding.UTF8.GetBytes(example);
    var decoded = Encoding.UTF8.GetString(encoded);

    Console.Out.WriteLine($"{example} -> {decoded}");
}