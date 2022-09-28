using System;
using System.Collections;

namespace Lists
{
  class MyList<T> : IEnumerable
  {
    public class ListNode
    {
      public T Value { get; }
      public ListNode Next { get; private set; }

      internal ListNode(T value)
      {
        Value = value;
        Next = null;
      }

      public void Add(ListNode node)
      {
        Next = node;
      }
    }

    private readonly ListNode _head;
    private ListNode _tail;
    public int Count { get; private set; }

    public MyList(T val)
    {
      var node = new ListNode(val);
      _head = node;
      _tail = node;
      Count = 1;
    }

    public void Add(T val)
    {
      var node = new ListNode(val);
      _tail.Add(node);
      _tail = node;
      Count++;
    }
    
    public void Add(MyList<T> val)
    {
      _tail.Add(val._head);
      _tail = val._tail;
      Count += val.Count;
    }

    public IEnumerator GetEnumerator()
    {
      var cur = _head;
      while (cur != null)
      {
        yield return cur.Value;
        cur = cur.Next;
      }
    }

    public static ListNode CommonPart(MyList<T> a, MyList<T> b)
    {
      var curA = a._head;
      var curB = b._head;
      for (int i = 0; i < a.Count - b.Count; i++)
      {
        curA = curA.Next;
      }
      for (int i = 0; i < b.Count - a.Count; i++)
      {
        curB = curB.Next;
      }

      while (curA != curB)
      {
        curA = curA.Next;
        curB = curB.Next;
      }

      return curA;
    }
  }
  
  internal static class Program
  {
    public static void Main(string[] args)
    {
      MyList<int> listCommon = new MyList<int>(10);
      listCommon.Add(15);
      
      MyList<int> listA = new MyList<int>(1);
      listA.Add(2);
      listA.Add(3);

      MyList<int> listB = new MyList<int>(4);
      
      listA.Add(listCommon);
      //listB.Add(listCommon);
      
      Console.Out.WriteLine("ListA");
      foreach (var el in listA)
      {
        Console.Out.Write(el + " ");
      }
      Console.Out.WriteLine();
      
      Console.Out.WriteLine("ListB");
      foreach (var el in listB)
      {
        Console.Out.Write(el + " ");
      }
      Console.Out.WriteLine();

      var commonNode = MyList<int>.CommonPart(listA, listB);

      if (commonNode != null)
      {
        Console.Out.WriteLine("The value of the first common node:");
        Console.Out.WriteLine(commonNode.Value);
      }
      else
      {
        Console.Out.WriteLine("No intersection!");
      }
    }
  }
}