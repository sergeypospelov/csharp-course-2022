// See https://aka.ms/new-console-template for more information

const int maxGatheringTime = 20;

Random rng = new();

var pot = 0;
object potLock = new();

void BeeAction(int beeIndex, int maxPortions, CancellationToken ct)
{
    if (ct.IsCancellationRequested)
    {
        return;
    }
    
    var sleepTime = rng.Next(maxGatheringTime + 1);
    Thread.Sleep(sleepTime);
    lock (potLock)
    {
        if (pot < maxPortions)
        {
            pot++;
            Console.Out.WriteLine($"Bee {beeIndex} has just carried on the {pot} portion of honey");
            Monitor.PulseAll(potLock);
        }
    }

    Task.Factory.StartNew(() => BeeAction(beeIndex, maxPortions, ct)); // start a new task to carry a new portion
}

void BearAction(int maxPortions, int maxEatTimes)
{
    if (maxEatTimes == 0)
    {
        return;
    }
    
    lock (potLock)
    {
        while (pot < maxPortions)
        {
            Monitor.Wait(potLock);
        }

        Console.Out.WriteLine($"Bear eats honey");
        pot = 0;
    }

    var task = Task.Factory.StartNew(() => BearAction(maxPortions, maxEatTimes - 1));
    task.Wait();
}

var examples = new[]
{
    new[] { 1, 5 },
    new[] { 3, 10 },
    new[] { 4, 20 },
};

foreach (var example in examples)
{
    var bees = example[0];
    var maxPortions = example[1];

    Console.Out.WriteLine($"Bees count: {bees}; Max portions: {maxPortions}");

    pot = 0;

    var bearTask = Task.Factory.StartNew(() => BearAction(maxPortions, 2)); // bear will eat two full pots

    var ts = new CancellationTokenSource();
    CancellationToken ct = ts.Token;
    var tasks = Enumerable.Range(1, bees).Select(idx => Task.Factory.StartNew(() => BeeAction(idx, maxPortions, ct), ct)).ToList();
    await bearTask;
    ts.Cancel();
    foreach (var task in tasks)
    {
        await task;
    }
}