namespace TurboCollections.Test;

public class TurboSortTests
{
    [Test]
    public void SelectionSortWorks()
    {
        TurboLinkedList<int> list = new TurboLinkedList<int>{4, 7, 23, 5, 1};
        TurboSort.SelectionSort(list);
        Assert.That(list, Is.EquivalentTo(new []{4, 7, 23, 5, 1}));
        Assert.That(list, Is.Ordered);
    }
    [Test]
    public void BubbleSortWorks()
    {
        TurboLinkedList<int> list = new TurboLinkedList<int>{4, 7, 23, 5, 1};
        TurboSort.BubbleSort(list);
        Assert.That(list, Is.EquivalentTo(new []{4, 7, 23, 5, 1}));
        Assert.That(list, Is.Ordered);
    }
}