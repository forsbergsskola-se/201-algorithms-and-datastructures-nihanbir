namespace TurboCollections.Test;

public class TurboSortTests
{
    [Test]
    public void SelectionSortWorks()
    {
        TurboLinkedList<int> list = new TurboLinkedList<int>{4, 7, 23, 5, 1};
        TurboSort.SelectionSort(list);
        Assert.That(list, Is.EqualTo(new []{1,4,5,7,23}));
    }
}