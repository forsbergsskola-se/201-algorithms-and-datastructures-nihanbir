using System.Collections;
using System.Diagnostics;

namespace TurboCollections;

public interface ITurboQueue<T> : IEnumerable<T> {
    int Count { get; }
    void Enqueue(T item);
    T Peek();
    T Dequeue();
    void Clear();
}

public class TurboLinkedQueue<T> : ITurboQueue<T> {
    class Node {
        public T? Value;
        public Node? Next;
    }
    Node? FirstNode;
    Node? LastNode;
    

    public int Count { get; set; }

    public void Enqueue(T value)
    {
        if (FirstNode == null)
        {
            FirstNode = new Node
            {
                Value = value
            };
            LastNode = FirstNode;
        }
        else
        {
            Debug.Assert(LastNode != null, nameof(LastNode) + " != null");
            LastNode.Next = new Node
            {
                Value = value
            };
            LastNode = LastNode.Next;
        }
        Count++;
    }

    public T Peek()
    {
        if (FirstNode != null) return FirstNode.Value;
        throw new NullReferenceException();
    }

    public T Dequeue()
    {
        if (FirstNode != null)
        {
            Node t = FirstNode;
            FirstNode = FirstNode.Next;
            Count--;
            return t.Value;
        }
        throw new NullReferenceException();
    }

    public void Clear()
    {
        FirstNode = null;
        Count = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var enumerator = new Enumerator(FirstNode ?? throw new InvalidOperationException());
        return enumerator;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    class Enumerator : IEnumerator<T>
    {
        private Node? CurrentNode;
        private Node? FirstNode;
        
        public Enumerator(Node firstNode)
        {
            FirstNode = firstNode;
        }
        
        public bool MoveNext()
        {
            if(CurrentNode == null) CurrentNode = FirstNode; 
            else CurrentNode = CurrentNode.Next;
            return CurrentNode != null;
        }

        public void Reset()
        {
            CurrentNode = null;
        }

        public T Current => CurrentNode.Value;

        object IEnumerator.Current
        {
            get
            {
                if (Current != null) return Current;
                throw new NullReferenceException();
            }
        }
        public void Dispose() {}
    }
}