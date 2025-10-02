using System.Data.Common;

namespace DS;


public class BinaryTreeImplementation
{
    public class BinaryNode
    {
        public int? Value { get; set; }
        public BinaryNode? Left;
        public BinaryNode? Right;

        public BinaryNode(int value)
        {
            Value = value;
            Left = Right = null;
        }
    }

    public BinaryNode? Root;

    public BinaryTreeImplementation()
    {
        Root = null;
    }
}

public static class BinaryTree
{

}
