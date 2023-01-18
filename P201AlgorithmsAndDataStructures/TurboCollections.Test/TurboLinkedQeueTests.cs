namespace TurboCollections.Test;

public class TurboLinkedQeueTests
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
}