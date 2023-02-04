namespace TurboCollections;

public class BinaryTree<T>
{
    readonly T[] _values = new T[1_000_000];
    public Node Root => new(0, this);
    int GetLeftChildIndex(int nodeIndex) => 2 * nodeIndex + 1;
    int GetRightChildIndex(int nodeIndex) => 2 * nodeIndex + 2;
    T GetValue(int nodeIndex) => _values[nodeIndex];

    void SetValue(int nodeIndex, T value)
    {
        if (_values.Length <= nodeIndex) { /* resize */ }
        _values[nodeIndex] = value;
    }

    public readonly struct Node
    {
        readonly int _nodeIndex;
        readonly BinaryTree<T> _tree;

        public T Value
        {
            get => _tree.GetValue(_nodeIndex);
            set => _tree.SetValue(_nodeIndex, value);
        }

        public Node(int nodeIndex, BinaryTree<T> tree)
        {
            _nodeIndex = nodeIndex;
            _tree = tree;
        }

        public Node LeftChild => new(_tree.GetLeftChildIndex(_nodeIndex), _tree);
        public Node RightChild => new(_tree.GetRightChildIndex(_nodeIndex), _tree);
    }
}

