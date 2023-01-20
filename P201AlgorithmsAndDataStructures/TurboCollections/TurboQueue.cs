using System.Collections;

namespace TurboCollections;

public class TurboQueue<T> : ITurboQueue<T>
{
    public int Count => Array.Length;

    protected T[] Array = System.Array.Empty<T>();
    
    public void Enqueue(T item)
    {
        T[] newArray = new T[Array.Length + 1];
        newArray[^1] = item;
        for (int i = 0; i < Array.Length; i++)
        {
            newArray[i] = Array[i];
        }
        Array = newArray;
    }

    public T Peek()
    {
        return Array[0];
    }

    public T Dequeue()
    {
        T firstIndex = Array[0];
        T[] newArray = new T[Array.Length-1];
        for (int i = 0; i < newArray.Length; i++)
        {
            newArray[i] = Array[i+1];
        }
        Array = newArray;
        return firstIndex;
    }

    public void Clear()
    {
        Array = System.Array.Empty<T>();
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
