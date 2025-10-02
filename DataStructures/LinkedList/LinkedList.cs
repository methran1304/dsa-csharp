using System.Collections;
namespace DS;

public class LLImplementation<T> : IEnumerable<T>
{
    private class Node
    {
        public T? Value { get; set; }
        public Node? NextNode { get; set; }
        public Node? PrevNode { get; set; }
        public Node(T? Value)
        {
            this.Value = Value;
            NextNode = PrevNode = null;
        }
    }

    private Node? Head { get; set; }
    private Node? Tail { get; set; }
    public uint Count { get; private set; }


    public LLImplementation()
    {
        Head = Tail = null;
        Count = 0;
    }

    // insert element at Count-th index
    public void InsertAtTail(T? value)
    {
        Node newNode = new(value); // create new node

        if (Head == null || Tail == null)
        {
            Head = Tail = newNode; // first node in the linked list
        }
        else
        {
            newNode.PrevNode = Tail;
            Tail.NextNode = newNode;
            Tail = newNode;
        }

        Count++;
    }

    // insert element at 0th index
    public void InsertAtHead(T? value)
    {
        Node newNode = new(value); // create new node
        newNode.PrevNode = null; // First node, no previous node
        newNode.NextNode = Head;

        if (Head == null)
        {
            Tail = newNode;
        }
        else
        {
            Head.PrevNode = newNode;
        }

        Head = newNode;
        Count++;
    }

    // insert element at i-th position (0 based indexing)
    public void InsertAtPosition(T? value, uint position)
    {
        if (position > Count)
            return;

        if (position == Count)
        {
            InsertAtTail(value);
        }
        else if (position == 0)
        {
            InsertAtHead(value);
        }
        else
        {
            Node? targetNode = Head;
            uint currentIndex = 0;

            while (currentIndex < position && targetNode != null)
            {
                targetNode = targetNode.NextNode;
                currentIndex++;
            }

            if (targetNode == null) return;

            Node newNode = new(value);
            newNode.PrevNode = targetNode.PrevNode;
            newNode.NextNode = targetNode;

            if (targetNode.PrevNode != null)
            {
                targetNode.PrevNode.NextNode = newNode;
            }

            targetNode.PrevNode = newNode;
            Count++;
        }
    }

    public void DeleteAtHead()
    {
        if (Head == null)
            return;

        Node? nextNode = Head.NextNode;
        Head = nextNode;
        if (Head == null)
            Tail = null;
        else
            Head.PrevNode = null;
        Count--;
    }

    public void DeleteAtTail()
    {
        if (Head == null)
            return;

        if (Tail == Head)
        {
            Head = Tail = null;
        }
        else
        {
            Tail = Tail?.PrevNode;
            Tail!.NextNode = null;
        }

        Count--;
    }

    public void DeleteAtPosition(uint position)
    {
        if (position > Count)
            return;

        if (position == Count - 1)
        {
            DeleteAtTail();
        }
        else if (position == 0)
        {
            DeleteAtHead();
        }
        else
        {
            Node? targetNode = Head;
            uint currentIndex = 0;

            while (currentIndex < position && targetNode != null)
            {
                targetNode = targetNode.NextNode;
                currentIndex++;
            }

            if (targetNode == null) return;

            if (targetNode.PrevNode != null) targetNode.PrevNode.NextNode = targetNode.NextNode;
            if (targetNode.NextNode != null) targetNode.NextNode.PrevNode = targetNode.PrevNode;

            Count--;
        }
    }

    public bool Find(T? value)
    {
        if (Head == null)
            return false;

        Node? tempNode = Head;

        while (tempNode != null)
        {
            if (EqualityComparer<T>.Default.Equals(tempNode.Value, value))
            {
                return true;
            }

            tempNode = tempNode.NextNode;
        }
        return false;
    }

    public T? GetHead()
    {
        if (Head == null)
            return default(T);

        return Head.Value;
    }

    public T? GetTail()
    {
        if (Tail == null)
            return default(T);

        return Tail.Value;
    }

    public void Traverse()
    {
        if (Head == null)
            return;

        Node? tempNode = Head;

        while (tempNode != null)
        {
            Console.Write(tempNode.Value);
            if (!IsLastNode(tempNode))
            {
                Console.Write(" -> ");
            }
            tempNode = tempNode.NextNode;
        }

        Console.Write('\n');
    }

    private bool IsLastNode(Node node) => node == Tail;

    public IEnumerable<T> Reverse()
    {
        Node? tempNode = Tail;

        while (tempNode != null)
        {
            if (tempNode.Value != null)
            {
                yield return tempNode.Value;
            }
            tempNode = tempNode.PrevNode;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node? tempNode = Head;

        while (tempNode != null)
        {
            if (tempNode.Value != null)
            {
                yield return tempNode.Value;
            }
            tempNode = tempNode.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public static class LinkedList
{
    public static void Begin()
    {
        LLImplementation<int> myList = new();
        Console.WriteLine($"myList length: {myList.Count}");

        for (int i = 0; i < 10; i++)
        {
            myList.InsertAtTail(i);
        }

        foreach (var element in myList.Reverse())
        {
            Console.WriteLine(element);
        }
        
        

        // Console.WriteLine($"myList length after multiple insertion: {myList.Count}");
        // Console.WriteLine("myList after multiple insertion");
        // myList.Traverse();

        // Console.WriteLine($"myList length after insertion at position 2: {myList.Count}");
        // myList.InsertAtPosition(99, 11);

        // myList.Traverse();

        // myList.DeleteAtHead();
        // Console.WriteLine("List after deleting at head");
        // myList.Traverse();

        // TODO: deletion by index, element (can be used for deleteFirst, deleteLast), findByElement, findByIndex
    }
}