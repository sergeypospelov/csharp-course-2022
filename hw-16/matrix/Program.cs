const int maxSleepTime = 1000;
Random rng = new();


void PrintMatrix(int [,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
    }
}

// a_dim = n x k ; b_dim = k x m
int[,] MatrixMult(int n, int k, int m, int[,] a, int[,] b, int threadsNum = 4)
{
    int[,] res = new int[n, m];

    void MultiplyTask(int i, int j)
    {
        for (int t = 0; t < k; t++)
        {
            Console.Out.WriteLine($"{i}, {j}, {t}");
            res[i, j] += a[i, t] * b[t, j];
        }
    }

    int ptr = 0;
    object ptrLock = new();

    void ThreadRoutine()
    {
        while (ptr < n * m)
        {
            Thread.Sleep(rng.Next(maxSleepTime));
            
            int i, j;
            lock (ptrLock)
            {
                i = ptr / m;
                j = ptr % m;
                ptr++;
            }

            if (ptr < n * m)
            {
                MultiplyTask(i, j);
            }
        }
    }

    var threads = Enumerable.Repeat(0, threadsNum).Select(_ => new Thread(ThreadRoutine)).ToList();
    threads.ForEach(it => it.Start());
    threads.ForEach(it => it.Join());

    return res;
}

var m1 = new [,]
{
    {1, 2, 3},
};

var m2 = new [,]
{
    {1, -1},
    {-1, 1},
    {1, 1}
};

int n = 1, k = 3, m = 2;

var res = MatrixMult(n, k, m, m1, m2);

PrintMatrix(m1);
Console.Out.WriteLine("*");
PrintMatrix(m2);
Console.Out.WriteLine("=");
PrintMatrix(res);
