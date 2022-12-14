// See https://aka.ms/new-console-template for more information

int x = 0;

void Method() {
    for (int i = 0; i < 1_000_000; i++)
    {
        int y = x;
        y += 1;
        x = y;
    }
}


for (var attempt = 0; attempt < 4; attempt++)
{
    x = 0;
    var thread1 = new Thread(Method);
    var thread2 = new Thread(Method);

    thread1.Start();
    thread2.Start();

    thread1.Join();
    thread2.Join();

    Console.Out.WriteLine($"Attempt: {attempt}; Result: {x};");
}

