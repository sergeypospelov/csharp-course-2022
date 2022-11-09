using System.Runtime.Serialization;

namespace students_groups_serialization;

[Serializable]
public class Group
{
    public Group(decimal groupId, string name)
    {
        GroupId = groupId;
        Name = name;
        Students = new List<Student>();
    }

    public decimal GroupId { get; set; }
    public string Name { get; set; }

    public List<Student> Students
    {
        get => _students;
        set => _students = value;
    }
    public int StudentsCount => _students.Count;

    private List<Student> _students;

    public override string ToString()
    {
        return $"{nameof(GroupId)}: {GroupId}, {nameof(Name)}: {Name}, {nameof(Students)}:{{{string.Join("; ", Students)}}}, {nameof(StudentsCount)}: {StudentsCount}";
    }
}