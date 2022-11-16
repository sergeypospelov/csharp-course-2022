using System.Reflection;
using black_box;

const BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;

var type = typeof(BlackBox);
var box = type
    .GetConstructor(flags, null, new[] { typeof(int) }, null)!
    .Invoke(new object[] { 0 });

var field = type.GetField("innerValue", flags)!;

while (true)
{
    var cmd = Console.In.ReadLine()!;
    var splits = cmd.Split('(', ')');
    var methodName = splits[0];
    var argument = int.Parse(splits[1]);

    var method = type.GetMethod(methodName, flags);

    if (method != null)
    {
        method.Invoke(box, new object[] { argument });
    }

    var value = field.GetValue(box);
    Console.Out.WriteLine(value);
}