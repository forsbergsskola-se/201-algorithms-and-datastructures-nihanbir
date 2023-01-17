namespace TurboCollections;

public static class TurboMaths
{
    public static void SayHello()
    {
        Console.WriteLine($"Hello, I'm {typeof(TurboMaths)}");
    }
    // Returns all Odd Numbers until the given number. e.g.:
    // GetOddNumbers(12) -> {0, 2, 4, 8, 10, 12};
    // GetOddNumbers(15) -> {0, 2, 4, 8, 10, 12, 14};
    // GetOddNumbers(-1) -> {};
    // GetOddNumbers(0) -> {0};
    public static List<int> GetEvenNumbersList(int maxNumber)
    {
        List<int> list = new();
        for (int i = 0; i <= maxNumber; i += 2)
        {
            list.Add(i);
        }
        return list;
    }
    
    public static IEnumerable<int> GetEvenNumbers(int maxNumber)
    {
        for (int i = 0; i <= maxNumber; i++)
        {
            if(i % 2 == 0) yield return i;
        }
    }
}