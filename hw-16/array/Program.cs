var array = new ConcurrentArray(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8});

var thread1 = new Thread(() =>
{
    for (var i = 0; i < 4; i++)
    {
        Thread.Sleep(500);
        float res = array.ComputeAverage();
        Console.Out.WriteLine($"Average #{i}: {res}");
    }
});
thread1.Start();

var thread2 = new Thread(() =>
{
    for (var i = 0; i < 4; i++)
    {
        Thread.Sleep(900);
        float res = array.ComputeMin();
        Console.Out.WriteLine($"Min #{i}: {res}");
    }
});
thread2.Start();

var thread3 = new Thread(() =>
{
    for (var i = 0; i < 4; i++)
    {
        Thread.Sleep(450);
        array.Swap();
        Console.Out.WriteLine($"Swap #{i}");
    }
});
thread3.Start();

var thread4 = new Thread(() =>
{
    for (var i = 0; i < 4; i++)
    {
        Thread.Sleep(600);
        array.Sort();
        Console.Out.WriteLine($"Sort #{i}");
    }
});
thread4.Start();

thread1.Join();
thread2.Join();
thread3.Join();
thread4.Join();
