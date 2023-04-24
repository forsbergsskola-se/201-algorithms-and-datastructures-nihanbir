namespace TurboCollections;

public static partial class TurboSearch
{
    public static int BinarySearch(TurboLinkedList<int> list, int value)
    {
        int lowerBound = 0;
        int upperBound = list.Count - 1;

        while (true)
        {
            if (upperBound < lowerBound) return -1;

            int midPoint = (lowerBound + upperBound) / 2;

            if (list[midPoint] < value) lowerBound = midPoint + 1;
            else if (list[midPoint] > value) upperBound = midPoint - 1;
            else if (list[midPoint] == value) return midPoint;
        }
    }
}