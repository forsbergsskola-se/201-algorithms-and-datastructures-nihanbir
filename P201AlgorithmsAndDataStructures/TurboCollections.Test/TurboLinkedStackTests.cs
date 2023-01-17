using System.Collections;

namespace TurboCollections.Test;

public class TurboLinkedStackTests
{
    [Test]
    [TestCase(2)]
    [TestCase("wassup")]
    [TestCase('a')]
    public static void CanPush(object item)
    {
        TurboLinkedStack<object?> list = new TurboLinkedStack<object?>();
        list.Push(item);
        if(list.Count == 0) Assert.Fail();
    }

    [Test]
    [TestCase(2)]
    [TestCase("sup")]
    [TestCase('a')]
    public static void CanPeek(object item)
    {
        TurboLinkedStack<object?> list = new TurboLinkedStack<object?>();
        list.Push(item);
        if(list.Peek() == item) Assert.Pass(); 
    }

    [Test]
    [TestCase(2,4)]
    [TestCase("sup", "wassup")]
    [TestCase('a','b')]
    public static void CanPop(object a, object b)
    {
        TurboLinkedStack<object?> list = new TurboLinkedStack<object?>();
        list.Push(a);
        list.Push(b);
        object? beforePopNode = list.Peek(); 
        list.Pop();
        object? afterPopNode = list.Peek(); 
        //Peek to see if Pop() returns the last node value.
        //Check if the last node is replaced with the previous node value after Pop().
        if(beforePopNode != list.Pop() && afterPopNode != a) Assert.Fail();
    }

    [Test]
    [TestCase(2,4)]
    [TestCase("sup", "wassup")]
    [TestCase('a','b')]
    public static void CanClear(object a, object b)
    {
        TurboLinkedStack<object?> list = new TurboLinkedStack<object?>();
        list.Push(a);
        list.Push(b);
        list.Clear();
        if(list.Peek() != null) Assert.Fail();
    }
    
    
}