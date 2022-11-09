// See https://aka.ms/new-console-template for more information

using System.Runtime.Serialization.Formatters.Binary;
using students_groups_serialization;

MemoryStream Serialize(Group group)
{
    var formatter = new BinaryFormatter();
    var stream = new MemoryStream();
    formatter.Serialize(stream, group);
    return stream;
}

Group DeserializeGroup(Stream stream)
{
    stream.Seek(0, SeekOrigin.Begin);
    var formatter = new BinaryFormatter();
    return (Group) formatter.Deserialize(stream);
}

var group = new Group(1, "first");
group.Students = new List<Student>()
{
    new Student(1, "First1", "Last1", 21, group),
    new Student(2, "First2", "Last2", 31, group),
    new Student(3, "First3", "Last3", 41, group),
};

Console.Out.WriteLine("Before:\n");
Console.Out.WriteLine(group.ToString());

var deserialized = DeserializeGroup(Serialize(group));

Console.Out.WriteLine("\nAfter:\n");
Console.Out.WriteLine(deserialized.ToString());