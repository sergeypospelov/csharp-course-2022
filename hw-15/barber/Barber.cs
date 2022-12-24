using System.Collections.Concurrent;

namespace barber;

public class Barber
{
    private readonly int _capacity;
    private readonly ConcurrentQueue<Customer> _q = new();
    private readonly Task _task;
    private bool _working = true;
    private readonly object _emptyLock = new();

    public Barber(int capacity)
    {
        _capacity = capacity;
        _task = new Task(WorkRoutine);
        _task.Start();
    }

    public bool NewCustomer(Customer customer)
    {
        if (_q.Count == _capacity)
        {
            Console.Out.WriteLine($"Customer {customer.Id} can't wait -- the queue is full");
            return false;
        }

        Console.Out.WriteLine($"Customer {customer.Id} waits in the queue");
        
        _q.Enqueue(customer);
        lock (_emptyLock)
        {
            Monitor.Pulse(_emptyLock);
        }
        return true;
    }

    public void Close()
    {
        _working = false;
        lock (_emptyLock)
        {
            Monitor.Pulse(_emptyLock);
        }
        _task.Wait();
    }

    private void WorkRoutine()
    {
        while (_working || !_q.IsEmpty)
        {
            lock (_emptyLock)
            {
                while (_q.IsEmpty && _working)
                {
                    Monitor.Wait(_emptyLock);
                }
            }
            if (!_q.TryDequeue(out var customer))
            {
                continue;
            }
            Console.Out.WriteLine($"The barber has just started a haircutting for customer <{customer.Id}>");
            Thread.Sleep(customer.TimeToCut);
            Console.Out.WriteLine($"The barber has just finished a haircutting for customer <{customer.Id}>");
        }
    }
}