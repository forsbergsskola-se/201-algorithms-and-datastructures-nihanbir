using System.Collections;
using System.Diagnostics;

namespace TurboCollections;

public interface ITurboQueue<T> : IEnumerable<T> {
    // returns the current amount of items contained in the stack.
    int Count { get; }
    // adds one item to the back of the queue.
    void Enqueue(T item);
    // returns the item in the front of the queue without removing it.
    T Peek();
    // returns the item in the front of the queue and removes it at the same time.
    T Dequeue();
    // removes all items from the queue.
    void Clear();
}

public class TurboLinkedQueue<T> : ITurboQueue<T> {
    // This class is VERY similar to the TurboLinkedStack
    class Node {
        public T? Value;
        // But we store the Next Node for each Node instead.
        public Node? Next;
    }
    // Also, we store the first instead of the last Node. First Come, First Serve.
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
        // This is a bit more complicated. You need to let the last Node in the Queue know who's next after him.
        // No other choice but looping through your Nodes until you reach the end.
        // You know that you've reached the end, if the current Node's Next Node is null.
        // Then, you assign a new Node containing the value to the current node's Next field.

        // Analogy: In our store, we always remember who's the first that arrived. When a new customer arrives, we tell the last customer, that the new customer will be after them.
        // However, we only know, who's the first customer. And each customer knows, who comes after them. So we continue asking each customer, who comes after them, until one says: "No one! I'm last in the Queue" and we can tell them: "Not anymore! This new customer is now last in the queue"
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

    // Everything else is super similar to the TurboLinkedStack!
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
            CurrentNode = firstNode;
        }
        
        public bool MoveNext()
        {
            if(CurrentNode == null) CurrentNode = FirstNode; 
            // Assign the Current Node's Previous Node to be the Current Node.
            else CurrentNode = CurrentNode.Next;
            // Return, whether there is a CurrentNode. Else, we have reached the end of the Stack, there's no more Elements.
            return CurrentNode != null;
        }

        public void Reset()
        {
            CurrentNode = FirstNode;
        }

        public T Current { get; }

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
