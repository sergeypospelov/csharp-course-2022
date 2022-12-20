// See https://aka.ms/new-console-template for more information

using System.Collections.Concurrent;

const int size = 9;

bool CheckLine(char[,] arr, int line)
{
    bool[] used = new bool[size];
    for (int i = 0; i < size; i++)
    {
        if (arr[line, i] == '.')
        {
            continue;
        }

        var x = arr[line, i] - '0' - 1;
        if (used[x])
        {
            return false;
        }

        used[x] = true;
    }

    return true;
}

bool CheckColumn(char[,] arr, int column)
{
    bool[] used = new bool[size];
    for (int i = 0; i < size; i++)
    {
        if (arr[i, column] == '.')
        {
            continue;
        }

        var x = arr[i, column] - '0' - 1;
        if (used[x])
        {
            return false;
        }

        used[x] = true;
    }

    return true;
}

bool CheckArea(char[,] arr, int x, int y)
{
    bool[] used = new bool[size];
    for (int i = x; i < x + 3; i++)
    {
        for (int j = y; j < y + 3; j++)
        {
            if (arr[i, j] == '.')
            {
                continue;
            }

            var a = arr[i, j] - '0' - 1;
            if (used[a])
            {
                return false;
            }

            used[a] = true;
        }
    }

    return true;
}


bool Check(char[,] arr)
{
    var results = new ConcurrentQueue<bool>();
    for (int i = 0; i < size; i++)
    {
        var i1 = i;
        ThreadPool.QueueUserWorkItem(_ =>
        {
            var res = CheckLine(arr, i1);
            results.Enqueue(res);
        });
        ThreadPool.QueueUserWorkItem(_ =>
        {
            var res = CheckColumn(arr, i1);
            results.Enqueue(res);
        });
    }

    for (int i = 0; i < size; i += size / 3)
    {
        for (int j = 0; j < size; j += size / 3)
        {
            var i1 = i;
            var j1 = j;
            ThreadPool.QueueUserWorkItem(_ =>
            {
                var res = CheckArea(arr, i1, j1);
                results.Enqueue(res);
            });
        }
    }

    return results.All(a => a);
}

var example1 = new[,]
{
    { '5', '3', '.', '.', '7', '.', '.', '.', '.' }, { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
    { '.', '9', '8', '.', '.', '.', '.', '6', '.' }, { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
    { '4', '.', '.', '8', '.', '3', '.', '.', '1' }, { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
    { '.', '6', '.', '.', '.', '.', '2', '8', '.' }, { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
    { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
};

Console.Out.WriteLine(Check(example1));

var example2 = new[,]
{
    { '8', '3', '.', '.', '7', '.', '.', '.', '.' }, { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
    { '.', '9', '8', '.', '.', '.', '.', '6', '.' }, { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
    { '4', '.', '.', '8', '.', '3', '.', '.', '1' }, { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
    { '.', '6', '.', '.', '.', '.', '2', '8', '.' }, { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
    { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
};

Console.Out.WriteLine(Check(example2));