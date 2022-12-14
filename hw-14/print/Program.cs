// See https://aka.ms/new-console-template for more information

int pointer = 0;
object mutex = new object();

void Print(int []order, int num, Action action)
{
    lock (mutex)
    {
        while (pointer < order.Length)
        {
            while (pointer < order.Length && order[pointer] != num)
            {
                Monitor.Wait(mutex);
            }

            if (pointer < order.Length)
            {
                action();
                pointer++;
                Monitor.PulseAll(mutex);
            }
        }
    }
}

var examples = new[]
{ 
    new []{1, 2, 3},
    new []{1, 2, 1, 2, 3},
    new []{1, 1, 2, 2, 3, 3}
};

foreach (var example in examples)
{
    pointer = 0;
    Console.Out.WriteLine(String.Join(" ", example));
    var foo = new Foo();

    var thread1 = new Thread(_ => Print(example, 1, foo.first));
    var thread2 = new Thread(_ => Print(example, 2, foo.second));
    var thread3 = new Thread(_ => Print(example, 3, foo.third));
    
    thread1.Start();
    thread2.Start();
    thread3.Start();

    thread1.Join();
    thread2.Join();
    thread3.Join();
}