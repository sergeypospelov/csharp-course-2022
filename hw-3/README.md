﻿# hw-3
## Задание 1

```csharp
var x = new
{
    Items = new List<int> { 1, 2, 3 }.GetEnumerator()
};
while (x.Items.MoveNext())
    Console.WriteLine(x.Items.Current);
```

Анонимный тип в C# может содержать только readonly свойства.
Таким образом, неявно создаётся тип с readonly полем типа `List<int>.Enumerator`.
C# запрещает изменение внутреннего состояния полей-структур, объявленных с модификатором `readonly`.
`List<int>.Enumerator` является структурой, но не `readonly` структурой, поэтому, чтобы сохранить гарантию,
компилятор добавит код, копирующий структуру перед вызовом метода `MoveNext`. Таким образом, `MoveNext`
будет вызвана на копии енумератора, а исходное поле останется без изменений.

`IEnumerator.Current` возвращает значение, на текущей позиции. По умолчанию, енумератор указывает на элемент
перед началом списка, в таком случае поведение `Current` не определено согласно документации. В текущей
реализации `Current` возвращает `default(T)`, то есть значение по умолчанию. В нашем случае это `0`.

Таким образом, в консоль выведется бесконечное количество нулей.

## Задание 2

Пример работы:

```
ListA
1 2 3 10 15
ListB
4 10 15
The value of the first common node:
10

---

ListA
1 2 3 10 15
ListB
4
No intersection!
```


## Задание 3

Пример работы:

```
4/6 -> 2/3
10/11 -> 10/11
100/400 -> 1/4
8/4 -> 2
-10/-4 -> 5/2
15/-20 -> -3/4
```

## Задание 4

Пример работы:

```
4884 -> (3, 9)
1 -> (1, 0)
11 -> (5, 2)
3113 -> (199, 3)
8836886388 -> (3, 22)
13377331 -> (1003129, 2)
```