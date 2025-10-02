namespace DS;

// general tree - 0 ore more children
public class Node<T>
{
    public T? Value { get; set; }
    public List<Node<T>> Children { get; set; }

    public Node() : this(default)
    {
        // delegated to param ctor
    }

    public Node(T? Value)
    {
        this.Value = Value;
        Children = [];
    }
}

public class TreeImplementation<T>
{
    public Node<T>? Root { get; set; }

    public TreeImplementation()
    {
        Root = new();
    }

    public void LevelOrderTraversal()
    {
        QueueImplementation<Node<T>> q = new(Root);

        // 1. create a queue
        // 2. add root node to queue
        // 3. while there are elements in the queue, print the value at the front
        // 4. dequeue the node and add all of it's children into the queue
        // 5. Repeat step 2-4 until there are no elements in the queue

        while (!q.IsEmpty())
        {
            Node<T>? currentNode = q.GetFront();
            if (currentNode != null)
            {
                if (q.Dequeue())
                {
                    for (int i = 0; i < currentNode.Children.Count; i++)
                    {
                        q.Enqueue(currentNode.Children[i]);
                    }
                }

                Console.Write($"{currentNode.Value} ");
                Console.Write('\n');
            }
        }
    }
}

public static class Tree
{
    public static void Begin()
    {
        TreeImplementation<int> tree = new();

        Node<int> node = new();
        node.Value = 1;

        for (int i = 2; i <= 5; i++)
        {
            Node<int> child = new(i);
            node.Children.Add(child);
        }

        for (int i = 6; i <= 10; i++)
        {
            Node<int> child = new(i);
            node.Children[0].Children.Add(child);
        }

        for (int i = 11; i <= 13; i++)
        {
            Node<int> child = new(i);
            node.Children[3].Children.Add(child);
        }

        tree.Root = node;

        tree.LevelOrderTraversal();
    }
}
