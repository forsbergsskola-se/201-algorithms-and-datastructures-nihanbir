namespace TurboCollections;

public static partial class TurboSearch
{
    public static int LinearSearch(TurboLinkedList<int> list, int value)
    {
        var count = 0;
        foreach (var i in list)
        {
            if (list[i] == value) return count;
            count++;
        }
        return -1;
    }
}