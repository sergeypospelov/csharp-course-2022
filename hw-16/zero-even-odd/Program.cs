
var examples = new[]
{
    2, 5, 10
};

void PrintNumber(int x)
{
    Console.Out.Write(x);
}

foreach (var example in examples)
{
    ZeroEvenOdd obj = new(example);

    var t1 = new Thread(() => obj.Zero(PrintNumber));
    var t2 = new Thread(() => obj.Even(PrintNumber));
    var t3 = new Thread(() => obj.Odd(PrintNumber));

    Console.Out.Write($"{example} -> ");
    
    t1.Start();
    t2.Start();
    t3.Start();

    t1.Join();
    t2.Join();
    t3.Join();
    
    Console.Out.WriteLine();
}

public class ZeroEvenOdd {
    private int _n;
    private int _state;
    private readonly object _stateLock = new();

    public ZeroEvenOdd(int n)
    {
        _n = n;
        _state = 0;
    }

    private void WaitStateAndPrint(int state, int x, Action<int> printNumber)
    {
        lock (_stateLock)
        {
            while (_state != state)
            {
                Monitor.Wait(_stateLock);
            }

            printNumber(x);

            _state++;
            _state %= 4;
            Monitor.PulseAll(_stateLock);
        }
    }
    
    // printNumber(x) outputs "x", where x is an integer.
    public void Zero(Action<int> printNumber) {
        for (int i = 0; i < _n; i++)
        {
            WaitStateAndPrint(i % 2 * 2, 0, printNumber);
        }
    }
    public void Even(Action<int> printNumber) {
        for (int i = 0; i < (_n + 1) / 2; i++)
        {
            WaitStateAndPrint(1, 2 * i + 1, printNumber);
        }
    }
    public void Odd(Action<int> printNumber) {
        for (int i = 0; i < _n / 2; i++)
        {
            WaitStateAndPrint(3, 2 * i + 2, printNumber);
        }
    }
}