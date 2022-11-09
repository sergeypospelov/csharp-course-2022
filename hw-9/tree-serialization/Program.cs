// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

var tree = new Tree(5);
tree.AddVertex(1, 2, 3);
tree.AddVertex(3, 4, 5);

Console.Out.WriteLine("Before:\n");
Console.Out.WriteLine(tree.ToString());

var deserialized = Tree.FromString(tree.ToString());
Debug.Assert(deserialized != null, nameof(deserialized) + " != null");

Console.Out.WriteLine("\nAfter:\n");
Console.Out.WriteLine(deserialized.ToString());

