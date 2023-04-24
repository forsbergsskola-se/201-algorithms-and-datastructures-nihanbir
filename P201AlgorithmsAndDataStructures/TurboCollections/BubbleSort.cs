namespace TurboCollections;

public static partial class TurboSort
{
    public static void BubbleSort(TurboLinkedList<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            bool swapped = false;
            for (int j = 0; j < list.Count - 1; j++)
            {
                if (list[j] > list[j + 1]) (list[j], list[j + 1]) = (list[j + 1], list[j]);
                swapped = true;
            }
            if(!swapped) break;
        }
    }
}