using System.Diagnostics;

namespace TurboCollections.Test;

public class SelectionSortTests
{
    [Test]
    public void RandomUnsortedListMeasurePerformance()
    {
        var items = Enumerable.Range(1,Random.Shared.Next(50,101))
            .Select(_ => Random.Shared.Next(0,100)).ToArray();
        var list = new TurboLinkedList<int>();
        
        list.AddRange(items);
        
        var timer = new Stopwatch();
        timer.Start();
        TurboSort.SelectionSort(list);
        timer.Stop();
        Assert.That(list, Is.Ordered);
        Assert.That(list, Is.EquivalentTo(items));
        Console.WriteLine($"Unsorted List: {timer.Elapsed}");
    }
    
    [Test]
    public void ReversedListMeasurePerformance()
    {
        var items = Enumerable.Range(0, Random.Shared.Next(50,101)).Reverse();
        var list = new TurboLinkedList<int>();
        list.AddRange(items);
        
        var timer = new Stopwatch();
        timer.Start();
        TurboSort.SelectionSort(list);
        timer.Stop();
        Assert.That(list, Is.Ordered);
        Assert.That(list, Is.EquivalentTo(items));
        Console.WriteLine($"Reversed List: {timer.Elapsed}");
    }
    
    [Test]
    public void SortedListMeasurePerformance()
    {
        var items = Enumerable.Range(1, Random.Shared.Next(50,101));
        var list = new TurboLinkedList<int>();
        list.AddRange(items);
 
        var timer = new Stopwatch();
        timer.Start();
        TurboSort.SelectionSort(list);
        timer.Stop();
        Assert.That(list, Is.Ordered);
        Assert.That(list, Is.EquivalentTo(items));
        Console.WriteLine($"Sorted List: {timer.Elapsed}");
    }
}