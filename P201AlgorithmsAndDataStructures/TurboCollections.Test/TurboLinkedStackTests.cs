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
        if(list.Count != 1) Assert.Fail();
    }

    [Test]
    [TestCase(2,4)]
    [TestCase("sup", "wassup")]
    [TestCase('a','b')]
    public static void CanPeek(object a, object b)
    {
        TurboLinkedStack<object?> list = new TurboLinkedStack<object?>();
        list.Push(a);
        list.Push(b);
        if(list.Peek() != b) Assert.Fail();
        list.Clear();
        Assert.Throws<NullReferenceException>(() => list.Peek());
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
        if(list.Count != 0) Assert.Fail();
    }

    [Test]
    [TestCase(2,4)]
    [TestCase("sup", "wassup")]
    [TestCase('a','b')]
    public static void EnumeratorMovesNextAndStartsOver(object a, object b)
    {
        TurboLinkedStack<object?> list = new TurboLinkedStack<object?>();
        list.Push(a);
        list.Push(b);
        using var enumerator = list.GetEnumerator();
        Assert.That(enumerator.MoveNext(), Is.EqualTo(true));
        Assert.That(enumerator.Current, Is.EqualTo(b));
        enumerator.Reset();
        Assert.That(enumerator.MoveNext(), Is.EqualTo(true));
        Assert.That(enumerator.Current, Is.EqualTo(b));
    }
    
    [Test]
    public void MoveNextReturnsTrueWhenListIsNotEmpty()
    {
        TurboLinkedStack<object> tls = new TurboLinkedStack<object>();
        tls.Push(12);
        using var enumerator = tls.GetEnumerator();
        Assert.That(enumerator.MoveNext(), Is.EqualTo(true));
    }
    [Test]
    public void CurrentPointerMovesWithMoveNext()
    {
        TurboLinkedStack<object> tlq = new TurboLinkedStack<object>();
        tlq.Push(12);
        tlq.Push(100);
        using var enumerator = tlq.GetEnumerator();
        enumerator.MoveNext();
        Assert.That(enumerator.Current, Is.EqualTo(100));
        enumerator.MoveNext();
        Assert.That(enumerator.Current, Is.EqualTo(12));
    }
}