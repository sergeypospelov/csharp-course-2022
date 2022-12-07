// See https://aka.ms/new-console-template for more information

object outputLock = new();
var inc = 0;
var printed = false;

void Printer(int idx)
{
    for (int i = 0; i < 20; i++)
    {
        while (true)
        {
            lock (outputLock)
            {
                if (inc % 2 == idx)
                {
                    Console.Out.WriteLine(idx + ":" + i);
                    inc++;
                    break;
                } 
            }
        }
    }
}

var thread1 = new Thread(_ => Printer(0));
var thread2 = new Thread(_ => Printer(1));

thread1.Start();
thread2.Start();