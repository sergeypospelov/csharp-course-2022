// See https://aka.ms/new-console-template for more information

const int sleepTime = 100; // 100 ms

void SleepSort1(string[] strings)
{
    object mutex = new();
    var threads = strings.Select(str =>
    {
        return new Thread(_ =>
        {
            Thread.Sleep(sleepTime * str.Length);
            lock (mutex)
            {
                Console.Out.WriteLine(str);
            }
        });
    }).ToList();

    foreach (var thread in threads)
    {
        thread.Start();
    }

    foreach (var thread in threads)
    {
        thread.Join();
    }
}

void SleepSort2(string[] strings)
{
    object mutex = new();
    var result = new List<String>();
    var threads = strings.Select(str =>
    {
        return new Thread(_ =>
        {
            Thread.Sleep(sleepTime * str.Length);
            lock (mutex)
            {
                result.Add(str);
            }
        });
    }).ToList();

    foreach (var thread in threads)
    {
        thread.Start();
    }

    foreach (var thread in threads)
    {
        thread.Join();
    }

    foreach (var str in result)
    {
        Console.Out.WriteLine(str);
    }
}

var examples = new []
{
    new []{"a", "bcd", "bb", "aaa", "ccccc", "ede"},
    new []{"ccc", "bb", "bb", "a"}
};

foreach (var example in examples)
{
    Console.Out.WriteLine("SleepSort1:");
    SleepSort1(example);
    Console.Out.WriteLine("SleepSort2:");
    SleepSort2(example);
}