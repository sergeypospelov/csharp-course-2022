// See https://aka.ms/new-console-template for more information

using foobar;

object outputLock = new();
var inc = 0;
var printed = false;

void Printer(int idx)
{
    while (true)
    {
        lock (outputLock)
        {
            if (inc % 2 == idx)
            {
                Console.Out.Write(idx == 0 ? "foo" : "bar");
                inc++;
                break;
            } 
        }
    }
}

var fooBar = new FooBar(10);

var t1 = new Thread(() => fooBar.Foo(() => Printer(0)));
var t2 = new Thread(() => fooBar.Foo(() => Printer(1)));

t1.Start();
t2.Start();