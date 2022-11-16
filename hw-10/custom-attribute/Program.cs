using System.Reflection;
using custom_attribute;

var type = typeof(HealthScore);

var attribute = type.GetCustomAttributes(false).First();

Console.Out.WriteLine("HealthScore");
Console.Out.WriteLine(attribute + "\n");


foreach (var method in type.GetMethods())
{
    var mAttribute = method.GetCustomAttributes(false).FirstOrDefault();
    Console.Out.WriteLine(method.Name + " [");
    Console.Out.WriteLine(mAttribute);
    Console.Out.WriteLine("]\n");
}