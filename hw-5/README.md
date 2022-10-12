# hw-5

## Задание 1

Тестовый код:
```csharp
var eventBusA = new EventBus<EventA>();

var subscriberA1 = new SubscriberA("Subscriber_A_#1");
var subscriberA2 = new SubscriberA("Subscriber_A_#2");

eventBusA.Subscribe(subscriberA1);
eventBusA.Subscribe(subscriberA2);

eventBusA.Post(new EventA("<EventA: 0>", "Main_#1"));

eventBusA.UnSubscribe(subscriberA1);
    
eventBusA.Post(new EventA("<EventA: 0>", "Main_#2"));


var eventBusB = new EventBus<EventB>();

var subscriberB = new SubscriberB();

eventBusB.Subscribe(subscriberB);

eventBusB.Post(new EventB(4, 2));

```
Результат работы:

```
Subscriber Subscriber_A_#1 received event <EventA: 0> from Main_#1
Subscriber Subscriber_A_#2 received event <EventA: 0> from Main_#1
Subscriber Subscriber_A_#2 received event <EventA: 0> from Main_#2
SubscriberB received EventB with data (4, 2)

```

## Задание 2

Тестовый код
```csharp
var stack = new PseudoStack<int>(3);

stack.Push(14);
stack.Push(15);
stack.Push(42);

Console.Out.WriteLine(String.Join(" ", stack));

stack.Push(100);
stack.Push(0);

Console.Out.WriteLine(String.Join(" ", stack));

stack.Pop();

Console.Out.WriteLine(String.Join(" ", stack));

stack.Pop();
stack.Pop();
stack.Pop();

Console.Out.WriteLine(String.Join(" ", stack));
```

Результат работы:

```
14 15 42
14 15 42 100 0
14 15 42 100
14

```


## Задание 3

Пример работы:

```
10001 -> 1
00101 -> 1
0 -> 1
000 -> 2
00 -> 1
1 -> 0
11 -> 0
10101 -> 0
1001001 -> 0
100010001 -> 2
```

## Задание 4

Пример работы:

```
2 = 2
4 = 2^2
10 = 2 x 5
60 = 2^2 x 3 x 5
239 = 239
1000 = 2^3 x 5^3
1791791791 = 1791791791
753208157208154 = 2 x 37 x 613651 x 16586771
```