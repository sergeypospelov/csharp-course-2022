namespace custom_attribute;

public class Custom : Attribute
{
    private string Author { get; }
    private int Revision { get; }
    private string Summary { get; }
    private string[] Reviewers { get; }

    public Custom(string author, int revision, string summary, params string[] reviewers)
    {
        Author = author;
        Revision = revision;
        Summary = summary;
        Reviewers = reviewers;
    }

    public override string ToString()
    {
        return "Author: " + Author + "\nRevision: " + Revision + "\nSummary: " + Summary + "\nReviewers: [" + string.Join(", ", Reviewers) + "]";
    }
}