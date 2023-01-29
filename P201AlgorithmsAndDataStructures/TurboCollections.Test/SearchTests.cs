namespace TurboCollections.Test;

public class SearchTests
{
    [Test]
    public void BinarySearchWorks()
    {
        var list = new TurboLinkedList<int>{2,5,7,8,89};
        Assert.That(TurboSearch.BinarySearch(list, 1), Is.EqualTo(-1));
        Assert.That(TurboSearch.BinarySearch(list, 89), Is.EqualTo(4));
    }
    [Test]
    public void LinearSearchWorks()
    {
        var list = new TurboLinkedList<int>{2,5,7,8,89};
        Assert.That(TurboSearch.LinearSearch(list, 1), Is.EqualTo(-1));
        Assert.That(TurboSearch.LinearSearch(list, 89), Is.EqualTo(4));
    }
}