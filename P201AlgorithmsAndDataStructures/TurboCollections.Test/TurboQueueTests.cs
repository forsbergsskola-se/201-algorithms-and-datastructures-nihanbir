namespace TurboCollections.Test;

public class TurboQueueTests
{
    [Test]
    [TestCase(2, 4)]
    [TestCase("sup", "wassup")]
    [TestCase('a', 'b')]
    public static void EnqueueWorks(object a, object b)
    {
        var list = new TurboQueue<object>();
        list.Enqueue(a);
        list.Enqueue(b);
        Assert.That(list.Peek(), Is.EqualTo(a));
        Assert.That(list.Count, Is.EqualTo(2));
    }
    [Test]
    [TestCase(2, 4)]
    [TestCase("sup", "wassup")]
    [TestCase('a', 'b')]
    public static void DequeueWorks(object a, object b)
    {
        var list = new TurboQueue<object>();
        list.Enqueue(a);
        Assert.That(list.Dequeue(), Is.EqualTo(a));
        Assert.Throws<NullReferenceException>(() => list.Dequeue());
    }
    
    [Test]
    [TestCase(2, 4)]
    [TestCase("sup", "wassup")]
    [TestCase('a', 'b')]
    public static void ClearWorks(object a, object b)
    {
        var list = new TurboQueue<object>();
        list.Enqueue(b);
        list.Clear();
        Assert.That(list.Count, Is.EqualTo(0));
    }
   
   

    //Ale's tests, also exists in TurboLinkedStackTests
    [Test]
    public void MoveNextReturnsTrueWhenListIsNotEmpty()
    {
        TurboQueue<object> tls = new TurboQueue<object>();
        tls.Enqueue(12);
        var enumerator = tls.GetEnumerator();
        Assert.That(enumerator.MoveNext(), Is.EqualTo(true));
    }
    [Test]
    public void CurrentPointerMovesWithMoveNext()
    {
        TurboQueue<object> tlq = new TurboQueue<object>();
        tlq.Enqueue(12);
        tlq.Enqueue(100);
        var enumerator = tlq.GetEnumerator();
        enumerator.MoveNext();
        Assert.That(enumerator.Current, Is.EqualTo(12));
        enumerator.MoveNext();
        Assert.That(enumerator.Current, Is.EqualTo(100));
    }
}