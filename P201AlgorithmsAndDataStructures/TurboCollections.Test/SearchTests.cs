using System.Diagnostics;

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
    
    [Test]
    public void LinearSearchs()
    {
        var list = new TurboLinkedList<int>{2,5,7,8,89};
        
        var timer = new Stopwatch();
        timer.Start();
        TurboSearch.LinearSearch(list, 89);
        timer.Stop();
        var linearTimer= timer.Elapsed;
        Console.WriteLine($"Linear Search: {timer.Elapsed}");
        
        timer.Restart();
        TurboSearch.BinarySearch(list, 89);
        timer.Stop();
        var binaryTimer= timer.Elapsed;
        Console.WriteLine($"Binary Search: {timer.Elapsed}");

        if (binaryTimer < linearTimer)
        {
            var comparisonResult = (linearTimer - binaryTimer) / linearTimer * 100;
            Console.WriteLine($"Binary Search was {(int)comparisonResult}% faster than Linear Search");
        }
        else
        {
            var comparisonResult = (binaryTimer - linearTimer) / binaryTimer * 100;
            Console.WriteLine($"Linear Search was {(int)comparisonResult}% faster than Binary Search");
        }
        
    }
    
}