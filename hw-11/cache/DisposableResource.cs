namespace cache;

public class DisposableResource : IDisposable
{
    private readonly int _id;

    public DisposableResource(int id)
    {
        _id = id;
    }

    public void Dispose()
    {
        Console.Out.WriteLine($"Bye, bye from {_id}");
    }
}