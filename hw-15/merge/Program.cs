// See https://aka.ms/new-console-template for more information

using System.Collections.Concurrent;

Random rng = new();

void SubSort(ref List<int> elementsToSort, int l, int r)
{
    elementsToSort.Sort(l, r - l, Comparer<int>.Default);
    int delay = rng.Next(500, 1000);
    Thread.Sleep(delay);
}

List<int> MergeTask(ref List<int> left, ref List<int> right)
{
    var result = new List<int>();
    var (leftIndex, rightIndex) = (0, 0);

    while (leftIndex < left.Count && rightIndex < right.Count)
    {
        result.Add(left[leftIndex] < right[rightIndex] ? left[leftIndex++] : right[rightIndex++]);
    }

    while (leftIndex < left.Count)
    {
        result.Add(left[leftIndex++]);
    }

    while (rightIndex < right.Count)
    {
        result.Add(right[rightIndex++]);
    }

    return result;
}

List<int> MergeSort(List<int> elementsToSort, int threads)
{
    var chunk = (elementsToSort.Count + threads - 1) / threads;
    threads = (elementsToSort.Count + chunk - 1) / chunk;

    var result = new List<int>();
    var resultLock = new object();
    var finishedSubtasks = new ConcurrentQueue<int>();

    var subtasks = new List<Task>();
    for (var i = 0; i < threads; ++i)
    {
        var l = i * chunk;
        var r = Math.Min(elementsToSort.Count, l + chunk);
        var subTask = Task.Run(() => SubSort(ref elementsToSort, l, r));
        subTask.ContinueWith(_ =>
        {
            lock (resultLock)
            {
                finishedSubtasks.Enqueue(l);
                Monitor.Pulse(resultLock);
            }
        });
        subtasks.Add(subTask);
    }

    while (result.Count < elementsToSort.Count)
    {
        lock (resultLock)
        {
            while (finishedSubtasks.IsEmpty)
            {
                Monitor.Wait(resultLock);
            }
            if (finishedSubtasks.TryDequeue(out var l))
            {
                var r = Math.Min(l + chunk, elementsToSort.Count);
                var sortedBatch = elementsToSort.GetRange(l, r - l);
                result = MergeTask(ref result, ref sortedBatch);
            }
        }
    }

    Task.WaitAll(subtasks.ToArray());
    return result;
}

var examples = new []
{
    (1, new [] {5, 4, 3, 2, 1, 0}),
    (2, new [] {6, 5, 4, 3, 2, 1, 0, -1}),
    (4, new [] {6, 5, 4, 3, 2, 1, 0, -1}),
    (10, new [] {3, 2, 1})
};

foreach (var example in examples)
{
    var res = MergeSort(example.Item2.ToList(), example.Item1);
    Console.Out.WriteLine(string.Join(" ", res));
}