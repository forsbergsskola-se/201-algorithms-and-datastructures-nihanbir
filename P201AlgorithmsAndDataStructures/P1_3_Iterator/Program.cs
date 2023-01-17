using System.Collections;
using TurboCollections;

List<int> numbers = new() {
    1,
    1,
    2,
    3,
    5
};
IEnumerator num = numbers.GetEnumerator();

while (num.MoveNext()) Console.WriteLine(num.Current);

int maxNumber = 12;

foreach (int item in TurboMaths.GetEvenNumbersList(maxNumber))
{
    Console.WriteLine($"GetOddNumbersList ({maxNumber}): {item}");
}

foreach (int item in TurboMaths.GetEvenNumbers(maxNumber))
{
    Console.WriteLine($"GetOddNumber ({maxNumber}): {item}");
}


