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
}