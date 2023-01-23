   
namespace TurboCollections.Test;

public static class MathsTests
{
 [Test]
    public static void SayHelloExists()
    {
        TurboMaths.SayHello();
        Assert.Pass();
    }

    [Test]
    [TestCase(12)]
    [TestCase(15)]
    [TestCase(-1)]
    [TestCase(0)]
    public static void CanGetEvenNumbersList(int maxNumber)
    {
        foreach (var i in TurboMaths.GetEvenNumbersList(maxNumber))
        {
            if(i%2 != 0 || i > maxNumber) Assert.Fail();
        }
    }

    [Test]
    [TestCase(12)]
    [TestCase(15)]
    [TestCase(-1)]
    [TestCase(0)]
    public static void CanGetEvenNumbers(int maxNumber)
    {
        foreach (var i in TurboMaths.GetEvenNumbers(maxNumber))
        {
            if(i%2 != 0 || i > maxNumber) Assert.Fail();
        }
    }

    [Test]
    public static void CanCalculateAverage()
    {
        float[] array1 = {2,7,5,6};
        Assert.That(TurboMaths.CalculateAverage(array1), Is.EqualTo(5));
    }
    [Test]
    public static void TestFibonacci()
    {
        var fibs = Enumerable.Range(0, 10)
            .Select(TurboMaths.RecursiveFib);
        
        Assert.That(fibs, Is.EqualTo(new []{0, 1, 1, 2, 3, 5, 8, 13, 21, 34}));
    }
}