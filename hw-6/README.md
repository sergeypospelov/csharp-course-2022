# hw-6

## Задание 1

Пример работы:

```
1 3 5 7 8 6 4 2
13 1 4 9 -8 21
```

## Задание 2

Пример работы:
```
By name:
Name: Olga, Age: 13
Name: Vova, Age: 6
Name: Andrey, Age: 46
Name: Dmitry, Age: 30
Name: Sergey, Age: 21

By age:
Name: Vova, Age: 6
Name: Olga, Age: 13
Name: Sergey, Age: 21
Name: Dmitry, Age: 30
Name: Andrey, Age: 46
```

## Задание 3

Тестовый код:

```csharp
var list = new MyList<int>();

list.Add(3);
list.Add(2);
list.Add(3);
list.Add(4);
Console.Out.WriteLine("Size: " + list.Count);
Console.Out.WriteLine("Remove 2:" + list.Remove(2));
Console.Out.WriteLine("Size: " + list.Count);
Console.Out.WriteLine("Remove 2:" + list.Remove(2));
Console.Out.WriteLine("Size: " + list.Count);
Console.Out.WriteLine("Remove 4:" + list.Remove(4));
Console.Out.WriteLine("Size: " + list.Count);

list.Add(4);
list.Add(1);
list.Add(4);

Console.Out.WriteLine("Size: " + list.Count);

foreach (var i in list)
{
    Console.Out.Write(i + " ");
}

Console.Out.WriteLine("\nRemove 4:" + list.Remove(4));

Console.Out.WriteLine("Size: " + list.Count);
foreach (var i in list)
{
    Console.Out.Write(i + " ");
}
```

Результат:
```
Size: 4
Remove 2:True
Size: 3
Remove 2:False
Size: 3
Remove 2:True
Size: 2
Size: 5
3 3 4 1 4
Remove 4:True
Size: 4
3 3 1 4
```

## Задание 4

Пример работы:

## Задание 5

Пример работы:

