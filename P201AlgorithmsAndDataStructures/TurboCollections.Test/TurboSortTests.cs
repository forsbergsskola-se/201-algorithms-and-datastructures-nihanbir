namespace TurboCollections.Test;

public class TurboSortTests
{
    private TurboLinkedList<int> _list = null!;

    [SetUp]
    public void SetUp()
    {
        _list = new TurboLinkedList<int>{4, 7, 23, 5, 1};
    }
    
    [Test]
    public void SelectionSortWorks()
    {
        TurboSort.SelectionSort(_list);
        Assert.That(_list, Is.EquivalentTo(new []{4, 7, 23, 5, 1}));
        Assert.That(_list, Is.Ordered);
    }
    
    [Test]
    public void BubbleSortWorks()
    {
        TurboSort.BubbleSort(_list);
        Assert.That(_list, Is.EquivalentTo(new []{4, 7, 23, 5, 1}));
        Assert.That(_list, Is.Ordered);
    }

    [Test]
    public void QuickSortWorks()
    {
        TurboSort.QuickSort(_list);
        Assert.That(_list, Is.EquivalentTo(new []{4, 7, 23, 5, 1}));
        Assert.That(_list, Is.Ordered);
    }
}