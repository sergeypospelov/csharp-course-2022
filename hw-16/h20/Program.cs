var state = 0;
object stateLock = new();

void UpdateStateAndPrint(int[] stateValues, char chr)
{
    lock (stateLock)
    {
        while (!stateValues.Contains(state))
        {
            Monitor.Wait(stateLock);
        }

        Console.Out.Write(chr);

        state++;
        state %= 3;

        Monitor.PulseAll(stateLock);
    }
}

void ReleaseOxygen()
{
    UpdateStateAndPrint(new[] { 0 }, 'O');
}

void ReleaseHydrogen()
{
    UpdateStateAndPrint(new[] { 1, 2 }, 'H');
}

var examples = new[]
{
    "HOH",
    "OOHHHH",
    "HHOHHOHHOOHH"
};

foreach (var example in examples)
{
    H2O h20 = new();
    var threads = example.Select(chr =>
            new Thread(chr == 'O' ? () => h20.Oxygen(ReleaseOxygen) : () => h20.Hydrogen(ReleaseHydrogen))
        )
        .ToList();
    foreach (var thread in threads)
    {
        thread.Start();
    }

    foreach (var thread in threads)
    {
        thread.Join();
    }

    Console.Out.WriteLine();
}

public class H2O
{
    public H2O()
    {
    }

    public void Hydrogen(Action releaseHydrogen)
    {
        // releaseHydrogen() outputs "H". Do not change or remove this line.
        releaseHydrogen();
    }

    public void Oxygen(Action releaseOxygen)
    {
        // releaseOxygen() outputs "O". Do not change or remove this line.
        releaseOxygen();
    }
}