# hw-13

## Задание 1

Пример работы:

```csharp
string lock1 = "lock1";
string lock2 = "lock2";
int x = 0;

void foo()
{
    lock (lock1)
    {
        Thread.Sleep(10);
        lock (lock2)
        {
        }
    }
}

void bar()
{
    lock (lock2)
    {
        lock (lock1)
        {
        }
    }
}

var thread1 = new Thread(foo);
var thread2 = new Thread(bar);

thread1.Start();
thread2.Start();
```

## Задание 2

Пример работы:

```
0:0
1:0
0:1
1:1
0:2
1:2
0:3
1:3
0:4
1:4
0:5
1:5
0:6
1:6
0:7
1:7
0:8
1:8
0:9
1:9
0:10
1:10
0:11
1:11
0:12
1:12
0:13
1:13
0:14
1:14
0:15
1:15
0:16
1:16
0:17
1:17
0:18
1:18
0:19
1:19
```

## Задание 3

Пример работы:

```
foobarfoobarfoobarfoobarfoobarfoobarfoobarfoobarfoobarfoobar
```

## Задание 4

Пример работы:

```
True
False
```