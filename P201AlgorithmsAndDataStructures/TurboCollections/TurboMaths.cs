namespace TurboCollections;

public static class TurboMaths
{
    public static void SayHello()
    {
        Console.WriteLine($"Hello, I'm {typeof(TurboMaths)}");
    }
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

    public static float CalculateAverage(float[] array)
    {
        float sum = 0;
        foreach (var i in array) sum += i;
        return sum / array.Length;
    }
    
    public static int RecursiveFib(int n)  
    {  
        if (n == 0) return 0; 
        if (n == 1) return 1;  
        return RecursiveFib(n - 1) + RecursiveFib(n - 2);  
    }

    public static int IterativeFib(int n)
    {
        int firstNumber = 0, secondNumber = 1, result = 0;

        if (n == 0) return 0;
        if (n == 1) return 1;

        for (int i = 2; i <= n; i++)
        {
            result = firstNumber + secondNumber;
            firstNumber = secondNumber;
            secondNumber = result;
        }
        return result;
    }
}