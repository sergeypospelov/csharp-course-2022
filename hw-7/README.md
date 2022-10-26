# hw-7

## Задание 1

Исходный код:


```csharp
var res1 = Task1(new List<ClassWithName>(new[]
    {
        new ClassWithName("Name1"),
        new ClassWithName("Name2"),
        new ClassWithName("Name3"),
        new ClassWithName("Name4"),
        new ClassWithName("Name5"),
        new ClassWithName("Name6")
    }), ", "
);
Console.Out.WriteLine(res1);
```

Пример работы:
```
Name4, Name5, Name6
```

## Задание 2


```csharp
var res2 = Task2(new List<ClassWithName>(new[]
    {
        new ClassWithName("abcde"),
        new ClassWithName("a"),
        new ClassWithName("abc"),
        new ClassWithName("abcde"),
        new ClassWithName("a"),
        new ClassWithName("abcd")
    })
);
Console.Out.WriteLine(String.Join(" ", res2));
```

Пример работы:
```
abcde abc abcde
```
## Задание 3

Пример работы:

```
Length: 3 Size: 3
Это
что
бац
Length: 6 Size: 3
ходишь
ходишь
вторая
Length: 5 Size: 3
школу
потом
смена
Length: 1 Size: 2
в
а
Length: 2 Size: 1
же
Length: 10 Size: 1
получается
```

## Задание 4

Пример работы:

## Задание 5

Пример работы:

## Задание 6

Пример работы:

```
12340 -> 42310, 10342
98761 -> 98761, 18769
9000 -> 9000, 9000
11321 -> 31121, 11123
```

## Задание 7

Пример работы:

```
Example: {0 1 -1 -1 2}
Result: {(-1, -1, 2), (0, 1, -1)}

Example: {0 0 0 5 -5}
Result: {(0, 0, 0), (0, 5, -5)}

Example: {1 2 3}
Result: {}

Example: {}
Result: {}

```