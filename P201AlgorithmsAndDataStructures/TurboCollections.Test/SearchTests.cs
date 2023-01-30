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
    [TestCase(89000)]
    [TestCase(500)]
    [TestCase(1)]
    public void SearchComparison(int value)
    {
        // var list = new TurboLinkedList<int> { 2, 5, 7, 8, 89 };
        var items = Enumerable.Range(1, 1000000);
        var list = new TurboLinkedList<int>();
        list.AddRange(items);
        
        var timer = new Stopwatch();
        timer.Start();
        TurboSearch.LinearSearch(list, value);
        timer.Stop();
        var linearTimer = timer.Elapsed;
        // Assert.That();
        Console.WriteLine($"Linear Search: {linearTimer}");

        var items1 = Enumerable.Range(1, 100);
        var list1 = new TurboLinkedList<int>();
        list1.AddRange(items1);
        
        timer.Restart();
        TurboSearch.BinarySearch(list1, value);
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
    [Test]
    [TestCase(0)]
    [TestCase(50000)]
    [TestCase(75000)]
    [TestCase(99999)]
    public void BinaryVsLinearSearchComparison(int testCase)
    {
        var numberList = Enumerable.Range(0, 10000000);
        var list = new TurboLinkedList<int>();
        list.AddRange(numberList);
        var sw = new Stopwatch();
        
        
        
        sw.Start();
        TurboSearch.LinearSearch(list, testCase);
        sw.Stop();
        long linearResult = sw.ElapsedMilliseconds;
        Console.WriteLine($"Linear Search value {testCase}: {sw.ElapsedMilliseconds} ms");
        sw.Reset();
    
        sw.Start();
        TurboSearch.BinarySearch(list, testCase);
        sw.Stop();
        long binaryResult = sw.ElapsedMilliseconds;
        Console.WriteLine($"Binary Search value {testCase}: {sw.ElapsedMilliseconds} ms");
        sw.Reset();
        
        string fasterMethod = (binaryResult < linearResult ? "Binary" : "Linear") + " search";
        long fasterTime = Math.Max(binaryResult, linearResult);
        long slower = Math.Min(binaryResult, linearResult);
        Console.WriteLine($"{fasterMethod} is faster by {fasterTime - slower} ms");
    }

}