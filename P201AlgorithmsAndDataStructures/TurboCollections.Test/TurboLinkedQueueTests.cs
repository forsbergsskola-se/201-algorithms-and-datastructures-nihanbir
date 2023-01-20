namespace TurboCollections.Test;

public class TurboLinkedQueueTests
{
    [Test]
    [TestCase(2,4)]
    [TestCase("sup", "wassup")]
    [TestCase('a','b')]
    public static void TurboLinkedWorks(object a, object b)
    {
        var list = new TurboLinkedQueue<object>();
        list.Enqueue(a);
        list.Enqueue(b);
        Assert.That(list.Peek(), Is.EqualTo(a));
        Assert.That(list.Count, Is.EqualTo(2));
        
        Assert.That(list.Dequeue(), Is.EqualTo(a));
        Assert.That(list.Peek(), Is.EqualTo(b));
        
        list.Enqueue(b);
        list.Clear();
        Assert.Throws<NullReferenceException>(() => list.Peek());
        Assert.Throws<NullReferenceException>(() => list.Dequeue());
    }
    
    //Ale's tests, also exists in TurboLinkedStackTests
    [Test]
    public void MoveNextReturnsTrueWhenListIsNotEmpty()
    {
        TurboLinkedQueue<object> tls = new TurboLinkedQueue<object>();
        tls.Enqueue(12);
        var enumerator = tls.GetEnumerator();
        Assert.That(enumerator.MoveNext(), Is.EqualTo(true));
    }
    [Test]
    public void CurrentPointerMovesWithMoveNext()
    {
        TurboLinkedQueue<object> tlq = new TurboLinkedQueue<object>();
        tlq.Enqueue(12);
        tlq.Enqueue(100);
        var enumerator = tlq.GetEnumerator();
        enumerator.MoveNext();
        Assert.That(enumerator.Current, Is.EqualTo(12));
        enumerator.MoveNext();
        Assert.That(enumerator.Current, Is.EqualTo(100));
    }
}