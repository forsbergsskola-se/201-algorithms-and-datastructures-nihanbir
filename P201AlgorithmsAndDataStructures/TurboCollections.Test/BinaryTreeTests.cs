namespace TurboCollections.Test;

public class BinaryTreeTests
{
    // [Test]
    // public void BinaryTreeWorks()
    // {
    //     BinaryTree<int> tree = new BinaryTree<int>();
    //     var root = tree.Root;
    //     var leftChild = root.LeftChild;
    //     var rightChildOfLeftChild = leftChild.RightChild;
    //
    //     int value = rightChildOfLeftChild.Value;
    //
    // }
    //
    // [Test]
    // public void BinaryTreeWorksWithNodes()
    // {
    //     BinaryTree<int> tree = new BinaryTree<int>();
    //     var root = tree.Root;
    //     root.GetLeftChild().GetRightChild().GetValue();
    // }
    
    [Test]
    public void BuildLetterTree_indices()
    {
        var tree = new BinaryTree<char>();
        var a = tree.Root;
        a.Value = 'A';
        var b = a.LeftChild;
        b.Value = 'B';
        var c = a.RightChild;
        c.Value = 'C';
    }
}