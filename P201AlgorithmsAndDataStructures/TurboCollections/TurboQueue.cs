using System.Collections;

namespace TurboCollections;

public class TurboQueue<T> : ITurboQueue<T>
{
    public int Count { get; set; }

    private T[] Array = System.Array.Empty<T>();
    
    public void Enqueue(T item)
    {
        if (Count == Array.Length)
        {
            T[] newArray = new T[Math.Max(Array.Length * 2, 1)];
            for (int i = 0; i < Array.Length; i++)
            {
                newArray[i] = Array[i];
            }
            Array = newArray;
        }
        Array[Count] = item;
        Count++;
    }

    public T Peek()
    {
        return Array[0];
    }

    public T Dequeue()
    {
        if (Count == 0) throw new NullReferenceException();
        T firstIndex = Array[0];
        Count--;
        for (int i = 0; i < Count; i++)
        {
            Array[i] = Array[i+1];
        }
        return firstIndex;
    }

    public void Clear()
    {
        Array = System.Array.Empty<T>();
        Count = 0;
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        var enumerator = new Enumerator(Array ?? throw new InvalidOperationException());
        return enumerator;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    class Enumerator : IEnumerator<T>
    {
        private T[] Array;
        private int _currentIndex = -1;
        
        public Enumerator(T[] array)
        {
            Array = array;
        }
        
        public bool MoveNext()
        {
            _currentIndex++;
            return _currentIndex < Array.Length + 1;
        }

        public void Reset()
        {
            _currentIndex -= 1;
        }

        public T Current => Array[_currentIndex];

        object IEnumerator.Current => Current;
        
        public void Dispose() {}
    }
}
