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
    [TestCase(2)]
    [TestCase(7)]
    [TestCase(89)]
    public void SearchComparison(int value)
    {
        var list = new TurboLinkedList<int> { 2, 5, 7, 8, 89 };

        var timer = new Stopwatch();
        timer.Start();
        TurboSearch.LinearSearch(list, value);
        timer.Stop();
        var linearTimer = timer.Elapsed;
        Console.WriteLine($"Linear Search: {linearTimer}");

        timer.Restart();
        TurboSearch.BinarySearch(list, value);
        timer.Stop();
        var binaryTimer = timer.Elapsed;
        Console.WriteLine($"Binary Search: {binaryTimer}");
        
        if (binaryTimer < linearTimer)
        {
            var comparisonResult = linearTimer / binaryTimer;
            Console.WriteLine($"Binary Search was {Math.Round(comparisonResult, 1)} times faster");
        }
        else
        {
            var comparisonResult = binaryTimer / linearTimer;
            Console.WriteLine($"Linear Search was {Math.Round(comparisonResult, 1)} times faster");
        }
    }
}