using System.Collections;

namespace TurboCollections;

public class TurboLinkedStack<T> : IEnumerable<T> {
    class Node {
        public T? Value;
        public Node? Previous;
    }
    Node? LastNode;

    public void Push(T item)
    {
        LastNode = new Node {
            Value = item,
            Previous = LastNode
        };
    }

    public T? Peek()
    {
        if (LastNode != null) return LastNode.Value;
        throw new NullReferenceException();
    }

    public T Pop()
    {
        Node? node = LastNode;
        if (LastNode != null) LastNode = LastNode.Previous;
        return node.Value;
    }

    public void Clear() {
        LastNode = null;
    }

    public int Count {
        get{
            int count = 0;
            Node? lastNode = LastNode;
            while(lastNode != null)
            {
                count++;
                lastNode = lastNode.Previous;
            }
            return count;
        }
    }

    public IEnumerator<T> GetEnumerator() {
        var enumerator = new Enumerator(LastNode ?? throw new InvalidOperationException());
        return enumerator;
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    class Enumerator : IEnumerator<T> {
        private Node? CurrentNode;
        private Node? FirstNode;

        public Enumerator(Node firstNode)
        {
            FirstNode = firstNode;
        }

        public bool MoveNext(){
            if(CurrentNode == null) CurrentNode = FirstNode; 
            else CurrentNode = CurrentNode.Previous;
            return CurrentNode != null;
        }
        
        public T Current => CurrentNode.Value;

        object IEnumerator.Current => Current;

        public void Reset() {
            CurrentNode = null;
        }

        public void Dispose() {}
    }
}