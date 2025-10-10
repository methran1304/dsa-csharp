using System.Data.Common;
using System.Linq.Expressions;

namespace DS;


public class BinaryTreeImplementation
{
    public class BinaryNode
    {
        public int Value { get; set; }
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

    public bool Find(int value)
    {
        return RecursiveFind(Root, value);
    }
    
    private bool RecursiveFind(BinaryNode? root, int value)
    {
        if (root == null) return false;
        if (root.Value == value) return true;
        if (root.Value > value) return RecursiveFind(root.Left, value);
        else return RecursiveFind(root.Right, value);
    }

    public bool Insert(int value)
    {
        Root = RecursiveInsert(Root, value);
        return true;
    }

    private BinaryNode? RecursiveInsert(BinaryNode? root, int value)
    {
        if (root == null)
        {
            return new BinaryNode(value);
        }

        if (root.Value == value)
        {
            return root;
        }
        if (root.Value > value)
        {
            root!.Left = RecursiveInsert(root.Left, value);
        }
        else
        {
            root!.Right = RecursiveInsert(root.Right, value);
        }

        return root;
    }


    public void BFS()
    {
        if (Root == null) return;

        QueueImplementation<BinaryNode> queue = new();
        queue.Enqueue(Root);

        while (!queue.IsEmpty())
        {
            BinaryNode currentNode = queue.GetFront()!;
            queue.Dequeue();

            if (currentNode?.Left != null)
            {
                queue.Enqueue(currentNode.Left);
            }

            if (currentNode?.Right != null)
            {
                queue.Enqueue(currentNode.Right);
            }

            Console.WriteLine(currentNode?.Value);
        }
    }

    public void DFS()
    {
        RecursiveDFS(Root);
    }

    // in order
    private void RecursiveDFS(BinaryNode? root)
    {
        if (root == null) return;

        RecursiveDFS(root.Left);
        Console.WriteLine(root.Value);
        RecursiveDFS(root.Right);
    }

    public void PreOrderDFS()
    {
        RecursivePreOrderDFS(Root);
    }

    private void RecursivePreOrderDFS(BinaryNode? root)
    {
        if (root == null) return;

        Console.WriteLine(root.Value);
        RecursivePreOrderDFS(root.Left);
        RecursivePreOrderDFS(root.Right);
    }

    public void PostOrderDFS()
    {
        RecursivePostOrderDFS(Root);
    }

    private void RecursivePostOrderDFS(BinaryNode? root)
    {
        if (root == null) return;

        RecursivePostOrderDFS(root.Left);
        RecursivePostOrderDFS(root.Right);
        Console.WriteLine(root.Value);
    }

}

public static class BinaryTree
{
    public static void Begin()
    {
        BinaryTreeImplementation bt = new();

        bt.Insert(1);
        bt.Insert(-2);
        bt.Insert(2);
        bt.Insert(-4);
        bt.Insert(-1);
        bt.Insert(8);

        bt.PreOrderDFS();
    }
}
