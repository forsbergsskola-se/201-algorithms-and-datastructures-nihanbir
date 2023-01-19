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
        // Insert Code from AddNumber Example in #4 here
        LastNode = new Node {
            Value = item,
            Previous = LastNode
        };
    }

    public T? Peek()
    {
        // Return the Value of Last Node here.
        if (LastNode != null) return LastNode.Value;
        throw new NullReferenceException();
    }

    public T Pop()
    {
        // 1. Save the Last Node locally so we can return the value later.
        Node? node = LastNode;
        // 2. Now, assign the Last Node's Previous Node to be the Last Node.
        if (LastNode != null) LastNode = LastNode.Previous;
        // -- This effectively removes the previously Last Node of the Stack
        // -- Imagine LastNode is customer 436
        // -- -- who remembered that customer 435 was before him.
        // -- We assign that before customer 435 to LastNode.
        // -- -- 435 knows that 434 was before him.
        // -- -- But he has no memory of customer 436.
        // Now, return the Value of the Node that you cached in Step 1.
        return node.Value;
    }

    public void Clear() {
        // This one is incredibly easy. Just assign null to Field LastNode
        LastNode = null;
        // -- This is like pretending you never new that there is any last customer.
        // -- by forgetting the latest customer, you forget them all.
    }

    public int Count {
        get{
            // Here, you need to do a while loop over all nodes
            // Similar to the previous PrintAllNodes Function
            // But instead of Printing Nodes, you just count how many Nodes you have visited
            // Similar to this:
            int count = 0;
            Node? lastNode = LastNode;
            while(lastNode != null/* remove false and replace with correct condition...*/)
            {
                count++;
                lastNode = lastNode.Previous;
            }
            return count;
        }
    }

    public IEnumerator<T> GetEnumerator() {
        // This one is a bonus and a bit more difficult.
        // You need to create a new class named Enumerator.
        // You find the details below.
        // This might look confusing. But remember? Last In. First Out.
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
            // if we don't have a current node, we start with the first node
            if(CurrentNode == null) CurrentNode = FirstNode; 
            // Assign the Current Node's Previous Node to be the Current Node.
            else CurrentNode = CurrentNode.Previous;
            // Return, whether there is a CurrentNode. Else, we have reached the end of the Stack, there's no more Elements.
            return CurrentNode != null;
        }
        
        // Return the Current Node's Value.
        public T Current => CurrentNode.Value;

        // This Boiler Plate is necessary to correctly implement `IEnumerable` interface.
        object IEnumerator.Current => Current;

        public void Reset() {
            // Look at Move. How can you make sure that this Enumerator starts over again?
            CurrentNode = null;
        }

        public void Dispose()
        {
            // This function is not needed right now.
        }
    }
}